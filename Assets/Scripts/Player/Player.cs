using System;
using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
public class Player : MonoBehaviour
{
    private PlayerMover _playerMover;
    private int _score;

    public static Action<int> ScoreChanged;
    public static Action GameOver;

    private void Start()
    {
        _playerMover = GetComponent<PlayerMover>();
    }

    private void OnEnable()
    {
        EnemyCollisionHandler.Killed += OnAddScore;
        GameUI.GameBegun += ResetPlayer;
        GameUI.GoneMenu += ResetPlayer;
    }

    private void OnDisable()
    {
        EnemyCollisionHandler.Killed -= OnAddScore;
        GameUI.GameBegun -= ResetPlayer;
        GameUI.GoneMenu -= ResetPlayer;
    }

    public void ResetPlayer()
    {
        _score = 0;
        _playerMover.Reset();
        ScoreChanged?.Invoke(_score);
    }

    public void OnAddScore()
    {
        _score++;
        ScoreChanged?.Invoke(_score);
    }

    public void Die()
    {
        GameOver?.Invoke();
    }
}
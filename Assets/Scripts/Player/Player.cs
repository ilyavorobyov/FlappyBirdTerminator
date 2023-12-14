using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
public class Player : MonoBehaviour
{
    private PlayerMover _playerMover;
    private int _score;

    private void Start()
    {
        _playerMover = GetComponent<PlayerMover>();
    }

    public void ResetPlayer()
    {
        _score = 0;
        _playerMover.Reset();
    }

    public void Die()
    {
        Debug.Log("die");
        Time.timeScale = 0;
    }
}
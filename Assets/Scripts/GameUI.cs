using System;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Button _startButton;
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _menuButton;
    [SerializeField] private GameOverScreen _gameOverScreen;

    public static Action GameBegun;
    public static Action GoneMenu;

    private void Awake()
    {
        Time.timeScale = 0f;
    }

    private void OnEnable()
    {
        Player.GameOver += OnGameOver;
        _startButton.onClick.AddListener(OnStartButtonClick);
        _restartButton.onClick.AddListener(OnStartButtonClick);
        _menuButton.onClick.AddListener(OnMenuButtonClick);
    }

    private void OnDisable()
    {
        Player.GameOver -= OnGameOver;
        _startButton.onClick.RemoveListener(OnStartButtonClick);
        _restartButton.onClick.RemoveListener(OnStartButtonClick);
        _menuButton.onClick.RemoveListener(OnMenuButtonClick);
    }

    private void OnStartButtonClick()
    {
        Time.timeScale = 1f;
        _startButton.gameObject.SetActive(false);
        _gameOverScreen.gameObject.SetActive(false);
        GameBegun?.Invoke();
    }

    private void OnMenuButtonClick()
    {
        _gameOverScreen.gameObject.SetActive(false);
        _startButton.gameObject.SetActive(true);
        GoneMenu?.Invoke();
    }

    private void OnGameOver()
    {
        Time.timeScale = 0f;
        _gameOverScreen.gameObject.SetActive(true);
    }
}
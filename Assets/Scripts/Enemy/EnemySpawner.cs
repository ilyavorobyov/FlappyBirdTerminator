using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Container _container;
    [SerializeField] private Enemy _enemyTemplate;
    [SerializeField] private Player _player;
    [SerializeField] private float _spawnTime;
    [SerializeField] private float _maxYPosition;
    [SerializeField] private float _minYPosition;

    private List<Enemy> _enemies = new List<Enemy>();
    private int _capacity = 3;
    private Coroutine _spawn;

    private void Awake()
    {
        for(int i = 0;  i < _capacity; i++)
        {
            Enemy enemy = Instantiate(_enemyTemplate, _container.transform);
            enemy.gameObject.SetActive(false);
            _enemies.Add(enemy);
        }
    }

    private void OnEnable()
    {
        GameUI.GameBegun += OnStartSpawn;
        Player.GameOver += OnGameOver;
    }

    private void OnDisable()
    {
        GameUI.GameBegun -= OnStartSpawn;
        Player.GameOver -= OnGameOver;
    }

    private void OnDestroy()
    {
        StopSpawn();
    }

    private bool TryGetEnemy(out Enemy enemy)
    {
        enemy = _enemies.FirstOrDefault(p => p.gameObject.activeSelf == false);
        return enemy != null;
    }

    private void OnGameOver()
    {
        StopSpawn();

        foreach (Enemy enemy in _enemies)
        {
            enemy.gameObject.SetActive(false);
        }
    }

    private void OnStartSpawn()
    {
        _spawn = StartCoroutine(Spawn());
    }

    private void StopSpawn()
    {
        if( _spawn != null )
            StopCoroutine(_spawn);
    }

    private IEnumerator Spawn()
    {
        var waitForSeconds = new WaitForSeconds(_spawnTime);
        float addingXPosition = 5f;
        float zPosition = 0f;
        Vector3 spawnPoint;
        bool isSpawning = true;

        while(isSpawning)
        {
            yield return waitForSeconds;

            if(TryGetEnemy(out Enemy enemy))
            {
                float yPosition = Random.Range(_minYPosition, _maxYPosition);
                spawnPoint = new Vector3(_player.transform.position.x + addingXPosition,
                    yPosition, zPosition);
                enemy.transform.position = spawnPoint;
                enemy.gameObject.SetActive(true);
            }
        }
    }
}
using System;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] private float _speed;

    private float _lifeTime = 3;

    private void Start()
    {
        Destroy(gameObject, _lifeTime);
    }

    private void OnEnable()
    {
        Player.GameOver += OnGameover;
    }

    private void OnDisable()
    {
        Player.GameOver -= OnGameover;
    }

    private void Update()
    {
        transform.Translate(Vector3.left * _speed * Time.deltaTime);
    }

    private void OnGameover()
    {
        Destroy(gameObject);
    }
}
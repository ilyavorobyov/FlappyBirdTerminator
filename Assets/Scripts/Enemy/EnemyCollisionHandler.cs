using System;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyCollisionHandler : MonoBehaviour
{
    private Enemy _enemy;

    public static Action Killed;

    private void Awake()
    {
        _enemy = GetComponent<Enemy>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out PlayerBullet playerBullet))
        {
            _enemy.Die();
            playerBullet.Die();
            Killed?.Invoke();
        }

        if(collision.TryGetComponent(out Border border))
        {
            _enemy.Die();
        }
    }
}
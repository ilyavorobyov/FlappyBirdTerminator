using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyCollisionHandler : MonoBehaviour
{
    private Enemy _enemy;

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
        }
    }
}
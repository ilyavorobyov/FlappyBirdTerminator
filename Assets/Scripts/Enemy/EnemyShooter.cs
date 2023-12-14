using System.Collections;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    [SerializeField] private EnemyBullet _enemyBullet;
    [SerializeField] private Transform _shotPoint;

    private float _shotInterval = 1.5f;
    private Coroutine _shot;

    private void OnEnable()
    {
        _shot = StartCoroutine(Shoot());
    }

    private void OnDisable()
    {
        StopShoot();
    }

    private void OnDestroy()
    {
        StopShoot();
    }

    private void StopShoot()
    {
        if (_shot != null)
            StopCoroutine(_shot);
    }

    private IEnumerator Shoot()
    {
        var waitForSeconds = new WaitForSeconds(_shotInterval);
        bool isShooting = true;

        while (isShooting)
        {
            yield return waitForSeconds;
            Instantiate(_enemyBullet, _shotPoint.transform.position, Quaternion.identity);
        }
    }
}

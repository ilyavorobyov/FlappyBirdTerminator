using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    [SerializeField] private PlayerBullet _playerBullet;
    [SerializeField] private Transform _shotPoint;

    private void OnShoot()
    {
        PlayerBullet playerBullet =  Instantiate(_playerBullet, _shotPoint.transform.position, 
            Quaternion.identity);
        playerBullet.SetRotation(transform.rotation);
    }
}
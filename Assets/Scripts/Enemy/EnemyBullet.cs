using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] private float _speed;

    private float _lifeTime = 5;

    private void Start()
    {
        Destroy(gameObject, _lifeTime);
    }
    private void Update()
    {
        transform.Translate(Vector3.left * _speed * Time.deltaTime);
    }
}
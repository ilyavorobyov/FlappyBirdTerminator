using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    private float _speed = 5;
    private float _lifeTime = 1f;

    private void Start()
    {
        Destroy(gameObject, _lifeTime);
    }

    private void Update()
    {
        transform.Translate(Vector3.right * _speed * Time.deltaTime);
    }

    public void SetRotation(Quaternion rotation)
    {
        transform.rotation = rotation;
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
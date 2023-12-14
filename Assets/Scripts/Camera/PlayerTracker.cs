using UnityEngine;

public class PlayerTracker : MonoBehaviour
{
    [SerializeField] private Player _player;

    private float _xOffset = -1.4f;

    private void Update()
    {
        transform.position = new Vector3(_player.transform.position.x -
            _xOffset, transform.position.y, transform.position.z);
    }
}
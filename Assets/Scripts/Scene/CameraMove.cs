using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private float _offset;
    private void Update()
    {
        if (_player != null)
            transform.position = new Vector3(_player.transform.position.x + _offset, transform.position.y, transform.position.z);
    }
}

using System;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class GameArea : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private BoxCollider2D _collider;
    [SerializeField] private LayerMask _playerMask;

    public event Action playerExitGameArea;

    private void OnTriggerExit2D(Collider2D other)
    {
        if ((_playerMask & (1 << other.gameObject.layer)) != 0)
        {
            playerExitGameArea?.Invoke();
        }
    }

    private void Start()
    {
        float height = _camera.orthographicSize * 2;
        float width = height * Screen.width / Screen.height;
        _collider.size = new Vector2(width, height);
    }

    private void Update()
    {
        transform.position = _camera.transform.position;
    }
}

using System;
using UnityEngine;

public class Ground : MonoBehaviour
{
    [SerializeField] private LayerMask _playerMask;

    public event Action PlayerTouchGround;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if ((_playerMask & (1 << other.gameObject.layer)) != 0)
        {
            PlayerTouchGround?.Invoke();
        }
    }
}

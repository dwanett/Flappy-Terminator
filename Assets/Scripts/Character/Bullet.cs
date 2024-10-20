using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _timeLive;
    [SerializeField] private Rigidbody2D _rigidbody2D;
    
    private LayerMask _targetMask;
    private float _damage;
    private Vector2 _direction;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if ((_targetMask & (1 << other.gameObject.layer)) != 0)
        {
            Character character = other.gameObject.GetComponent<Character>();
            if (character != null)
            {
                character.TakeDamage(_damage);
                Destroy(gameObject);
            }
        }
    }

    private void Start()
    {
        _rigidbody2D.velocity = _direction * _speed;
        StartCoroutine(LiveBullet());
    }

    public void ChangeDirection(Vector2 newDirection)
    {
        _direction = newDirection;
    }
    
    public void ChangeTargetMask(LayerMask newTargetMask)
    {
        _targetMask = newTargetMask;
    }
    
    public void ChangeDamage(float newDamage)
    {
        _damage = newDamage;
    }
    
    private IEnumerator LiveBullet()
    {
        yield return new WaitForSeconds(_timeLive);
        Destroy(gameObject);
    }
}
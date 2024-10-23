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

    public event Action<Bullet> Die;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if ((_targetMask & (1 << other.gameObject.layer)) != 0)
        {
            Character character = other.gameObject.GetComponent<Character>();
            if (character != null)
            {
                character.TakeDamage(_damage);
                Die?.Invoke(this);
            }
        }
    }

    private void OnEnable()
    {
        StartCoroutine(LiveBullet());
    }

    public void ChangeDirection(Vector2 direction)
    {
        _rigidbody2D.velocity = direction * _speed;
    }
    
    public void ChangeTargetMask(LayerMask targetMask)
    {
        _targetMask = targetMask;
    }
    
    public void ChangeDamage(float newDamage)
    {
        _damage = newDamage;
    }
    
    private IEnumerator LiveBullet()
    {
        yield return new WaitForSeconds(_timeLive);
        Die?.Invoke(this);
    }
}
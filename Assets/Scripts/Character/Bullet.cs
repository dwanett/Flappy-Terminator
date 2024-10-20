using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Vector2 direction;

    public void ChangeDirection(Vector2 newDirection)
    {
        direction = newDirection;
    }
}
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : CharacterMover
{
    [SerializeField] private float _forceJump;
    [SerializeField] private float _maxRotationZ;
    [SerializeField] private float _minRotationZ;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private Rigidbody2D _rigidbody;
    
    private Quaternion _maxRotation;
    private Quaternion _minRotation;

    private void Start()
    {
        _maxRotation = Quaternion.Euler(0, 0, _maxRotationZ);
        _minRotation = Quaternion.Euler(0, 0, _minRotationZ);
    }

    private void OnEnable()
    {
        _playerInput.JumpEvent += Jump;
    }

    private void OnDisable()
    {
        _playerInput.JumpEvent -= Jump;
    }

    private void Update()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, _minRotation, _rotationSpeed * Time.deltaTime);
    }

    private void Jump()
    {
        _rigidbody.velocity = new Vector2(_speed, _forceJump);
        transform.rotation = _maxRotation;
    }
}

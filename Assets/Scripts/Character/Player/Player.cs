using UnityEngine;

public class Player : Character
{
    [SerializeField] private GameArea _gameArea;
    [SerializeField] private Ground _ground;
    [SerializeField] private PlayerInput _playerInput;

    private void OnEnable()
    {
        _gameArea.playerExitGameArea += ToDie;
        _ground.playerTouchGround += ToDie;
        _playerInput.ShootEvent += UseSkill;
    }

    private void OnDisable()
    {
        _gameArea.playerExitGameArea -= ToDie;
        _ground.playerTouchGround -= ToDie;
        _playerInput.ShootEvent -= UseSkill;
    }

    private void UseSkill()
    {
        Skill.TryUse();
    }
}

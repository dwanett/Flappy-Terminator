using UnityEngine;

public class Player : Character
{
    [SerializeField] private GameArea _gameArea;
    [SerializeField] private Ground _ground;

    private void OnEnable()
    {
        _gameArea.playerExitGameArea += ToDie;
        _ground.playerTouchGround += ToDie;
    }

    private void OnDisable()
    {
        _gameArea.playerExitGameArea -= ToDie;
        _ground.playerTouchGround -= ToDie;
    }
}

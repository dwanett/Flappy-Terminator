using System;
using UnityEngine;
using Random = System.Random;

public class EnemyMover : CharacterMover
{
    //[SerializeField] private Vision _vision;
    [SerializeField] private Enemy _enemy;

    private Transform _currentTargetMovePoint;
    
    private void Start()
    {
        _currentTargetMovePoint = GetNextPointMove();
    }
    
    private void Update()
    {
        if (Mathf.Approximately(transform.position.y, _currentTargetMovePoint.position.y))
        {
            _currentTargetMovePoint = GetNextPointMove();
        }
        
        transform.position = Vector2.MoveTowards(transform.position, _currentTargetMovePoint.position, _speed * Time.deltaTime);
    }

    private Transform GetNextPointMove()
    {
        return _enemy.PointsPatrollingWay[new Random().Next(_enemy.PointsPatrollingWay.Count)].transform;
    }
}

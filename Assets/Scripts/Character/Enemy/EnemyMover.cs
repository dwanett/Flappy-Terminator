using UnityEngine;

public class EnemyMover : CharacterMover
{
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

        transform.position = Vector2.MoveTowards(transform.position, _currentTargetMovePoint.position, Speed * Time.deltaTime);
    }

    private Transform GetNextPointMove()
    {
        return _enemy.PointsPatrollingWay[Random.Range(0, _enemy.PointsPatrollingWay.Count)].transform;
    }
}

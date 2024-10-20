using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnemy : MonoBehaviour
{
    [SerializeField] private Enemy _prefabEnemy;
    [SerializeField] private List<PatrollingWayPoint> pointsPatrollingWay;
    private bool _canSpawn = true;

    private Enemy _spawnedEnemy;
    
    private void Update()
    {
        if (_canSpawn)
        {
            Spawn();
        }
    }

    private void Spawn()
    {
        _spawnedEnemy = Instantiate(_prefabEnemy, transform);
        _spawnedEnemy.ReplacePatrollingWay(pointsPatrollingWay);
        _canSpawn = false;
        _spawnedEnemy.DieEvent += Despawn;
    }

    private void Despawn()
    {
        _spawnedEnemy.DieEvent -= Despawn;
        _canSpawn = !_canSpawn;
    }
}
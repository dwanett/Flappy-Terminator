using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnemy : MonoBehaviour
{
    [SerializeField] private Enemy _prefabEnemy;
    [SerializeField] private float _delayRespawn;
    [SerializeField] private int _countSpawn;
    [SerializeField] private List<PatrollingWayPoint> _pointsPatrollingWay;
    [SerializeField] private List<Transform> _pointsSpawn;
    private bool _canSpawn = true;

    private int _countDie = 0;
    
    public event Action<int> DieEnemy;
    
    private void Awake()
    {
        for (int i = 0; i < _countSpawn; i++)
        {
            Spawn();
        }
    }

    private void Update()
    {
        if (_canSpawn)
        {
            Spawn();
        }
    }

    private void Spawn()
    {
        Enemy spawnedEnemy = Instantiate(_prefabEnemy, _pointsSpawn[new System.Random().Next(_pointsSpawn.Count)]);
        spawnedEnemy.ReplacePatrollingWay(_pointsPatrollingWay);
        _canSpawn = false;
        spawnedEnemy.DieEvent += Despawn;
    }

    private void Despawn()
    {
        _countDie++;
        DieEnemy?.Invoke(_countDie);  
        StartCoroutine(DelayRespawn());
    }

    private IEnumerator DelayRespawn()
    {
        yield return new WaitForSeconds(_delayRespawn);
        _canSpawn = !_canSpawn;
    }
}
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
    
    private int _countActive = 0;
    private int _countDie = 0;
    private Coroutine _delay = null;
    
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
        if (_countActive < _countSpawn && _delay == null)
        {
            _delay = StartCoroutine(DelayRespawn());
        }
    }

    private void Spawn()
    {
        Enemy spawnedEnemy = Instantiate(_prefabEnemy, _pointsSpawn[new System.Random().Next(_pointsSpawn.Count)]);
        spawnedEnemy.ReplacePatrollingWay(_pointsPatrollingWay);
        _countActive++;
        spawnedEnemy.DieEvent += Despawn;
    }

    private void Despawn()
    {
        _countDie++;
        _countActive--;
        DieEnemy?.Invoke(_countDie);  
    }

    private IEnumerator DelayRespawn()
    {
        yield return new WaitForSeconds(_delayRespawn);
        _delay = null;
        Spawn();
    }
}
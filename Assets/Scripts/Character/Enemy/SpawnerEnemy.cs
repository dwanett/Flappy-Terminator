using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnemy : Spawner<Enemy>
{
    [SerializeField] private float _delayRespawn;
    [SerializeField] private List<Transform> _pointsSpawn;
    
    [field: SerializeField] public List<PatrollingWayPoint> PointsPatrollingWay { get; private set; }
    
    private int _countDie = 0;
    private WaitForSeconds _waitForSeconds;

    public event Action<int> DieEnemy;

    private void Start()
    {
        _waitForSeconds = new WaitForSeconds(_delayRespawn);
        InvokeRepeating(nameof(Spawn), 0, 0.01f);
    }

    protected override void ActionOnRelease(Enemy enemy)
    {
        _countDie++;
        DieEnemy?.Invoke(_countDie);
    }

    protected override void ActionOnGet(Enemy enemy)
    {
        StartCoroutine(DelayRespawn(enemy));
    }

    protected override Enemy Instantiate()
    {
        Enemy enemy = Instantiate(Prefab, _pointsSpawn[new System.Random().Next(_pointsSpawn.Count)]);
        enemy.ReplacePatrollingWay(PointsPatrollingWay);
        enemy.DieEvent += () => Pool.Release(enemy);
        return enemy;
    }

    private void Spawn()
    {
        if (Pool.CountActive < MaxSpawn)
            Pool.Get();
    }
    
    private IEnumerator DelayRespawn(Enemy enemy)
    {
        yield return _waitForSeconds;
        enemy.ToRevive();
    }
}
using UnityEngine;

public class Shoot : Skill
{
    [SerializeField] private SpawnerBullet _prefabSpawnerBullet;
    private SpawnerBullet _spawner;

    private void Start()
    {
        _spawner = Instantiate(_prefabSpawnerBullet);
    }
    
    public override bool TryUse()
    {
        bool isUsing = base.TryUse();

        if (isUsing)
        {
            Vector2 directionView = transform.localScale.x < 0f ? transform.right * -1: transform.right;
            _spawner.Spawn(directionView, transform.position, LayerMaskAttacked, Damage);
        }
        
        return isUsing;
    }
}
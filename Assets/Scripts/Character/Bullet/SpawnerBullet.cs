using UnityEngine;

public class SpawnerBullet : Spawner<Bullet>
{
    protected override void ActionOnRelease(Bullet bullet)
    {
        bullet.Die -= Despawn;
        bullet.gameObject.SetActive(false);
    }

    protected override void ActionOnGet(Bullet bullet)
    {
        bullet.Die += Despawn;
        bullet.gameObject.SetActive(true);
    }

    protected override Bullet Instantiate()
    {
        return Instantiate(Prefab);
    }

    private void Despawn(Bullet bullet)
    {
        Pool.Release(bullet);
    }
    
    public void Spawn(Vector3 directionView, Vector3 position, LayerMask layerMaskAttacked, float damage)
    {
        Bullet bullet = Pool.Get();
        bullet.transform.position = position;
        bullet.ChangeDirection(directionView);
        bullet.ChangeTargetMask(layerMaskAttacked);
        bullet.ChangeDamage(damage);
    }
}

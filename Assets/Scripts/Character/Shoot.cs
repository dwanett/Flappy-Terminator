using UnityEngine;

public class Shoot : Skill
{
    [SerializeField] private Bullet _prefabBullet;
    
    public override bool TryUse()
    {
        bool isUsing = base.TryUse();

        if (isUsing)
        {
            Vector2 directionView = transform.localScale.x < 0f ? Vector2.left : Vector2.right;
            Bullet bullet = Instantiate(_prefabBullet, transform.position, Quaternion.identity);
            bullet.ChangeDirection(directionView);
            bullet.ChangeTargetMask(LayerMaskAttacked);
            bullet.ChangeDamage(Damage);
        }
        
        return isUsing;
    }
}
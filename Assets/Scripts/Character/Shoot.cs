using UnityEngine;

public class Shoot : Skill
{
    [SerializeField] private Bullet _prefabBullet;
    
    public override bool TryUse()
    {
        bool isUsing = base.TryUse();
        
        Vector2 directionView = transform.localScale.x < 0f ? Vector2.left : Vector2.right;
        Instantiate(_prefabBullet, transform);
        
        
        //RaycastHit2D raycastHit2D = Physics2D.Raycast(transform.position, directionView,
        //    DistanceUsing, LayerMaskAttacked.value);
//
        //if (raycastHit2D && raycastHit2D.collider.TryGetComponent(out Character target))
        //{
        //    isUsing = IsDistanceReached(target) && base.TryUse();
        //    
        //    if (isUsing)
        //        target.TakeDamage(Damage);
        //}
        
        return isUsing;
    }
}
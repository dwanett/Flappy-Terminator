using UnityEngine;

public class Vision : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private LayerMask _layerMaskPlayer;
    
    private void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.left, Mathf.Infinity, _layerMaskPlayer);
        
        if (hit)
        {
            _enemy.Skill.TryUse();
        }
    }
}
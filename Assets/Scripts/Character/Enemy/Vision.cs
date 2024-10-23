using UnityEngine;

public class Vision : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private LayerMask _layerMaskPlayer;
    
    private void FixedUpdate()
    {
        if (Physics2D.Raycast(transform.position, Vector2.left, Mathf.Infinity, _layerMaskPlayer))
        {
            _enemy.Skill.TryUse();
        }
    }
}
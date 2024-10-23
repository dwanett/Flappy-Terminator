using UnityEngine;

[CreateAssetMenu (fileName = "EnemyInfo", menuName = "Enemy/EnemyInfo")]
public class EnemyInfo : ScriptableObject
{
    [field: SerializeField] public Health Health { get; private set; }
}
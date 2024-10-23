using System;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    [field: SerializeField] public Health Health {get; private set;}
    
    [field: SerializeField] public Skill Skill {get; private set;}
    
    public event Action DieEvent;
    
    public void TakeDamage(float damage)
    {
        Health.Heal(damage);
    
        if (Health.Value <= 0f)
            ToDie();
    }
    
    public void ToDie()
    {
        DieEvent?.Invoke();
        gameObject.SetActive(false);
    }
    
    public void ToRevive()
    {
        Health.UpToMaxValue();
        gameObject.SetActive(true);
    }
}

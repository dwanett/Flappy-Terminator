using System;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    [field: SerializeField] public Health Health {get; private set;}
    
    [field: SerializeField] public  Skill Skill {get; private set;}
    
    public event Action DieEvent;
    
    protected void ToDie()
    {
        DieEvent?.Invoke();
        gameObject.SetActive(false);
        Destroy(gameObject);
    }
    
    public void TakeDamage(float damage)
    {
        Health.TakeHealth(damage);

        if (Health.Value <= 0f)
            ToDie();
    }
}

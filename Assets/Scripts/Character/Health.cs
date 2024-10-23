using UnityEngine;

public class Health : MonoBehaviour
{
    [field: SerializeField, Range(0, 300f)] public float MaxValue { get; private set; }
    [field: SerializeField, Range(0, 300f)] public float Value { get; private set; }

    private void OnValidate()
    {
        if (Value > MaxValue)
            Value = MaxValue;
    }

    public void Heal(float health)
    {
        if (health <= 0f) 
            return;
        
        Value = Mathf.Clamp(Value - health, 0, Value);
    }

    public void UpToMaxValue()
    {
        Value = MaxValue;
    }
}
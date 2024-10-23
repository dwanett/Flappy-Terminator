using UnityEngine;
using UnityEngine.Pool;

public abstract class Spawner<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] protected T Prefab;
    [SerializeField] protected int MaxSpawn;
    
    protected ObjectPool<T> Pool { get; private set; }
    
    private void Awake()
    {
        Pool = new ObjectPool<T>(
            Instantiate,
            ActionOnGet, 
            ActionOnRelease, 
            Destroy, 
            false, 
            MaxSpawn, 
            MaxSpawn);
    }

    protected abstract void ActionOnRelease(T monoBehaviour);

    protected abstract void ActionOnGet(T monoBehaviour);
    
    protected abstract T Instantiate();
}
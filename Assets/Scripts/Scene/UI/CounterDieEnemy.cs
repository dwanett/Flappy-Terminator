using TMPro;
using UnityEngine;

public class CounterDieEnemy : MonoBehaviour
{
    [SerializeField] private SpawnerEnemy _spawnerEnemy;
    [SerializeField] private TextMeshProUGUI _counter;

    private void Start()
    {
        _counter.text = "0";
    }

    private void OnEnable()
    {
        _spawnerEnemy.DieEnemy += ChangeCountDie;
    }

    private void OnDisable()
    {
        _spawnerEnemy.DieEnemy -= ChangeCountDie;
    }

    private void ChangeCountDie(int newCount)
    {
        _counter.text = $"{newCount}";
    }
}

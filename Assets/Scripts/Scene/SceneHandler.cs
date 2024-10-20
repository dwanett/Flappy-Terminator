using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        _player.DieEvent += RestartScene;
    }

    private void OnDisable()
    {
        _player.DieEvent -= RestartScene;
    }

    private void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
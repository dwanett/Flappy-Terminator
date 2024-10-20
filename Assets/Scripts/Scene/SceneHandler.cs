using UnityEngine;

public class SceneHandler : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Menu _menu;

    private void OnEnable()
    {
        _player.DieEvent += EnabledMenu;
    }

    private void OnDisable()
    {
        _player.DieEvent -= EnabledMenu;
    }

    public void EnabledMenu()
    {
        Time.timeScale = 0f;
        _menu.gameObject.SetActive(true);
    }
}
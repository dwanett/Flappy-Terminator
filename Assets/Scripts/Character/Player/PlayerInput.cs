using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private const KeyCode Jump = KeyCode.Space;
    private const KeyCode Shoot = KeyCode.Mouse0;

    public event Action JumpEvent;
    public event Action ShootEvent;
    
    private void Update()
    {
        if (Input.GetKeyDown(Jump))
        {
            JumpEvent?.Invoke();
        }
        if (Input.GetKeyDown(Shoot))
        {
            ShootEvent?.Invoke();
        }
    }
}

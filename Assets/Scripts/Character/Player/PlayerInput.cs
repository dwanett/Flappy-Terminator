using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private const KeyCode Jump = KeyCode.Space;

    public event Action JumpEvent;
    
    private void Update()
    {
        if (Input.GetKeyDown(Jump))
        {
            JumpEvent?.Invoke();
        }
    }
}

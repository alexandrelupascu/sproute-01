using System;
using UnityEngine;
using UnityEngine.InputSystem;
using static InputSystem_Actions;

public class PlayerInput : MonoBehaviour, IPlayerActions
{
    public event Action<Vector2> Move;
    public event Action<bool> Sprint;

    public event Action<bool> Attack1;
    public event Action<bool> Attack2;
    

    InputSystem_Actions _input;

    // A way to access where the player facing (idk if it should stay in this script)
    public Vector2 Direction => _input != null ? _input.Player.Move.ReadValue<Vector2>() : Vector2.zero;

    void Awake()
    {
        _input = new InputSystem_Actions();
        _input.Player.SetCallbacks(this);
    }

    void OnEnable() => _input.Enable();
    void OnDisable() => _input.Disable();


    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.performed || context.canceled) 
            Move?.Invoke(context.ReadValue<Vector2>());
    }

    public void OnSprint(InputAction.CallbackContext context)
    {
        Sprint?.Invoke(context.ReadValueAsButton());
    }

    public void OnAttack1(InputAction.CallbackContext context)
    {
        Attack1?.Invoke(context.ReadValueAsButton());
    }

    public void OnAttack2(InputAction.CallbackContext context)
    {
        Attack2?.Invoke(context.ReadValueAsButton());
    }

    

    // Unused actions (subject to change)
    public void OnInteract(InputAction.CallbackContext context) { }
    public void OnLook(InputAction.CallbackContext context) { }
    public void OnNext(InputAction.CallbackContext context) { }
    public void OnPrevious(InputAction.CallbackContext context) { }

    
}

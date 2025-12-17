using System;
using UnityEngine;
using UnityEngine.InputSystem;
using static InputSystem_Actions;

public class PlayerInput : MonoBehaviour, IPlayerActions
{
    public event Action<Vector2> Move;
    public event Action<bool> Sprint;
    

    private InputSystem_Actions _input;

    //public Vector2 Direction => _input != null ? _input.Player.Move.ReadValue<Vector2>() : Vector2.zero;

    private void Awake()
    {
        _input = new InputSystem_Actions();
        _input.Player.SetCallbacks(this);
    }

    private void OnEnable()
    {
        _input.Enable();
    }

    private void OnDisable()
    {
        _input.Disable();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.performed || context.canceled)
            Move?.Invoke(context.ReadValue<Vector2>());
    }

    public void OnSprint(InputAction.CallbackContext context)
    {
        Sprint?.Invoke(context.ReadValueAsButton());
    }

    

    // Unused actions (subject to change)
    public void OnJump(InputAction.CallbackContext context) { }
    public void OnAttack(InputAction.CallbackContext context) { }
    public void OnCrouch(InputAction.CallbackContext context) { }
    public void OnInteract(InputAction.CallbackContext context) { }
    public void OnLook(InputAction.CallbackContext context) { }
    public void OnNext(InputAction.CallbackContext context) { }
    public void OnPrevious(InputAction.CallbackContext context) { }
}

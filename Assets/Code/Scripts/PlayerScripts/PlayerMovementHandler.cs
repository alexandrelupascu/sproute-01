using System;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// This script handles the player's movement based on input received from the PlayerInputHandler.
/// This script doesn't subscribe to input events directly, instead it relies on the PlayerHandler to forward the input events.
/// </summary>
public class PlayerMovementHandler : MonoBehaviour
{

    [SerializeField] private CharacterController _characterController;
    [SerializeField] private float _walkSpeed = 5f;
    [SerializeField] private float _sprintSpeed = 10f;


    private Vector2 _inputDirection;
    private bool _isSprinting = false;
    

    public void Awake()
    {
        if (_characterController == null)
            Debug.LogWarning("PlayerMovementHandler: _characterController is not assigned.", this);
    }

    // Update is called once per frame
    public void Update()
    {
        Vector3 moveDirection = new Vector3(_inputDirection.x, 0, _inputDirection.y);
        float speed = _isSprinting ? _sprintSpeed : _walkSpeed;
        moveDirection *= speed;
        _characterController.Move(moveDirection * Time.deltaTime);
    }

    // These methods get called by the PlayerHandler when input events are received
    public void OnMove(Vector2 direction)
    {
        _inputDirection = direction;
    }

    public void OnSprint(bool isSprinting)
    {
        _isSprinting = isSprinting;
    }
}

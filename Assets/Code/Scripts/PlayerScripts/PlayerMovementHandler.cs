using System;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// This script handles the player's movement based on input received from the PlayerInputHandler.
/// This script doesn't subscribe to input events directly, instead it relies on the PlayerHandler to forward the input events.
/// </summary>
public class PlayerMovementHandler : MonoBehaviour
{

    [SerializeField] CharacterController _characterController;
    [Tooltip("Units per second")] [SerializeField] float _walkSpeed = 5f;
    [Tooltip("Units per second")] [SerializeField] float _sprintSpeed = 10f;

    [Header("Stamina Settings")]
    [Tooltip("Percentage per second")] [SerializeField] float _staminaRecoveryRate = 1f;
    [Tooltip("Percentage per second")] [SerializeField] float _sprintStaminaCost = 1f;
    [Tooltip("Seconds")] [SerializeField] float _staminaRecoveryCooldown = 2f;

    
    Vector2 _inputDirection;
    bool _isSprinting = false;
    float _stamina = 100f;
    float _timeSinceLastSprint = 0f;
    bool _canMove = true;
    bool _canSprint = true;
    bool _canRecoverStamina = false;

    public float Stamina => _stamina; // Public getter
    

    public void Awake()
    {
        if (_characterController == null)
            Debug.LogWarning("PlayerMovementHandler: _characterController is not assigned.", this);
    }

    // Update is called once per frame
    public void Update()
    {
        Vector3 moveDirection = new Vector3(_inputDirection.x, 0, _inputDirection.y);
        float moveSpeed = 1f;

        if (_isSprinting && _canSprint && _canMove)
        {
            _timeSinceLastSprint = 0f;
            _stamina -= _sprintStaminaCost * Time.deltaTime;
            if (_stamina <= 0f)
            {
                _stamina = 0f;
                _canSprint = false;
            }
        }
        else
        {
            if (_stamina < 100f)
            {
                if (_timeSinceLastSprint >= _staminaRecoveryCooldown)
                {
                    _stamina += _staminaRecoveryRate * Time.deltaTime;
                    if (_stamina >= 100f)
                    {
                        _stamina = 100f;
                        _canSprint = true;
                    }
                }
                else
                {
                    _timeSinceLastSprint += Time.deltaTime;
                }
            }
        }

        moveSpeed = _isSprinting ? _sprintSpeed : _walkSpeed;
        moveDirection *= moveSpeed;
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

    public void EnableMoving()
    {
        _canMove = true;
    }

    public void DisableMoving()
    {
        _canMove = false;
    }
}

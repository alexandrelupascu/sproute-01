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
    float _maxStamina = 100f;
    float _timeSinceLastSprint = 0f;
    bool _canMove = true;
    bool _canSprint = true;
    bool _canRecoverStamina = true;

    public float Stamina => _stamina; // Public getter
    

    public void Awake()
    {
        if (_characterController == null)
            Debug.LogWarning("PlayerMovementHandler: _characterController is not assigned.", this);
    }

    // Update is called once per frame
    public void Update()
    {
        Vector3 movement = GetMovementVector(GetMovementSpeed());
        _characterController.Move(movement * Time.deltaTime);
        Debug.Log("Stamina: " + _stamina);
    }

    private float GetMovementSpeed()
    {
        float moveSpeed = _walkSpeed;
    

        if (_isSprinting && CanSprint())
        {
            moveSpeed = _sprintSpeed;
            _stamina -= _sprintStaminaCost * Time.deltaTime;
            _timeSinceLastSprint = 0f;
        }
        else if (_isSprinting && !CanSprint())
        {
            moveSpeed = _walkSpeed;
            _timeSinceLastSprint = 0f;
        }
        else
        {
            // Recover stamina after cooldown
            if (_stamina < _maxStamina && _canRecoverStamina)
            {
                _timeSinceLastSprint += Time.deltaTime;
                if (_timeSinceLastSprint >= _staminaRecoveryCooldown)
                {
                    _stamina += _staminaRecoveryRate * Time.deltaTime;
                    Mathf.Clamp(_stamina, 0f, _maxStamina);
                }
            }
            else
            {
                _timeSinceLastSprint = 0f; // Reset timer if stamina is full
            }
        }

        return moveSpeed;
    }

    private Vector3 GetMovementVector(float speed)
    {
        Vector3 moveDirection = Vector3.zero;
        if (_canMove)
        {
            moveDirection = new Vector3(_inputDirection.x, 0, _inputDirection.y);
        }
        return moveDirection *= speed;
    }

    private bool CanSprint()
    {
        if (!_canSprint)
            return false;

        if (_stamina <= 0f)
        {
            _stamina = 0f;
            return false;
        }
        return true;
    }


    public void SetCanMove(bool canMove)
    {
        _canMove = canMove;
    }

    public void SetStaminaRecovery(bool canRecoverStamina)
    {
        _canRecoverStamina = canRecoverStamina;
    }

    public void SetCanSprint(bool canSprint)
    {
        _canSprint = canSprint;
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

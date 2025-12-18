using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float _walkSpeed = 5f;
    [SerializeField] float _sprintSpeed = 10f;
    [Tooltip("Stamina per second")]
    [SerializeField] float _sprintCost = 10f;

    Vector2 _inputDirection;
    bool _isSprinting;
    bool _canMove = true;


    CharacterController _characterController;
    PlayerStamina _stamina;

    private void Awake()
    {
        _stamina = GetComponent<PlayerStamina>();
        _characterController = GetComponent<CharacterController>();

        if (_characterController == null)
            Debug.LogWarning("PlayerMovement: CharacterController missing", this);

        if (_stamina == null)
            Debug.LogWarning("PlayerMovement: PlayerStamina missing", this);
    }

    private void Update()
    {
        if (!_canMove) return;

        float speed = GetMoveSpeed();
        Vector3 movement = GetMoveVector(speed);

        _characterController.Move(movement * Time.deltaTime);
    }

    private float GetMoveSpeed()
    {
        if (_isSprinting && _stamina != null && _stamina.TryConsume(_sprintCost * Time.deltaTime))
        {
            return _sprintSpeed;
        }

        return _walkSpeed;
    }

    private Vector3 GetMoveVector(float speed)
    {
        Vector3 dir = new Vector3(_inputDirection.x, 0f, _inputDirection.y);
        dir = Vector3.ClampMagnitude(dir, 1f);
        return dir * speed;
    }

    // FSM hooks
    public void SetCanMove(bool value) => _canMove = value;


    // Input hooks
    public void OnMove(Vector2 direction) => _inputDirection = direction;
    public void OnSprint(bool value) => _isSprinting = value;
}

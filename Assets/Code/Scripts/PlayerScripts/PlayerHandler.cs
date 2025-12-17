using UnityEngine;


/// <summary>
/// This script will be used to handle communication between different Player components.
/// This script shouldn't be a singleton.
/// </summary>

public class PlayerHandler : MonoBehaviour
{
    private PlayerInput _input;
    private PlayerMovement _movement; 
    private PlayerCombat _combat;
    private PlayerAnimation _animation;
    private PlayerStamina _stamina;
    // private PlayerFSM _fsm;
    
    // Public read only references
    public PlayerInput Input => _input;
    public PlayerMovement Movement => _movement;
    public PlayerCombat Combat => _combat;
    public PlayerAnimation Animation => _animation;
    public PlayerStamina Stamina => _stamina;

    // Todo : include PlayerStamina reference
    
    // public PlayerFSM FSM => _fsm;

    void Awake()
    {
        _input = GetComponent<PlayerInput>();
        _movement = GetComponent<PlayerMovement>();
        _combat = GetComponent<PlayerCombat>();
        _animation = GetComponent<PlayerAnimation>();
        _stamina = GetComponent<PlayerStamina>();
        // _fsm = GetComponent<PlayerFSM>();

        if (_input == null)
            Debug.LogWarning("PlayerHandler: _input (PlayerInput) is not assigned.", this);
        if (_movement == null)
            Debug.LogWarning("PlayerHandler: _movement (PlayerMovement) is not assigned.", this);
        if (_combat == null)
            Debug.LogWarning("PlayerHandler: _combat (PlayerCombat) is not assigned.", this);
        if (_animation == null)
            Debug.LogWarning("PlayerHandler: _animation (PlayerAnimation) is not assigned.", this);
        if (_stamina == null)
            Debug.LogWarning("PlayerHandler: _stamina (PlayerStamina) is not assigned.", this);
        // if (_fsm == null)
        //    Debug.LogWarning("PlayerHandler: _fsm (PlayerFSM) is not assigned.", this);
    }

    void OnEnable()
    {
        // For now, movement directly subscribes to input events.
        // Will have to change this to handle states
        if (_input != null && _movement != null)
        {
            _input.Move += _movement.OnMove;
            _input.Sprint += _movement.OnSprint;
        }
    }

    void OnDisable()
    {
        if (_input != null && _movement != null)
        {
            _input.Move -= _movement.OnMove;
            _input.Sprint -= _movement.OnSprint;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
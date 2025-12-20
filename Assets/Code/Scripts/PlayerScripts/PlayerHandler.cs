using UnityEngine;


/// <summary>
/// This script is used to handle communication between different Player components.
/// This script shouldn't be a singleton.
/// </summary>

public class PlayerHandler : MonoBehaviour
{
    // Required components
    PlayerInput _input;
    PlayerMovement _movement; 
    PlayerCombat _combat;
    PlayerAnimation _animation;
    PlayerStamina _stamina;
    // PlayerFSM _fsm;
    
    // Public read only references
    public PlayerInput Input => _input;
    public PlayerMovement Movement => _movement;
    public PlayerCombat Combat => _combat;
    public PlayerAnimation Animation => _animation;
    public PlayerStamina Stamina => _stamina;
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
            Debug.LogWarning("PlayerHandler: PlayerInput missing", this);
        if (_movement == null)
            Debug.LogWarning("PlayerHandler: PlayerMovement missing", this);
        if (_combat == null)
            Debug.LogWarning("PlayerHandler: PlayerCombat missing", this);
        if (_animation == null)
            Debug.LogWarning("PlayerHandler: PlayerAnimation missing", this);
        if (_stamina == null)
            Debug.LogWarning("PlayerHandler: PlayerStamina missing", this);
        // if (_fsm == null)
        //    Debug.LogWarning("PlayerHandler: PlayerFSM missing", this);
    }

    void OnEnable()
    {
        // For now, movement directly subscribes to input events
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
using UnityEngine;


/// <summary>
/// This script will be used to handle communication between different Player components.
/// This script shouldn't be a singleton.
/// </summary>

public class PlayerHandler : MonoBehaviour
{

    [SerializeField] private PlayerMovementHandler _movement; 
    [SerializeField] private PlayerAnimationHandler _animation;
    [SerializeField] private PlayerInputHandler _input;
    [SerializeField] private PlayerFSM _fsm;
    
    // Public read only references
    public PlayerMovementHandler Movement => _movement;
    public PlayerAnimationHandler Animation => _animation;
    public PlayerInputHandler Input => _input;
    public PlayerFSM FSM => _fsm;

    void Awake()
    {
        if (_movement == null)
            Debug.LogWarning("PlayerHandler: _movement (PlayerMovementHandler) is not assigned.", this);
        if (_animation == null)
            Debug.LogWarning("PlayerHandler: _animation (PlayerAnimationHandler) is not assigned.", this);
        if (_input == null)
            Debug.LogWarning("PlayerHandler: _input (PlayerInputHandler) is not assigned.", this);
        if (_fsm == null)
            Debug.LogWarning("PlayerHandler: _fsm (PlayerFSM) is not assigned.", this);
    }

    void OnEnable()
    {
        // For now, movement directly subscribes to input events.
        // Will have to change this to handle states
        _input.Move += _movement.OnMove;
        _input.Sprint += _movement.OnSprint;
    }

    void OnDisable()
    {
        _input.Move -= _movement.OnMove;
        _input.Sprint -= _movement.OnSprint;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using UnityEngine;

/// <summary>
///     This script is used to handle communication between different Player components.
///     This script shouldn't be a singleton.
/// </summary>
public class PlayerHandler : MonoBehaviour
{
    //PlayerCombat _combat;

    // Required components

    // Public read only references
    public PlayerInput Input { get; private set; }

    public PlayerMovement Movement { get; private set; }

    //public PlayerCombat Combat => _combat;
    public CombatHandler Combat { get; private set; }

    public PlayerAnimation Animation { get; private set; }

    public PlayerStamina Stamina { get; private set; }

    public PlayerFSM FSM { get; private set; }

    void Awake()
    {
        Input = GetComponent<PlayerInput>();
        Movement = GetComponent<PlayerMovement>();
        //_combat = GetComponent<PlayerCombat>();
        Combat = GetComponent<CombatHandler>();
        Animation = GetComponent<PlayerAnimation>();
        Stamina = GetComponent<PlayerStamina>();
        FSM = GetComponent<PlayerFSM>();


        // do proper initialization
        if (Input == null)
            Debug.LogWarning("PlayerHandler: PlayerInput missing", this);
        if (Movement == null)
            Debug.LogWarning("PlayerHandler: PlayerMovement missing", this);
        if (Combat == null)
            Debug.LogWarning("PlayerHandler: PlayerCombat missing", this);
        if (Animation == null)
            Debug.LogWarning("PlayerHandler: PlayerAnimation missing", this);
        if (Stamina == null)
            Debug.LogWarning("PlayerHandler: PlayerStamina missing", this);

        if (FSM == null) Debug.LogWarning("PlayerHandler: PlayerFSM missing", this);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnEnable()
    {
        // For now, movement directly subscribes to input events
        // Will have to change this to handle states
        if (Input != null && Movement != null && Combat != null)
        {
            Input.Move += Movement.OnMove;
            Input.Sprint += Movement.OnSprint;

            Input.Attack1 += Combat.OnAttack;
        }
    }

    void OnDisable()
    {
        if (Input != null && Movement != null)
        {
            Input.Move -= Movement.OnMove;
            Input.Sprint -= Movement.OnSprint;

            Input.Attack1 -= Combat.OnAttack;
        }
    }
}
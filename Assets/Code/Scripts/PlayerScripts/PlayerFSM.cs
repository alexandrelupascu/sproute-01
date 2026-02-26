using UnityEngine;

/// <summary>
///     This script will handle the Player Finite State Machine (FSM).
///     For now, Movement and Animation states will be handled in PlayerHandler.
/// </summary>

public class PlayerFSM : MonoBehaviour
{
    State _current;

    // States as public fields so they're easy to reference
    public IdleState Idle;
    public MoveState Move;
    public SprintState Sprint;
    public AttackState Attack;

    public PlayerFSM(PlayerHandler player)
    {
        Idle = new IdleState(player);
        Move = new MoveState(player);
        Sprint = new SprintState(player);
        Attack = new AttackState(player);
    }

    public void Init() => ChangeState(Idle);

    public void Tick() => _current?.Tick();
    public void FixedTick() => _current?.FixedTick();

    public void ChangeState(State next)
    {
        _current?.Exit();
        _current = next;
        _current.Enter();
    }
}
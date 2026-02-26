using UnityEngine;

public abstract class State
{
    protected PlayerHandler Player; // maybe have a EntityHandler superclass?

    protected State(PlayerHandler player)
    {
        Player = player;
    }

    public virtual void Enter() { }
    public virtual void Tick() { }
    public virtual void FixedTick() { }
    public virtual void Exit() { }
}

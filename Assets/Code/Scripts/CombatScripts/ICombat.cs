// Collection of interfaces for combat related functionality


// Components such as HealthHandler or DestructibleObject should implement these interfaces.
using UnityEngine;

public interface IDamageable
{
    HealthData HealthData { get; } // still unsure about this being a SO
    void TakeDamage(int amount);
}


public interface IHealable
{
    void Heal(int amount);
}

public interface IKillable
{
    void Die();
}

// meh unsure about these
// Components that can initiate attacks should implement this interface (Projectile, Hitbox)
public interface IAttackSource
{
    WeaponEffectData[] Effects { get; }
}

// Components that can be attacked should implement this interface.
public interface IAttackTarget
{
    void ReceiveAttack(IAttackSource source);
}

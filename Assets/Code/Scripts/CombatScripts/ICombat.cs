// Collection of interfaces for combat related functionality


// Components such as HealthHandler or DestructibleObject should implement these interfaces.
public interface IDamageable
{
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


// Components that can initiate attacks should implement this interface (Projectile, Hitbox)
public interface IAttackSource
{
    int Damage { get; }
}

// Components that can be attacked should implement this interface.
public interface IAttackTarget
{
    void ReceiveAttack(IAttackSource source);
}

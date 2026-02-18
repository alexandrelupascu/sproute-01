public interface IDamageable : IAttackTarget
{
    // HealthData HealthData { get; } // still unsure about this being a SO
    
    void TakeDamage(float amount);
}
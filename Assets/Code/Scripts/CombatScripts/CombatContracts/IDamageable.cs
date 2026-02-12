public interface IDamageable
{
    HealthData HealthData { get; } // still unsure about this being a SO
    void TakeDamage(int amount);
}


using UnityEngine;

public class DamageEffectExecutor :  IAttackEffectExecutionStrategy
{
    float _damage;
    
    public DamageEffectExecutor(float damage)
    {
        _damage = damage;
    }
    
    public void Execute(GameObject target)
    {
        target.GetComponentInParent<IDamageable>()?.TakeDamage(_damage);
    }
}
using UnityEngine;

/// <summary>
///     Describes an attack effect (e.g., damage, fire, knockback, poison, etc.).
///     Attack effects can be combined to create complex attack behaviors.
/// </summary>
[CreateAssetMenu(fileName = "AttackEffectData", menuName = "Scriptable Objects/AttackEffectData")]
public class AttackEffectData : ScriptableObject
{
    
    // instead of defining attack effects as an enum, maybe use a IEffectStrategy class with concrete strategies defined,
    // or maybe keep enum, but only for inspector purposes, then return proper strategy based on EffectType selected
    
    // Effect type (e.g., Damage, Fire, Knockback, Poison, etc.)
    enum EffectType
    {
        Damage,
        Piercing,
        // Knockback,
    }

    [SerializeField] EffectType _effectType;

    // Effect parameters (customize based on effect type)
    [SerializeField] float _magnitude; // e.g., damage amount, knockback force

    IAttackEffectExecutionStrategy  _cachedStrategy;

    void OnEnable()
    {
        BuildStrategy();
    }

#if UNITY_EDITOR
    void OnValidate()
    {
        BuildStrategy();
    }
#endif

    void BuildStrategy()
    {
        switch (_effectType)
        {
            case EffectType.Damage:
                _cachedStrategy = new DamageEffectExecutor(_magnitude);
                break;

            case EffectType.Piercing:
                //_cachedStrategy = new PiercingEffectExecutor(_magnitude);
                break;
        }
    }

    public IAttackEffectExecutionStrategy GetStrategy()
    {
        return _cachedStrategy;
    }
}
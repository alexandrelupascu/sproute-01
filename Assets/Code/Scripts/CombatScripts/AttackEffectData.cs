using UnityEngine;

/// <summary>
///     Describes an attack effect (e.g., damage, fire, knockback, poison, etc.).
///     Attack effects can be combined to create complex attack behaviors.
/// </summary>
[CreateAssetMenu(fileName = "WeaponEffectData", menuName = "Scriptable Objects/WeaponEffectData")]
public class AttackEffectData : ScriptableObject
{
    // Effect type (e.g., Damage, Fire, Knockback, Poison, etc.)
    public enum EffectType
    {
        Damage,
        Movement
    }

    [SerializeField] EffectType _effectType;

    // Effect parameters (customize based on effect type)
    [SerializeField] float _magnitude; // e.g., damage amount, knockback force
    [SerializeField] float _duration; // e.g., duration of status effects like poison

    // Additional parameters can be added here based on the effect type
}
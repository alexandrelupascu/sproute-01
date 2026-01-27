using UnityEngine;

/// <summary>
/// Describes a weapon effect (e.g., damage, fire, knockback, poison, etc.). 
/// Weapon effects can be combined to create complex attack behaviors.
/// </summary>
[CreateAssetMenu(fileName = "WeaponEffectData", menuName = "Scriptable Objects/WeaponEffectData")]
public class WeaponEffectData : ScriptableObject
{
    // Effect type (e.g., Damage, Fire, Knockback, Poison, etc.)
    public enum EffectType
    {
        Damage,
        // More effect types can be added here.
    }

    [SerializeField] EffectType effectType;

    // Effect parameters (customize based on effect type)
    [SerializeField] float magnitude; // e.g., damage amount, knockback force
    [SerializeField] float duration;  // e.g., duration of status effects like poison

    // Additional parameters can be added here based on the effect type
}

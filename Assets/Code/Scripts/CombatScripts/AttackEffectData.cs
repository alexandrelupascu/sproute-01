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
    public enum EffectType
    {
        Damage,
        Movement
    }

    [SerializeField] EffectType _effectType;

    // Effect parameters (customize based on effect type)
    [SerializeField] float _magnitude; // e.g., damage amount, knockback force
    [SerializeField] float _duration; // e.g., duration of status effects like poison

    public float Magnitude => _magnitude;
    public float Duration => _duration;

    // Additional parameters can be added here based on the effect type
}
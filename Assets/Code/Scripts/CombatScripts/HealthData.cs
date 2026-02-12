using UnityEngine;

[CreateAssetMenu(fileName = "HealthData", menuName = "Scriptable Objects/HealthData")]
public class HealthData : ScriptableObject
{
    [SerializeField] int _maxHealth;
    public int MaxHealth => _maxHealth;
}
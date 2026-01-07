using UnityEngine;

[CreateAssetMenu(fileName = "HealthData", menuName = "Scriptable Objects/HealthData")]
public class HealthData : ScriptableObject
{
    [SerializeField] int maxHealth;

    public int MaxHealth => maxHealth;
}

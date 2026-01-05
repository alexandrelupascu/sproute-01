using System;
using UnityEngine;

/// <summary>
/// This shouldn't contain information about the attack details, just the weapon data like name, description, icon, etc.
/// </summary>
[CreateAssetMenu(fileName = "WeaponData", menuName = "Scriptable Objects/WeaponData")]
public class WeaponData : ScriptableObject
{
    String weaponName;

}

using System;
using UnityEngine;


// This shouldn't contain information about the attack details, just the weapon data like name, description, icon, etc.
[CreateAssetMenu(fileName = "WeaponData", menuName = "Scriptable Objects/WeaponData")]
public class WeaponData : ScriptableObject
{

    // Delivery type (e.g., Melee, Ranged, AreaOfEffect, etc.)
    public enum DeliveryType
    {
        Melee,
        Ranged,
        // More delivery types can be added here.
    }

    // fire rate? should this be in delivery data?
    // delevierybehaviour ref, 
    // list of wpneffectdata, 
    // prefab (projectile, hitbox), 
    // animation ref?/visuals
    
    [SerializeField] string weaponName;
    // [SerializeField] Sprite weaponIcon; // (will add when working on UI)
    [SerializeField] DeliveryType deliveryType;
    [SerializeField] GameObject attackPrefab;
    

}

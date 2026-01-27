using UnityEditor.Search;
using UnityEngine;

public class CombatHandler : MonoBehaviour
{

    [SerializeField] Weapon _equippedWeapon; // Serialized for testing purposes, will want to set this via code later

    // this might need to be changed to a weapon holding point
    // attack origin point would be moved to a weapon prefab or scriptable object
    [SerializeField] Transform _attackOriginPoint; // point from which attacks are initiated (e.g., projectile spawn point)

    void Awake()
    {
        // TODO : equip weapon based on saved player state

        if (_equippedWeapon == null)
        {
            Debug.LogError("No weapon equipped in CombatHandler.");
        }
        
        
        if (_attackOriginPoint == null)
        {
            Debug.LogError("No attack origin point assigned in CombatHandler. Defaulting to GameObject's transform.");
            _attackOriginPoint = this.transform; // default to the GameObject's transform
        }
    }

    void Update()
    {
        
    }
}

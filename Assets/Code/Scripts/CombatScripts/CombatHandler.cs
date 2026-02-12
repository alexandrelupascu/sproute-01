using UnityEngine;

public class CombatHandler : MonoBehaviour
{
    [SerializeField] Weapon _equippedWeapon; // Serialized for testing purposes, will want to set this via code later
    [SerializeField] Transform _holdingPoint;

    bool _isAttacking;

    

    void Awake()
    {
        // TODO : equip weapon based on saved player state

        if (_equippedWeapon == null) Debug.LogError("No weapon equipped in CombatHandler.");


        if (_holdingPoint == null)
        {
            Debug.LogError("No attack origin point assigned in CombatHandler. Defaulting to GameObject's transform.");
            _holdingPoint = transform; // default to the GameObject's transform
        }
    }

    void Update()
    {
        if (_isAttacking) _equippedWeapon.Attack();
    }

    public void ChangeWeapon(Weapon weapon)
    {
        _equippedWeapon = weapon;
    }


    // input hook (currently in PlayerHandler)
    public void OnAttack(bool value)
    {
        _isAttacking = value;
    }
}
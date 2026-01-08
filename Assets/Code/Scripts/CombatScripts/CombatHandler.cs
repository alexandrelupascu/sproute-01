using System;
using UnityEngine;

public class CombatHandler : MonoBehaviour
{
    [SerializeField] WeaponData _currentWeapon;
    [SerializeField]
    EffectExecutor _effectExecutor;
    void Awake()
    {
        if (_currentWeapon == null)
        {
            Debug.LogWarning("CombatHandler: No weapon assigned", this);
        }

        if (_effectExecutor == null)
        {
            _effectExecutor = new EffectExecutor();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SwitchWeapon(WeaponData newWeapon)
    {
        _currentWeapon = newWeapon;
    }


    public void ExecuteAttack(Vector3 origin)
    {
        switch (_currentWeapon.DeliveryType)
        {
            case WeaponDeliveryType.Melee:
                ExecuteMeleeAttack(origin, Vector3.zero);
                break;
            case WeaponDeliveryType.Ranged:
                ExecuteRangedAttack(origin, Vector3.zero);
                break;
            default:
                Debug.LogWarning("CombatHandler: Unknown delivery type");
                break;
        }
    }

    private void ExecuteRangedAttack(Vector3 origin, Vector3 target)
    {

    }

    private void ExecuteMeleeAttack(Vector3 origin, Vector3 target)
    {

    }
}

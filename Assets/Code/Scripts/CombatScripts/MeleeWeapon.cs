using UnityEngine;

public class MeleeWeapon : Weapon
{
    [SerializeField] private AttackHitbox _hitbox;

    public override void Attack()
    {
        _hitbox.EnableForSeconds(0.2f, Damage);
    }
}


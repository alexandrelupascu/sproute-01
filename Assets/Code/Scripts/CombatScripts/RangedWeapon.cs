using UnityEngine;

public class RangedWeapon : Weapon
{
    [SerializeField] private AttackProjectile _projectile;
    [SerializeField] private Transform _firePoint;

    public override void Attack()
    {
        Instantiate(_projectile, _firePoint.position, _firePoint.rotation).Initialize(Damage);
    }
}

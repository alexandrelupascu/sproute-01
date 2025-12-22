using System.Collections;
using UnityEngine;

public class CombatHandler : MonoBehaviour
{
    [SerializeField] private Weapon _weapon;

    private bool _canAttack = true;

    public void RequestAttack()
    {
        if (!_canAttack)
            return;

        _weapon.Attack();
        StartCoroutine(AttackCooldown());
    }

    // Cooldown coroutine
    private IEnumerator AttackCooldown()
    {
        _canAttack = false;
        yield return new WaitForSeconds(_weapon.Cooldown);
        _canAttack = true;
    }
}


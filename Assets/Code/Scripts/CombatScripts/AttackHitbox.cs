using UnityEngine;

public class AttackHitbox : MonoBehaviour
{
    private float _damage;

    public void EnableForSeconds(float duration, float damage)
    {
        _damage = damage;
        gameObject.SetActive(true);
        Invoke(nameof(Disable), duration);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out HealthHandler health))
        {
            health.TakeDamage(_damage);
        }
    }

    private void Disable()
    {
        gameObject.SetActive(false);
    }
}

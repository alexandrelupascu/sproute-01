using System;
using UnityEngine;

public class HealthHandler : MonoBehaviour
{

    // temporary ai generated slop
    public float MaxHealth = 100;
    private float _current;

    public event Action OnDeath;

    private void Awake()
    {
        _current = MaxHealth;
    }

    public void TakeDamage(float amount)
    {
        _current -= amount;

        if (_current <= 0)
            Die();
    }

    private void Die()
    {
        OnDeath?.Invoke();
        Destroy(gameObject);
    }
}

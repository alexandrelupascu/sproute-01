using UnityEngine;

public class Health : MonoBehaviour, IDamageable, IKillable, IHealable
{
    [SerializeField] float _health;
    
    
    public void TakeDamage(float amount)
    {
        _health -= amount;
        if (_health <= 0) Kill();
    }

    public void Kill()
    {
        gameObject.SetActive(false);
    }

    public void Heal(int amount)
    {
        _health += amount;
    }
}

using UnityEngine;

public class Attack : MonoBehaviour, IAttackSource
{
    Collider _hitboxCollider;
    [SerializeField] AttackEffectData[]  _effects;
    public AttackEffectData[] Effects => _effects;

    void Awake()
    {
        _hitboxCollider = GetComponent<Collider>();

        if (_hitboxCollider == null) Debug.LogError("No Collider component found on AttackHitbox GameObject.");
    }

    void OnTriggerEnter(Collider other)
    {
        IAttackTarget target = other.GetComponentInParent<IAttackTarget>();
        target?.ReceiveAttack(this);
        
    }

    
}
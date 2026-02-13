using UnityEngine;

public class Attack : MonoBehaviour
{
    Collider _hitboxCollider;
    [SerializeField] AttackEffectData[]  _effects;
    [SerializeField] float _lifeTime;
    [SerializeField] float _velocity;
    
    //public AttackEffectData[] Effects => _effects;

    void Awake()
    {
        _hitboxCollider = GetComponent<Collider>();

        if (_hitboxCollider == null) Debug.LogError("No Collider component found on AttackHitbox GameObject.");
    }

    void OnTriggerEnter(Collider other)
    {
        IAttackTarget target = other.GetComponentInParent<IAttackTarget>();
        
        if (target != null)
        {
            foreach (AttackEffectData effect in _effects)
            {
                
            }
        }
    }

    
}
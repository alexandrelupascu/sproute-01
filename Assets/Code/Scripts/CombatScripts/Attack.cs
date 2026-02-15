using UnityEngine;

[System.Serializable]
public struct AttackConfig
{
    public AttackEffectData[] effects;
    public float lifeTime;
    public float velocity;
    public Vector3 hitboxSize;
}

public class Attack : MonoBehaviour
{
    BoxCollider _hitboxCollider;
    AttackEffectData[] _effects;
    float _lifeTime;
    float _velocity;
    bool _hasHit = false;
    bool _initialized = false;

    public void Initialize(AttackConfig config, string attackLayer)
    {
        _effects = config.effects;
        _lifeTime = config.lifeTime;
        _velocity = config.velocity;

        _hitboxCollider = GetComponent<BoxCollider>();
        if (_hitboxCollider == null)
        {
            _hitboxCollider = gameObject.AddComponent<BoxCollider>();
        }

        _hitboxCollider.isTrigger = true;
        _hitboxCollider.center = Vector3.zero;
        _hitboxCollider.size = config.hitboxSize;

        // Set the attack's layer
        gameObject.layer = LayerMask.NameToLayer(attackLayer);

        Destroy(gameObject, _lifeTime);

        _initialized = true;
    }

    void Start()
    {
        if (!_initialized)
        {
            Debug.LogError("Attack was never initialized!");
        }
    }

    void Update()
    {
        transform.position += transform.forward * (_velocity * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log($"Attack hit: {other.gameObject.name} on layer: {LayerMask.LayerToName(other.gameObject.layer)}");
        
        if (_hasHit)
        {
            Debug.Log("Attack already hit something, ignoring");
            return;
        }

        IAttackTarget target = other.GetComponentInParent<IAttackTarget>();
    
        if (target != null)
        {
            Debug.Log($"Found IAttackTarget on: {(target as Component).gameObject.name}");
            
            _hasHit = true;
            
            foreach (AttackEffectData effect in _effects)
            {
                Debug.Log($"Executing effect: {effect.name}");
                effect.GetStrategy().Execute(other.gameObject);
            }
        }
        else
        {
            Debug.Log($"No IAttackTarget found on: {other.gameObject.name}");
        }
    }
}
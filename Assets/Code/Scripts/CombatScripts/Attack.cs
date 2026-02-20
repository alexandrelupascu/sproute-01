using System;
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
    [SerializeField] Material _debugMaterial;
    
    BoxCollider _hitboxCollider;
    MeshRenderer _meshRenderer;
    AttackEffectData[] _effects;
    float _lifeTime;
    float _velocity;
    bool _hasHit = false;
    bool _initialized = false;

    public void Initialize(AttackConfig config, string attackLayer)
    {
        _initialized = true;
        
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

        if (DebugManager.Instance.AttackHitboxes)
        {
            DebugBox debugBox = gameObject.AddComponent<DebugBox>();
            debugBox.Initialize(_hitboxCollider, _debugMaterial);
        }
        
        // Set the attack's layer
        gameObject.layer = LayerMask.NameToLayer(attackLayer);

        Destroy(gameObject, _lifeTime);
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
        if (_hasHit) return; // change this to use penetration

        IAttackTarget target = other.GetComponentInParent<IAttackTarget>();
        if (target != null)
        {
            _hasHit = true;
            
            foreach (AttackEffectData effect in _effects)
            {
                effect.GetStrategy().Execute(other.gameObject);
            }
        }
    }

    void OnEnable()
    {
        DebugManager.Instance.AttackHitboxesChanged += ToggleDebug;
        ToggleDebug(DebugManager.Instance.PlayerInfo); // sync immediately
    }

    void OnDisable()
    {
        DebugManager.Instance.AttackHitboxesChanged -= ToggleDebug;
    }


    void ToggleDebug(bool value)
    {
        
            
    }
    
    
}
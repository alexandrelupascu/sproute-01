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

[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(MeshRenderer))]
public class Attack : MonoBehaviour
{
    [SerializeField] private Material _debugMaterial;

    private BoxCollider _hitboxCollider;
    private MeshRenderer _meshRenderer;

    private AttackEffectData[] _effects;
    private float _lifeTime;
    private float _velocity;

    private bool _hasHit = false;
    private bool _initialized = false;

    // component setup
    void Awake()
    {
        _hitboxCollider = GetComponent<BoxCollider>();
        _meshRenderer = GetComponent<MeshRenderer>();

        // Optional: assign debug material automatically
        if (_debugMaterial != null)
            _meshRenderer.material = _debugMaterial;
    }

    
    public void Initialize(AttackConfig config, string attackLayer)
    {
        _initialized = true;

        _effects = config.effects;
        _lifeTime = config.lifeTime;
        _velocity = config.velocity;

        _hitboxCollider.isTrigger = true;
        _hitboxCollider.center = Vector3.zero;
        _hitboxCollider.size = config.hitboxSize;

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
        // this is a temp fix, it should be transform.forward
        transform.position += transform.right * (_velocity * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (_hasHit) return;

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

    // debug system
    void OnEnable()
    {
        if (DebugManager.HasInstance)
        {
            DebugManager.Instance.AttackHitboxesChanged += ToggleDebug;
            ToggleDebug(DebugManager.Instance.AttackHitboxes);
        }
    }

    void OnDisable()
    {
        if (DebugManager.HasInstance)
        {
            DebugManager.Instance.AttackHitboxesChanged -= ToggleDebug;
        }
    }

    void ToggleDebug(bool value)
    {
        _meshRenderer.enabled = value;
    }
}
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

    public void Initialize(AttackConfig config)
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
        IAttackTarget target = other.GetComponentInParent<IAttackTarget>();

        if (target != null)
        {
            Debug.Log("attack found collider");

            GameObject targetObject = (target as Component).gameObject;

            foreach (AttackEffectData effect in _effects)
            {
                effect.GetStrategy().Execute(targetObject);
            }
        }
    }
}
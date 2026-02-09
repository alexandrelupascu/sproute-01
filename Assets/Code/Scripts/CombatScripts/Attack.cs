using UnityEngine;

public class Attack : MonoBehaviour
{
    Collider _hitboxCollider;

    void Awake()
    {
        _hitboxCollider = GetComponent<Collider>();

        if (_hitboxCollider == null)
        {
            Debug.LogError("No Collider component found on AttackHitbox GameObject.");
        }
    }

    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

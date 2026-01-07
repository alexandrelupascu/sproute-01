using UnityEngine;

public class AttackHitbox : MonoBehaviour
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


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

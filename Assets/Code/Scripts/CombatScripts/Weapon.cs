using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] string _weaponName;
    [SerializeField] float _attacksPerSecond;
    [SerializeField] Attack _attackPrefab;
    [SerializeField] Transform _attackOriginPoint;
    [SerializeField] AttackConfig _attackConfig;

    float _lastAttack;
    string _attackLayer;

    void Awake()
    {
        if (_attackPrefab == null)
        {
            Debug.LogError("No attack prefab assigned to weapon: " + _weaponName);
        }
        
        if (_attackOriginPoint == null)
        {
            Debug.LogError($"Weapon {_weaponName} has no attack origin.");
        }
        
        // Auto-determine attack layer based on owner's layer
        string ownerLayer = LayerMask.LayerToName(gameObject.layer);
        
        if (ownerLayer == "Player")
        {
            _attackLayer = "PlayerAttack";
        }
        else if (ownerLayer == "Enemy")
        {
            _attackLayer = "EnemyAttack";
        }
        else
        {
            Debug.LogWarning($"Weapon on unknown layer: {ownerLayer}. Defaulting to PlayerAttack");
            _attackLayer = "PlayerAttack";
        }
        
        _lastAttack = -Mathf.Infinity;
    }

    public void Attack()
    {
        float cooldown = 1f / _attacksPerSecond;

        if (Time.time - _lastAttack >= cooldown)
        {
            Attack attackInstance = Instantiate(
                _attackPrefab, 
                _attackOriginPoint.position, 
                _attackOriginPoint.rotation);
        
            attackInstance.Initialize(_attackConfig, _attackLayer);
        
            _lastAttack = Time.time;
        }
    }
}
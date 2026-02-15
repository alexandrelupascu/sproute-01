using UnityEngine;

// To be attached to a weapon prefab
public class Weapon : MonoBehaviour
{
    [SerializeField] string _weaponName;
    [SerializeField] float _attacksPerSecond;
    [SerializeField] Attack _attackPrefab;
    [SerializeField] Transform _attackOriginPoint;
    [SerializeField] AttackConfig _attackConfig;

    float _lastAttack;

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
            
            attackInstance.Initialize(_attackConfig);
            
            _lastAttack = Time.time;
        }
    }
}
using UnityEngine;


// To be attached to a weapon prefab
public class Weapon : MonoBehaviour
{
    // SO for weapon stats?
    [SerializeField] string _weaponName;
    [SerializeField] float _attackRate;
    [SerializeField] Attack _attackPrefab; // could maybe be a list if a weapon has multiple attack types
    [SerializeField] Transform _attackOriginPoint; // point from which attacks are initiated (e.g., projectile spawn point)

    float _lastAttack;
    
    // read only 
    //public float AttackRate => _attackRate;

    void Awake()
    {
        if (_attackPrefab == null)
            Debug.LogError("No attack prefab assigned to weapon: " + _weaponName);
        
        _lastAttack =  Time.time;
    }


    public void Attack()
    {
        if (Time.time - _lastAttack < _attackRate)
        {
            // instantiate the attack prefab at the origin point's position and rotation
            Instantiate(_attackPrefab, _attackOriginPoint.position, _attackOriginPoint.rotation);
            _lastAttack = Time.time;
        }
        else
        {
            // should there be any logic here?
        }
        
    }
}
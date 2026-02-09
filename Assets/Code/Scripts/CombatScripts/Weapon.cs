using UnityEngine;




// To be attached to a weapon prefab
public class Weapon : MonoBehaviour
{

    [SerializeField] string weaponName;
    [SerializeField] Attack _attackPrefab; // could maybe be a list if a weapon has multiple attack types


    public void Attack(Transform originPoint)
    {
        if (_attackPrefab != null)
        {
            // Instantiate the attack prefab at the origin point's position and rotation
            Instantiate(_attackPrefab, originPoint.position, originPoint.rotation);
        
        }
        else
        {
            Debug.LogError("No attack prefab assigned to weapon: " + weaponName);
        }
    }
}

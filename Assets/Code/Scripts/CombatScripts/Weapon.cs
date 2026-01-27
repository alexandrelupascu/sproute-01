using UnityEngine;




// To be attached to a weapon prefab
public class Weapon : MonoBehaviour
{

    [SerializeField] string weaponName;
    [SerializeField] DeliveryType _deliveryType;
    [SerializeField] Attack _attackPrefab; // could maybe be a list if a weapon has multiple attack types


    void Start()
    {
        
    }


    void Update()
    {
        
    }

    public enum DeliveryType
    {
        Melee,
        Ranged,
        // More delivery types can be added here.
    }
}

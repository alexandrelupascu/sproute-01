using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public float Damage;
    public float Cooldown;

    public abstract void Attack();
}


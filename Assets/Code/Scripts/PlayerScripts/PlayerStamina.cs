using UnityEngine;

// possibly generalize this for all game objects implementing stamina logic 
public class PlayerStamina : MonoBehaviour // I think this should be a plain c# class
{
    [SerializeField] float _maxStamina = 100f; // This should stay 100 as it's used in percentages

    [Tooltip("Stamina percentage recovered per second")] [SerializeField]
    float _recoveryRate = 10f;

    [Tooltip("Time in seconds before stamina starts recovering")] [SerializeField]
    float _recoveryCooldown = 2f;

    // should this be handled in FSM?
    bool _canRecover = true;

    float _timeSinceLastUse;

    // Public read only references
    public float Stamina { get; private set; }

    void Awake()
    {
        Stamina = _maxStamina;
    }

    void Update()
    {
        Recover();
        //Debug.Log($"Stamina: {Stamina}/{_maxStamina}");
    }

    public bool HasStamina(float cost)
    {
        return Stamina >= cost;
        // Can be used to check if enough stamina is available
    }

    public bool TryConsume(float amount)
    {
        if (Stamina < amount)
            return false;

        Stamina -= amount;
        _timeSinceLastUse = 0f;
        return true;
    }

    void Recover()
    {
        if (!_canRecover || Stamina >= _maxStamina) return;

        _timeSinceLastUse += Time.deltaTime;

        if (_timeSinceLastUse >= _recoveryCooldown)
            Stamina = Mathf.Clamp(Stamina + _recoveryRate * Time.deltaTime, 0f, _maxStamina);
    }

    // FSM hooks
    public void SetCanRecover(bool value)
    {
        _canRecover = value;
    }
}
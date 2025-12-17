using UnityEngine;

public class PlayerStaminaHandler : MonoBehaviour
{
    [SerializeField] float _maxStamina = 100f;
    [SerializeField] float _recoveryRate = 10f;
    [SerializeField] float _recoveryCooldown = 2f;

    float _stamina;
    float _timeSinceLastUse;
    bool _canRecover = true;

    public float Stamina => _stamina;
    public bool HasStamina(float cost) => _stamina >= cost;

    private void Awake()
    {
        _stamina = _maxStamina;
    }

    private void Update()
    {
        Recover();
    }

    public bool TryConsume(float amount)
    {
        if (_stamina < amount)
            return false;

        _stamina -= amount;
        _timeSinceLastUse = 0f;
        return true;
    }

    private void Recover()
    {
        if (!_canRecover || _stamina >= _maxStamina)
            return;

        _timeSinceLastUse += Time.deltaTime;

        if (_timeSinceLastUse >= _recoveryCooldown)
        {
            _stamina = Mathf.Clamp(
                _stamina + _recoveryRate * Time.deltaTime,
                0f,
                _maxStamina
            );
        }
    }

    public void SetCanRecover(bool value)
    {
        _canRecover = value;
    }
}

using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    PlayerHandler _playerHandler; // TEMPORARY!! REMOVE TO AVOID COUPLING!
    SpriteRenderer _spriteRenderer;

    void Awake()
    {
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        _playerHandler = GetComponent<PlayerHandler>();
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_playerHandler.Input.Direction.x > 0)
            _spriteRenderer.flipX = false;
        else if (_playerHandler.Input.Direction.x < 0)
            _spriteRenderer.flipX = true;
    }
}

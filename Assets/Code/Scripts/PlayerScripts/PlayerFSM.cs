using UnityEngine;

/// <summary>
///     This script will handle the Player Finite State Machine (FSM).
///     For now, Movement and Animation states will be handled in PlayerHandler.
/// </summary>
public class PlayerFSM : MonoBehaviour // maybe this should be a plain c# class
{
    // this reference allows access to all the players relevant components
    PlayerHandler _player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Init(PlayerHandler playerHandler)
    {
        _player = playerHandler;
    }
}
using UnityEngine;


// This script will reference other scripts handling major Player components.
// This shouldn't be a singleton.
public class PlayerHandler : MonoBehaviour
{

    [SerializeField] private PlayerMovementHandler _movement; 
    [SerializeField] private PlayerAnimationHandler _animation;
    [SerializeField] private PlayerInputHandler _input;
    
    
    // public read only references
    public PlayerMovementHandler Mouvement => _movement;
    public PlayerAnimationHandler Animation => _animation;
    public PlayerInputHandler Input => _input;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

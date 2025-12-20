using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class SpriteCameraFacing : MonoBehaviour
{
    [Header ("Experimental Settings (Will be applied to all instances of this script)")]
    [SerializeField] bool _lockRotation = false;
    [SerializeField] bool _lockHorizontalRotation = false;
    [SerializeField] bool _allowFullRotation = false;
    Camera _mainCamera;

    private void Awake()
    {
        // Find the main camera by tag without having to assign in the inspector
        GameObject camObj = GameObject.FindGameObjectWithTag("MainCamera");

        if (camObj == null)
        {
            Debug.LogError("SpriteCameraFacing: No GameObject with tag 'MainCamera' found.");
            enabled = false;
            return;
        }

        _mainCamera = camObj.GetComponent<Camera>();

        if (_mainCamera == null)
        {
            Debug.LogError("SpriteCameraFacing: GameObject tagged 'MainCamera' has no Camera component.");
            enabled = false;
        }
    }

    // LateUpdate is called after camera has moved
    private void LateUpdate()
    {
        // Make sure only one option is enabled at a time
        ExperimentalSettingsChecks();

        // Default behaviour
        if (!_allowFullRotation && !_lockHorizontalRotation && !_lockRotation)
        {
            transform.rotation = _mainCamera.transform.rotation;
        }
        else if (_lockRotation)
        {
            transform.rotation = Quaternion.identity;
        }
        else if (_lockHorizontalRotation)
        {
            // Vector3 camEuler = _mainCamera.transform.rotation.eulerAngles;
            // transform.rotation = Quaternion.Euler(0, camEuler.y, 0);

            transform.LookAt(new Vector3(_mainCamera.transform.position.x, transform.position.y, _mainCamera.transform.position.z));
            transform.Rotate(0, 180, 0); // To face the camera
        }
        else if (_allowFullRotation)
        {
            transform.LookAt(_mainCamera.transform);
            transform.Rotate(0, 180, 0); // To face the camera
        }
    }
    
    /// <summary>
    /// Checks experimental settings to ensure only one rotation option is enabled.
    /// </summary>
    void ExperimentalSettingsChecks()
    {
        if (_allowFullRotation && (_lockHorizontalRotation || _lockRotation)) 
        {
            Debug.LogWarning("SpriteCameraFacing: Only one of the rotation options can be enabled at a time.");
            _lockHorizontalRotation = false;
            _lockRotation = false;
        }
        if (_lockHorizontalRotation && (_allowFullRotation || _lockRotation)) 
        { 
            Debug.LogWarning("SpriteCameraFacing: Only one of the rotation options can be enabled at a time.");
            _lockRotation = false;
            _allowFullRotation = false;
        }
        if (_lockRotation && (_allowFullRotation || _lockHorizontalRotation)) 
        { 
            Debug.LogWarning("SpriteCameraFacing: Only one of the rotation options can be enabled at a time.");
            _allowFullRotation = false;
            _lockHorizontalRotation = false;
        }
    }
}

using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class SpriteCameraFacing : MonoBehaviour
{
    [Header ("Experimental Settings")]
    [SerializeField] bool _LockRotation = false;
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
        HandleExperimentalSettingsChecks();

        // Default behaviour
        if (!_allowFullRotation && !_lockHorizontalRotation && !_LockRotation)
        {
            transform.rotation = _mainCamera.transform.rotation;
        }
        else if (_LockRotation)
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

    void HandleExperimentalSettingsChecks()
    {
        if (_allowFullRotation) 
        {
            Debug.LogWarning("SpriteCameraFacing: Only one of the rotation options can be enabled at a time.");
            _lockHorizontalRotation = false;
            _LockRotation = false;
        }
        if (_lockHorizontalRotation) 
        { 
            Debug.LogWarning("SpriteCameraFacing: Only one of the rotation options can be enabled at a time.");
            _LockRotation = false;
            _allowFullRotation = false;
        }
        if (_LockRotation) 
        { 
            Debug.LogWarning("SpriteCameraFacing: Only one of the rotation options can be enabled at a time.");
            _allowFullRotation = false;
            _lockHorizontalRotation = false;
        }
    }
}

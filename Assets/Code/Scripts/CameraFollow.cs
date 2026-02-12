using System;
using UnityEngine;

/// <summary>
///     This script gets attached to the main camera and makes it follow a target game object from a set distance and
///     angle.
/// </summary>
public class CameraFollow : MonoBehaviour
{
    [Tooltip("The target GameObject for the camera to follow. If left empty, it will try to find the Player by tag.")]
    [SerializeField] GameObject _cameraTarget;

    [SerializeField] float _distanceFromTarget = 6.0f;
    [SerializeField] [Range(0, 90)] float _lookAngle = 30.0f;

    [Tooltip("Lower means snappier camera movement")] [SerializeField]
    float _positionSmoothTime = 0.3f;

    [Header("Experimental Settings")] [SerializeField]
    bool _isYUnlocked;

    [SerializeField] float _rotationSmoothTime = 0.3f;

    [Tooltip("Camera bounds.")] [SerializeField]
    float _zTopBound;

    [SerializeField] float _zBottomBound = -8f;
    Vector3 _positionOffset;
    Vector3 _velocity = Vector3.zero;

    // Public read only references
    public Transform TargetTransform { get; private set; }

    void Awake()
    {
        if (_cameraTarget == null)
        {
            _cameraTarget = GameObject.FindGameObjectWithTag("Player");
            Debug.LogWarning("CameraFollow: _cameraTarget not assigned, found Player by tag instead.", this);
        }

        TargetTransform = _cameraTarget.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckBounds();

        _positionOffset = CalculatePositionOffset();
        var currentPosition = transform.position - _positionOffset;

        // Follows the target and smooths the camera movement
        transform.position =
            Vector3.SmoothDamp(currentPosition, TargetTransform.position, ref _velocity, _positionSmoothTime) +
            _positionOffset;

        if (_isYUnlocked)
        {
            // Camera snaps to look at target
            // transform.LookAt(_targetTransform); 


            // Smoothly rotates the camera to look at the target
            var lookDirection = TargetTransform.position - transform.position;
            lookDirection.Normalize();

            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(lookDirection),
                _rotationSmoothTime * Time.deltaTime);
        }
        else
        {
            // Sets the camera at the right angle based on the lookAngle
            var rotation = Quaternion.Euler(_lookAngle, 0, 0);
            transform.SetLocalPositionAndRotation(transform.localPosition, rotation);
        }
    }

    void CheckBounds()
    {
        var pos = transform.position;
        pos.z = Mathf.Clamp(pos.z, _zBottomBound, _zTopBound);
        transform.position = pos;
    }

    Vector3 CalculatePositionOffset()
    {
        // soh cah toa :3
        var positionOffset = Vector3.zero;
        positionOffset.z = -(float)(Math.Cos(_lookAngle * (Math.PI / 180)) * _distanceFromTarget);
        positionOffset.y = (float)(Math.Sin(_lookAngle * (Math.PI / 180)) * _distanceFromTarget);

        return positionOffset;
    }
}
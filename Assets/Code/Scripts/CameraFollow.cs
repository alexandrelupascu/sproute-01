using System;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// This script gets attached to the main camera and makes it follow a target game object from a set distance and angle.
/// </summary>
public class CameraFollow : MonoBehaviour
{
    [Tooltip("The target GameObject for the camera to follow. If left empty, it will try to find the Player by tag.")]
    [SerializeField] GameObject _cameraTarget;
    [SerializeField] float _distanceFromTarget = 6.0f;
    [SerializeField][Range(0, 90)] float _lookAngle = 30.0f;
    [Tooltip("Lower means snappier camera movement")]
    [SerializeField] float _positionSmoothTime = 0.3f;
    Transform _targetTransform;
    Vector3 _positionOffset;
    Vector3 _velocity = Vector3.zero;

    [Header("Experimental Settings")]
    [SerializeField] bool _isYUnlocked = false;
    [SerializeField] float _rotationSmoothTime = 0.3f;

    // Public read only references
    public Transform TargetTransform => _targetTransform;

    void Awake()
    {
        if (_cameraTarget == null)
        {
            _cameraTarget = GameObject.FindGameObjectWithTag("Player");
            Debug.LogWarning("CameraFollow: _cameraTarget not assigned, found Player by tag instead.", this);
        }

        _targetTransform = _cameraTarget.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        _positionOffset = CalculatePositionOffset();
        Vector3 currentPosition = transform.position - _positionOffset;

        // Follows the target and smooths the camera movement
        transform.position = Vector3.SmoothDamp(currentPosition, _targetTransform.position, ref _velocity, _positionSmoothTime) + _positionOffset;

        if (_isYUnlocked)
        {
            // Camera snaps to look at target
            // transform.LookAt(_targetTransform); 


            // Smoothly rotates the camera to look at the target
            Vector3 lookDirection = _targetTransform.position - transform.position;
            lookDirection.Normalize();

            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(lookDirection), _rotationSmoothTime * Time.deltaTime);
        }
        else
        {
            // Sets the camera at the right angle based on the lookAngle
            Quaternion rotation = Quaternion.Euler(_lookAngle, 0, 0);
            transform.SetLocalPositionAndRotation(transform.localPosition, rotation);
        }

    }

    private Vector3 CalculatePositionOffset()
    {
        // soh cah toa :3
        Vector3 positionOffset = Vector3.zero;
        positionOffset.z = -(float)(Math.Cos(_lookAngle * (Math.PI / 180)) * _distanceFromTarget);
        positionOffset.y = (float)(Math.Sin(_lookAngle * (Math.PI / 180)) * _distanceFromTarget);

        return positionOffset;
    }
}

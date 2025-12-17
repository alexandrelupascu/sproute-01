using System;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// This script gets attached to the main camera and makes it follow a target game object from a set distance and angle.
/// </summary>
public class CameraFollow : MonoBehaviour
{
    [SerializeField] GameObject cameraTarget;
    [SerializeField] float distanceFromTarget = 8.0f;
    [SerializeField][Range(0, 90)] float lookAngle = 45.0f;

    Transform targetTransform;
    Vector3 positionOffset;
    [SerializeField] float smoothTime = 1.0f;
    Vector3 velocity = Vector3.zero;

    void Awake()
    {
        targetTransform = cameraTarget.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        positionOffset = CalculatePositionOffset();
        Vector3 currentPosition = transform.position - positionOffset;

        // Follows the target and smooths the camera movement
        transform.position = Vector3.SmoothDamp(currentPosition, targetTransform.position, ref velocity, smoothTime) + positionOffset;

        // Sets the camera at the right angle based on the lookAngle
        Quaternion rotation = Quaternion.Euler(90 - lookAngle, 0, 0);
        transform.SetLocalPositionAndRotation(transform.localPosition, rotation);
    }

    private Vector3 CalculatePositionOffset()
    {
        // I <3 Pythagoras
        Vector3 positionOffset = Vector3.zero;
        positionOffset.z = -(float)(Math.Sin(lookAngle * (Math.PI / 180)) * distanceFromTarget);
        positionOffset.y = (float)(Math.Cos(lookAngle * (Math.PI / 180)) * distanceFromTarget);

        return positionOffset;
    }
}

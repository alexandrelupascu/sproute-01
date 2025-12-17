using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class SpriteCameraFacing : MonoBehaviour
{
    private Camera mainCamera;

    private void Awake()
    {
        GameObject camObj = GameObject.FindGameObjectWithTag("MainCamera");

        if (camObj == null)
        {
            Debug.LogError("SpriteCameraFacing: No GameObject with tag 'MainCamera' found.");
            enabled = false;
            return;
        }

        mainCamera = camObj.GetComponent<Camera>();

        if (mainCamera == null)
        {
            Debug.LogError("SpriteCameraFacing: GameObject tagged 'MainCamera' has no Camera component.");
            enabled = false;
        }
    }

    // LateUpdate is called after camera has moved
    private void LateUpdate()
    {
        transform.rotation = mainCamera.transform.rotation;
    }
}

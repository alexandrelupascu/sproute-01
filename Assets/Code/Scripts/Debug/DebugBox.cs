using UnityEngine;


// this AI generated garbage is inefficient as fuck, but it'll stay for now

[RequireComponent(typeof(BoxCollider))]
public class DebugBox : MonoBehaviour
{
    GameObject _visual;

    public void Initialize(BoxCollider box, Material material)
    {
        // Create empty
        _visual = new GameObject("DebugBox_Visual");
        _visual.transform.SetParent(transform);
        _visual.transform.localPosition = box.center;
        _visual.transform.localRotation = Quaternion.identity;
        _visual.transform.localScale = box.size;

        // Add MeshFilter
        var filter = _visual.AddComponent<MeshFilter>();
        filter.mesh = GetCubeMesh();

        // Add MeshRenderer
        var renderer = _visual.AddComponent<MeshRenderer>();
        renderer.material = material;
    }

    void SetVisibility(bool visible)
    {
        if (_visual != null)
            _visual.SetActive(visible);
    }

    void OnEnable()
    {
        if (DebugManager.HasInstance)
        {
            DebugManager.Instance.AttackHitboxesChanged += SetVisibility;
            SetVisibility(DebugManager.Instance.AttackHitboxes);
        }
    }

    void OnDisable()
    {
        if (DebugManager.HasInstance)
        {
            DebugManager.Instance.AttackHitboxesChanged -= SetVisibility;
        }
            
    }

    // Reuse Unity's built-in cube mesh safely
    Mesh GetCubeMesh()
    {
        var temp = GameObject.CreatePrimitive(PrimitiveType.Cube);
        var mesh = temp.GetComponent<MeshFilter>().sharedMesh;
        Destroy(temp);
        return mesh;
    }
}
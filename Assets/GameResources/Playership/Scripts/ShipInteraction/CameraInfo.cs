using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraInfo : MonoBehaviour
{
    private Camera _camera;

    private void Awake()
    {
        _camera = GetComponent<Camera>();
    }

    public Vector3 ClampPositionInsideCameraFOV(Vector3 position)
    {
        Vector3 viewportPosition = _camera.WorldToViewportPoint(position);
        viewportPosition.Set(Mathf.Clamp01(viewportPosition.x), Mathf.Clamp01(viewportPosition.y), viewportPosition.z);
        viewportPosition = _camera.ViewportToWorldPoint(viewportPosition);
        return viewportPosition;
    }
}

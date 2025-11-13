using UnityEngine;

public class FollowCamera2D : MonoBehaviour
{
    [SerializeField] private Camera targetCamera;

    private float initialZ;

    private void Awake()
    {
        if (targetCamera == null) targetCamera = Camera.main;
        initialZ = transform.position.z; 
    }

    private void LateUpdate()
    {
        if (targetCamera == null) return;

        Vector3 camPos = targetCamera.transform.position;
        transform.position = new Vector3(camPos.x, camPos.y, initialZ);
    }
}
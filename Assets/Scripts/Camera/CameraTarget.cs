using UnityEngine;
using System.Collections;

public class CameraTarget : MonoBehaviour
{
    public GameObject target;
    public float heightOffsetY = 10,
                 heightOffsetZ = 5;
    public float cameraRotation = 45;
    private float height;
    void Start()
    {
        target = gameObject;
    }
}

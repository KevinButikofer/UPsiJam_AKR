using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{    
    [SerializeField]
    private Transform playerTransform;

    public float horizontalResolution = 1920;
    private Camera cam;
    private void Start()
    {
        cam = GetComponent<Camera>();
    }

    void OnGUI()
    {
        float currentAspect = (float)Screen.width / (float)Screen.height;
        //Camera.main.orthographicSize = horizontalResolution / currentAspect / 200;
    }

    // Update is called once per framea
    void LateUpdate()
    {
        transform.position = new Vector3(playerTransform.transform.position.x, transform.position.y, this.transform.position.z);
        cam.orthographicSize = Mathf.Clamp(cam.orthographicSize - Input.mouseScrollDelta.y * 2f, 5, 20);
    }
}

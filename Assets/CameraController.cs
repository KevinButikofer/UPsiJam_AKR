using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{    
    [SerializeField]
    private Transform playerTransform;

    public float horizontalResolution = 1920;

    void OnGUI()
    {
        float currentAspect = (float)Screen.width / (float)Screen.height;
        Camera.main.orthographicSize = horizontalResolution / currentAspect / 200;
    }

    // Update is called once per framea
    void FixedUpdate()
    {
        transform.position = new Vector3(playerTransform.transform.position.x, transform.position.y, this.transform.position.z);
    }
}

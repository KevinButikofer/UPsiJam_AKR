using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform playerTransform;

    // Update is called once per framea
    void FixedUpdate()
    {
        transform.position = new Vector3(playerTransform.transform.position.x, transform.position.y, this.transform.position.z);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersController : MonoBehaviour
{
    [SerializeField]
    private Transform playerMeanPoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 centroid = new Vector3(0, 0, 0);
        if (transform.childCount > 0)
        {
            foreach(Transform child in transform)
            {
                if(child.gameObject.CompareTag("Player"))
                    centroid += child.transform.position;
            }
            centroid /= transform.childCount;
        }
        playerMeanPoint.position = centroid;
    }
}

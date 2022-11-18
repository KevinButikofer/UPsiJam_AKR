using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddPlayerScript : MonoBehaviour
{
    private GameObject playerContainer;

    public GameObject playerFactory;

    // Start is called before the first frame update
    void Start()
    {
        playerContainer = GameObject.Find("Players");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "Player")
        {
            Instantiate(playerFactory, transform.position, Quaternion.identity, playerContainer.transform);
            Destroy(gameObject);
        }
    }
}

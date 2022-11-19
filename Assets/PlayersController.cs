using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersController : MonoBehaviour
{
    [SerializeField]
    private Transform playerMeanPoint;

    public Object startPlayer;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(startPlayer, GameObject.Find("Players").transform);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 centroid = new Vector3(0, 0, 0);
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        foreach(GameObject player in players)
        {
            centroid += player.transform.position;
            player.transform.GetComponent<PlayerController>().isFreezed = false;
        }
        if(players.Length > 0)
            centroid /= players.Length;
        playerMeanPoint.position = centroid;

        if (Input.GetMouseButton(0))
        {;
            Vector3 origin = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(origin, Vector3.forward, 10.0f);
            if (hit.collider != null)
            {
                if (hit.transform.CompareTag("Player"))
                {
                    hit.transform.GetComponent<PlayerController>().isFreezed = true;
                }
            }
        }
    }
}

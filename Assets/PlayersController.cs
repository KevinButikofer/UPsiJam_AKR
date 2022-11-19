using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersController : MonoBehaviour
{
    [SerializeField]
    private Transform playerMeanPoint;

    public Object startPlayer;

    private PlayerController currentFreeze;

    public LayerMask playerMask;

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
        }
        if(players.Length > 0)
            centroid /= players.Length;
        playerMeanPoint.position = centroid;


        if (Input.GetMouseButtonDown(0))
        {

            Vector3 origin = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(origin, Vector3.forward, 10.0f, playerMask);
            if (hit.collider != null)
            {
                Debug.Log(hit.transform.name);
                if (hit.transform.CompareTag("Player"))
                {
                    PlayerController newFreeze = hit.transform.GetComponent<PlayerController>();
                    if (currentFreeze == null)
                    {
                        newFreeze.isFreezed = true;
                        currentFreeze = newFreeze;
                    }
                    else if (currentFreeze == newFreeze)
                    {
                        newFreeze.isFreezed = false;
                        currentFreeze = null;
                    }
                    else if(currentFreeze != newFreeze)
                    {
                        currentFreeze.isFreezed = false;
                        newFreeze.isFreezed = true;
                        currentFreeze = newFreeze;
                    }
                }
            }

        }
    }
}

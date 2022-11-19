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
        Spawn();
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
    }

    void Spawn()
    {
        Instantiate(startPlayer, new Vector3(0,0,0), Quaternion.identity, transform);
    }
}

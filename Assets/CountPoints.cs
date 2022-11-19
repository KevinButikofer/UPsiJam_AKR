using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;


public class CountPoints : MonoBehaviour
{
    public LayerMask m_LayerMask;


    public TextMeshProUGUI textMesh;

    private bool hasTriggerEnd = false;


    void Start()
    {
    }

    void Update()
    {
        int points = UpdateUI();

        if(Input.GetKey(KeyCode.Q)) {
            //finish
            GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
            for(int i = 0; i < players.Length; i++) {
                Transform pi = players[i].transform;
                PlayerKillTrigger pikt = pi.GetComponent<PlayerKillTrigger>();
                pikt.Kill();
            }

            hasTriggerEnd = true;
        }

        if(hasTriggerEnd){
            GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
            if(players.Length <= 0)
                GameManager.NextScene();
        }
    }

    int UpdateUI() 
    {
        Collider2D[] hitColliders = Physics2D.OverlapBoxAll(transform.position, transform.localScale, 0, m_LayerMask);
        int points = 0;
        for (int i = 0; i < hitColliders.Length; i++)
        {
            Collider2D collider = hitColliders[i];
            PlayerController pc = collider.gameObject.GetComponent<PlayerController>();
            points += pc.score;
        }
        int totalPoints = points + GameManager.collected;
        textMesh.text = points + " + " + GameManager.collected + " = " + totalPoints + "\npoints";
        return totalPoints;
    }

}

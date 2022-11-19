using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class CountPoints : MonoBehaviour
{
    public LayerMask m_LayerMask;


    public TextMeshProUGUI textMesh;

    void Start()
    {
    }

    void Update()
    {
        UpdateUI();

        if(Input.GetKey(KeyCode.Q)) {
            //finish
        }
    }

    void UpdateUI() 
    {
        Collider2D[] hitColliders = Physics2D.OverlapBoxAll(transform.position, transform.localScale, 0, m_LayerMask);
        int points = 0;
        for (int i = 0; i < hitColliders.Length; i++)
        {
            Collider2D collider = hitColliders[i];
            PlayerController pc = collider.gameObject.GetComponent<PlayerController>();
            //TODO: Count the points
            // points += pc.points;
            points += 1;
        }
        int totalPoints = points + GameManager.collected;
        textMesh.text = points + " + " + GameManager.collected + " = " + totalPoints + "\npoints";
    }

}

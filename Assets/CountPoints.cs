using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class CountPoints : MonoBehaviour
{
    private LayerMask m_LayerMask;


    public TextMeshProUGUI textMesh;

    void Start()
    {
    }

    void Update()
    {
        Collider[] hitColliders = Physics.OverlapBox(gameObject.transform.position, transform.localScale / 2, Quaternion.identity, m_LayerMask);
        
        textMesh.text = hitColliders.Length + "\npoints";
        for (int i = 0; i < hitColliders.Length; i++)
        {
            //TODO: Count the points
        }
    }

}
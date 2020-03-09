using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerObeserve : MonoBehaviour
{
    public GameObject enemy;
    private TrailRenderer trail;
    public bool obeserve;
    
    void Start()
    {
        trail = enemy.GetComponent<TrailRenderer>();
        
    }

   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && obeserve)
        {
            trail.enabled = true;
        }
    }

}

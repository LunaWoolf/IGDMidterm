using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{

    private NavMeshAgent na;
    private GameObject[] points;
    public int cur;
    
    void Start()
    {
        na = this.GetComponent<NavMeshAgent>();
        points = GameObject.FindGameObjectsWithTag("movepoint");
        
    }

   
    void Update()
    {
        if (na.hasPath == false)
        {
            cur = Random.Range(0, points.Length);
            na.SetDestination(points[cur].transform.position);
             

        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{

    private NavMeshAgent na;
    private GameObject[] points;
    private int cur;
    public Vector3 ray;
    private MeshRenderer mr;
    public Material red;


    void Start()
    {
        na = this.GetComponent<NavMeshAgent>();
        points = GameObject.FindGameObjectsWithTag("movepoint");
        ray = this.transform.TransformDirection(Vector3.forward);
        mr = this.GetComponent<MeshRenderer>();
    }

   
    void Update()
    {
        if (na.hasPath == false)
        {
            cur = Random.Range(0, points.Length);
            na.SetDestination(points[cur].transform.position);
        }

        if (Physics.Raycast(transform.position, ray, 10))
        {
            mr.material = red;
        }
    }
}

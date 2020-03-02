using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{

    private NavMeshAgent na;
    private GameObject[] points;
    private int cur;
    public Vector3 target;
    private MeshRenderer mr;
    public Material red;
    Ray ray;


    void Start()
    {
        na = this.GetComponent<NavMeshAgent>();
        points = GameObject.FindGameObjectsWithTag("movepoint");
        mr = this.GetComponent<MeshRenderer>();
    }

   
    void Update()
    {
        target = this.transform.TransformDirection(Vector3.forward);
        ray = new Ray(transform.position, target);

        if (na.hasPath == false)
        {
            cur = Random.Range(0, points.Length);
            na.SetDestination(points[cur].transform.position);
        }

        RaycastHit hit;
        if (Physics.Raycast(transform.position, target, out hit, 10))
        {
            if (hit.collider.tag == "Player")
            {
                mr.material = red;
            }
        }
        Debug.DrawRay(ray.origin, ray.direction * 10, Color.blue);
    }
}

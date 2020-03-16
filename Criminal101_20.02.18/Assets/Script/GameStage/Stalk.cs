using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Stalk : MonoBehaviour
{

    private NavMeshAgent na;
    private GameObject[] points;
    private int cur;
    public Vector3 target;
    private MeshRenderer mr;
    public Material red;
    public UIcontroller uicontrol;
    public GameObject canvas;
    public GameController gc;
    public GameObject player;
    Ray ray;


    void Start()
    {
        na = this.GetComponent<NavMeshAgent>();
        points = GameObject.FindGameObjectsWithTag("movepoint");
        mr = this.GetComponent<MeshRenderer>();
        gc = GameObject.Find("Main Camera").GetComponent<GameController>();
        player = GameObject.Find("Player");
        uicontrol = canvas.GetComponent<UIcontroller>();
    }


    void Update()
    {
        target = this.transform.TransformDirection(Vector3.forward);
        ray = new Ray(transform.position, target);

        if (na.hasPath == false || na.velocity == Vector3.zero)
        {
            cur = Random.Range(0, points.Length);
            na.SetDestination(points[cur].transform.position);
        }

        RaycastHit hit;
        if (Physics.Raycast(transform.position, target, out hit, 10))
        {
            if (hit.collider.tag == "Player" && !player.GetComponent<PlayerMovement>().isHide)
            {
                gc.barPercent += 0.03f;
            }
        }
        Debug.DrawRay(ray.origin, ray.direction * 10, Color.green);
    }
}

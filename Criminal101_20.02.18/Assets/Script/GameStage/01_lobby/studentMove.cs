using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class studentMove : MonoBehaviour
{
    private NavMeshAgent na;
    private GameObject[] points;
    private int cur;
    public Vector3 target;
    public UIcontroller uicontrol;
    public GameController gc;
    public GameObject player;
    Ray ray;

    void Start()
    {
        na = this.GetComponent<NavMeshAgent>();
        points = GameObject.FindGameObjectsWithTag("movepoint");
        gc = GameObject.Find("Main Camera").GetComponent<GameController>();
        player = GameObject.Find("Player");
        uicontrol = GameObject.Find("Canvas").GetComponent<UIcontroller>();
    }


    void Update()
    {
        // at the same line as player
        this.transform.position = new Vector3(transform.position.x, transform.position.y, player.transform.position.z);

        target = this.transform.TransformDirection(Vector3.forward);
        ray = new Ray(transform.position, target);

        if (na.hasPath == false || na.velocity == Vector3.zero)
        {
            cur = Random.Range(0, points.Length);
            na.SetDestination(points[cur].transform.position);
        }

        RaycastHit hit;
        if (Physics.Raycast(transform.position, target, out hit, 10f))
        {
            if (hit.collider.tag == "Player" && !player.GetComponent<PlayerMovement>().isHide)
            {
                Debug.Log("hit");
                gc.barPercent = 0.03f;
            }
        }

        //Debug.DrawRay(ray.origin, ray.direction.normalized * 10f, Color.blue);


        if (transform.position.x > 66)
        {
            Destroy(this);
        }
    }
}

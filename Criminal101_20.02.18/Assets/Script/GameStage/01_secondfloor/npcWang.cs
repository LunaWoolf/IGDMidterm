using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class npcWang : MonoBehaviour
{
	UIcontroller uicontrol;
	GameController gc;
	GameObject player;
    WangStateMachine wsm;
	public NavMeshAgent na;
	public GameObject[] points;
	public int cur;
   

	public Vector3 target;

	public float speed = 10f;
    private Vector3 lastAgentVelocity;
    private NavMeshPath lastAgentPath;
    private Vector3 lastAgentDestination;
    public bool isPause = false;

    void Start()
    {
        gc = GameObject.Find("Main Camera").GetComponent<GameController>();
        player = GameObject.Find("Player");
        uicontrol = GameObject.Find("Canvas").GetComponent<UIcontroller>();
        wsm = this.GetComponent<WangStateMachine>();
        na = this.GetComponent<NavMeshAgent>();
        points = GameObject.FindGameObjectsWithTag("movepoint");
        cur = points.Length;
    }

   
    void Update()
    {
        if (isPause == false && na.hasPath == false && na.velocity == Vector3.zero )
        {
            cur -= 1;
            na.speed = speed; 
            na.SetDestination(points[cur].transform.position);
        }
    }

    public void pause()
    {
        isPause = true;
        lastAgentVelocity = na.velocity;
        lastAgentPath = na.path;
        lastAgentDestination = na.destination;
        na.velocity = Vector3.zero;
        na.ResetPath();
    }

    public void resume()
    {
        cur += 1;
        if (na.destination == lastAgentDestination)
        {
            na.SetPath(lastAgentPath);
        }
        else
        {
            na.SetDestination(lastAgentDestination);
        }

        na.velocity = lastAgentVelocity;

        isPause = false;
    }

}

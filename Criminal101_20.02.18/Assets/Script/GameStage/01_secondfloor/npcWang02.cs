using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class npcWang02 : MonoBehaviour
{
	UIcontroller uicontrol;
	GameController gc;
	GameObject player;
    WangStateMachine wsm;
	public NavMeshAgent na;
	public GameObject[] points;
	public int cur;
    public int state02limit;
    public int state03limit;
   

	public Vector3 target;

	public float speed;
    private Vector3 lastAgentVelocity;
    private NavMeshPath lastAgentPath;
    private Vector3 lastAgentDestination;
    public bool isPause = false;

    GameObject phone;
    bool isphone = false;
    Ray ray;

    void Start()
    {
        gc = GameObject.Find("Main Camera").GetComponent<GameController>();
        player = GameObject.Find("Player");
        uicontrol = GameObject.Find("Canvas").GetComponent<UIcontroller>();
        phone = GameObject.Find("Phone");
        wsm = this.GetComponent<WangStateMachine>();
        na = this.GetComponent<NavMeshAgent>();

    }

   
    void FixedUpdate()
    {
        if (wsm.state == "State02" && na.hasPath == false && na.velocity == Vector3.zero)
        {
            if (isPause)
                return;
            cur += 1;
            if (cur == state02limit + 1)
            {
                wsm.changeState(new State03(wsm));
                wsm.state = "State03";
                return;
            }
            na.speed = speed; 
            na.SetDestination(points[cur].transform.position);
        }
        if (!isphone && cur == 3)
        {
            isphone = true;
            Vector3 pos = new Vector3(-409.1f, -238.9f, -139.1f);
            phone.transform.position = pos;
        }
        if (isphone && cur == 5)
        {
            isphone = false;
            Destroy(phone);
        }

        if (wsm.state == "State03" && na.hasPath == false && na.velocity == Vector3.zero)
        {
            if (isPause)
                return;
            cur = Random.Range(state02limit + 1, state03limit + 1);
            na.speed = speed;
            na.SetDestination(points[cur].transform.position);
        }

        target = this.transform.TransformDirection(Vector3.forward);
        ray = new Ray(transform.position, target);
        RaycastHit hit;
        if (Physics.Raycast(transform.position, target, out hit, 100f))
        {
            if (hit.collider.tag == "Player" && !player.GetComponent<PlayerMovement>().isHide)
            {
                Debug.Log("hit");
                gc.barPercent += 0.05f;
            }
        }
        Debug.DrawRay(ray.origin, ray.direction.normalized * 100f, Color.red);
    }

    private void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            gc.barPercent += 0.001f;
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
        isPause = false;
        cur -= 1;
        if (na.destination == lastAgentDestination)
        {
            na.SetPath(lastAgentPath);
            na.speed = speed;
        }
        else
        {
            na.SetDestination(lastAgentDestination);
            na.speed = speed;
        }

        na.velocity = lastAgentVelocity;

        
    }

}

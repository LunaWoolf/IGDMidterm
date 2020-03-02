using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class observeTrigger : MonoBehaviour
{
    public GameObject player;
    public playerObeserve po;

    void Start()
    {
        po = player.GetComponent<playerObeserve>();
        
    }


    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            po.obeserve = true;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            po.obeserve = false;
        }
    }
}

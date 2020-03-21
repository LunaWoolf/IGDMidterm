using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WangStateMachine : MonoBehaviour
{
    public GameObject Wang;
    public npcWang wscript;
    private WangStates curState;
    public string state;

    void Start()
    {
        Wang = this.gameObject;
        wscript = Wang.GetComponent<npcWang>();
        wscript.enabled = false;
        changeState(new StartState(this));
        state = "StartState";
    }

   
    void Update()
    {
        curState.Run();
    }

    public void changeState(WangStates newState)
    {
        if (curState != null)
        {
            curState.Exit();
        }
        curState = newState;
        curState.Entry();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class State02 : WangStates
{ 
    GameObject Wang;


    public State02(WangStateMachine sm) : base(sm) { }


    public override void Entry()
    {
        Wang = wsm.Wang;
        wsm.wscript.enabled = true;
        Wang.GetComponent<NavMeshAgent>().enabled = true;

    }

    public override void Run()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            wsm.wscript.pause();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            wsm.wscript.resume();
        }
    }

    public override void Exit()
    {
        
    }
}

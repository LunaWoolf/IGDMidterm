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
        wsm.wscript02.enabled = true;
        Wang.GetComponent<NavMeshAgent>().enabled = true;

    }

    public override void Run()
    {
       
    }

    public override void Exit()
    {
        
    }
}

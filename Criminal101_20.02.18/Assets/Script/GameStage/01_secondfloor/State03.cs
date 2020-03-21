using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class State03 : WangStates
{
    GameObject Wang;
    public State03(WangStateMachine sm) : base(sm) { }


    public override void Entry()
    {
        Wang = wsm.Wang;
        Wang.GetComponent<NavMeshAgent>().enabled = true;

    }

    public override void Run()
    {
        
    }

    public override void Exit()
    {

    }
}

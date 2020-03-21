using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartState : WangStates
{

    GameObject Wang;

    public StartState(WangStateMachine sm) : base(sm) { }


    public override void Entry()
    {
        Wang = wsm.Wang;
        Wang.transform.localRotation = Quaternion.Euler(0, 180, 0);

    }

    public override void Run()
    {

    }

    public override void Exit()
    {

    }

}

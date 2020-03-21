using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WangStates
{
    

    protected WangStateMachine wsm;

    public abstract void Run();
    public virtual void Entry() { }
    public virtual void Exit() { }

    public WangStates(WangStateMachine sm)
    {
        wsm = sm;
    }
}

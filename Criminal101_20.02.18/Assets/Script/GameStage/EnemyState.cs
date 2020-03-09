using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyState
{
    protected EnemyStateMachine esm;

    public abstract void Run();
    public virtual void Entry() { }
    public virtual void Exit() { }


    public EnemyState(EnemyStateMachine esm)
    {
        esm = this.esm;
    }
}

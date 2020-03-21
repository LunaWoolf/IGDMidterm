using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WangStateMachine : MonoBehaviour
{
    public GameObject Wang;
    public npcWang02 wscript02;
    public npcWang03 wscript03;
    private WangStates curState;
    public string state;

    void Start()
    {
        Wang = this.gameObject;
        wscript02 = Wang.GetComponent<npcWang02>();
        wscript02.enabled = false;
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

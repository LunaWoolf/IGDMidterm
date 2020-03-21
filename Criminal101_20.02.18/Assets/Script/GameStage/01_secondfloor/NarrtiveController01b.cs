using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NarrtiveController01b : MonoBehaviour
{
    GameObject player;
    GameObject Wang;
    WangStateMachine wsm;
    GameController gc;
    GameObject instruction01;
    GameObject instruction02;
    GameObject instruction03;
    GameObject instruction04;
    bool Dia01 = true;
    bool Dia02 = false;
    bool Dia02wait = false;
    bool Dia03 = false;
    bool Dia04 = false;
    bool complete = false;

    void Start()
    {
        player = GameObject.Find("Player");
        gc = GameObject.Find("Main Camera").GetComponent<GameController>();
        Wang = GameObject.Find("Mr.Wang");
        wsm = Wang.GetComponent<WangStateMachine>();
        instruction01 = GameObject.Find("instruction01");
        instruction02 = GameObject.Find("instruction02");
        instruction03 = GameObject.Find("instruction03");
        instruction04 = GameObject.Find("instruction04");
    }

  
    void Update()
    {
        if (Dia01)
        {
            instruction01.GetComponent<DialogueTrigger>().TriggerDialogue();
            Dia01 = false;
        }

        if (!Dia01 && !Dia02 && !FindObjectOfType<DialogueManager>().open && wsm.state != "State02")
        {
            wsm.changeState(new State02(wsm));
            wsm.state = "State02";
            if(!Dia02wait)
                StartCoroutine(WaitDia02(1f));
        }

        if (Dia02)
        {
            Wang.GetComponent<npcWang>().pause();
            instruction02.GetComponent<DialogueTrigger>().TriggerDialogue();
            Dia02 = false;
            Dia03 = true;
        }

    }

    private IEnumerator WaitDia02(float waitTime)
    {
        Dia02wait = true;
        Debug.Log("wait");
        yield return new WaitForSeconds(waitTime);
        Dia02 = true;
       
    }

   
}

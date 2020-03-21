using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    bool Dia02over = false;
    bool Dia03 = false;
    bool Dia03over = false;
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

        if (!Dia01 && !Dia02 && !FindObjectOfType<DialogueManager>().open && wsm.state != "State02" && wsm.state != "State03")
        {
            Debug.Log("test01");
            wsm.changeState(new State02(wsm));
            wsm.state = "State02";
            if(!Dia02wait)
                StartCoroutine(WaitDia02(2f));
        }

        if (Dia02)
        {
            Wang.GetComponent<npcWang02>().pause();
            instruction02.GetComponent<DialogueTrigger>().TriggerDialogue();
            Dia02 = false;
            Dia02over = true;
        }

        if (Dia02over && !FindObjectOfType<DialogueManager>().open)
        {    
           Dia02over = false;
           Wang.GetComponent<npcWang02>().resume();
           Dia03 = true;
        }

        if (Dia03 && player.transform.position.z < GameObject.Find("limit01").transform.position.z )
        {
            instruction03.GetComponent<DialogueTrigger>().TriggerDialogue();
            Wang.GetComponent<npcWang02>().pause();
            Dia03 = false;
            Dia03over = true ;
        }

        if (Dia03over && !FindObjectOfType<DialogueManager>().open)
        {
            Dia03over = false;
            Wang.GetComponent<npcWang02>().resume();
            Dia04 = true;
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

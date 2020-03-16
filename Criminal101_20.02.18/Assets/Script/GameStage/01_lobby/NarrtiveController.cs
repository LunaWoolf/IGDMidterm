using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NarrtiveController : MonoBehaviour
{
    GameObject player; 
    GameObject instruction01;
    GameObject instruction02;
    GameObject instruction03;
    GameObject instruction04;
    GameObject npc;
    bool Dia01 = true;
    bool Dia02 = false;
    bool Dia03 = false;
    bool Dia04 = false;
    bool complete = false;

    public GameController gc;


    void Start()
    {
        player = GameObject.Find("Player");
        npc = GameObject.Find("npc_student");
        instruction01 = GameObject.Find("instruction01");
        instruction02 = GameObject.Find("instruction02");
        instruction03 = GameObject.Find("instruction03");
        instruction04 = GameObject.Find("instruction04");
        instruction02.SetActive(false);
        instruction03.SetActive(false);
        instruction04.SetActive(false);
        npc.SetActive(false);
        gc = GameObject.Find("Main Camera").GetComponent<GameController>();

        //instruction01.SetActive(true);

    }

    
    void Update()
    {
        if (Dia01)
        {
            instruction01.GetComponent<DialogueTrigger>().TriggerDialogue();
            Dia01 = false;
        }

        if (player.transform.position.x > -38 && !Dia02)
        {
            Dia02 = true;
            instruction02.SetActive(true);
            instruction02.GetComponent<DialogueTrigger>().TriggerDialogue();
            npc.SetActive(true);
            player.GetComponent<PlayerMovement>().moveable = false;
        }

        if (gc.barPercent > 0 && !Dia03)
        {
            Dia03 = true;
            instruction03.SetActive(true);
            instruction03.GetComponent<DialogueTrigger>().TriggerDialogue();
            Dia04 = true;
        }

        if (Dia04 && !FindObjectOfType<DialogueManager>().open)
        {
            Dia04 = false;
            player.GetComponent<PlayerMovement>().moveable = true;
            instruction04.SetActive(true);
            instruction04.GetComponent<DialogueTrigger>().TriggerDialogue();
            complete = true;
           
        }

        if (complete && player.transform.position.x > -16.9f)
        {
            SceneManager.LoadScene("demo01");
        }
        

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public bool question;
    public Dialogue dialogue;

    public void TriggerDialogue()
    {
        dialogue.hasquestion = question;
        FindObjectOfType<DialogueManager>().startDialogue(dialogue);
    }
}

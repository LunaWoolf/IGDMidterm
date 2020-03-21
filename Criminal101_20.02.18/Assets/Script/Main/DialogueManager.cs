using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Queue<string> sentences;
    public Text nameText;
    public Text diaText;
    public GameObject continuebutton;
    public Animator boxAnimator;
    public bool open;
    public GameObject choices;
    public Dialogue dialogue;
    //_______________________________________
    public Button switchscene;
    


    void Start()
    {
        choices = GameObject.Find("Choices");
        choices.SetActive(false);
        sentences = new Queue<string>();
        if (switchscene != null)
        {
            switchscene.enabled = false;
            switchscene.GetComponentInChildren<Text>().enabled = false;
            switchscene.image.enabled = false;
        }   
    }

    
   public void startDialogue(Dialogue dialogue)
   {
        nameText.enabled = true;
        diaText.enabled = true;
        continuebutton.SetActive(true);
        choices.SetActive(false);

        this.dialogue = dialogue;
        sentences = new Queue<string>();
        open = true;
        boxAnimator.SetBool("isOpen", true);
        nameText.text = dialogue.name;
        foreach(string sentence in dialogue.sentence)
        {
            sentences.Enqueue(sentence);
        }

        displayNextSentence();
   }

    public void displayNextSentence()
    {
        
        if(sentences.Count == 0)
        {
            endDialogue(dialogue);
            return;
        }

        string curSentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(curSentence));
        //diaText.text = curSentence;
    }

    IEnumerator TypeSentence(string sentence)
    {
        diaText.text = "";
        foreach (char letter in sentence)
        {
            diaText.text += letter;
            yield return null;
        }
    }

    public void endDialogue(Dialogue dialogue)
    {
        if (switchscene != null)
        {
            switchscene.enabled = true;
            switchscene.image.enabled = true;
            switchscene.GetComponentInChildren<Text>().enabled = true;
        }

        if (!dialogue.hasquestion)
        {
            boxAnimator.SetBool("isOpen", false);
            open = false;
        }

        if (dialogue.hasquestion)
        {
            loadquestion(dialogue);
        }
     
    }

    public void loadquestion(Dialogue dialogue)
    {
        nameText.enabled = false;
        diaText.enabled = false;
        continuebutton.SetActive(false);

        choices.SetActive(true);
        choices.transform.Find("Question").GetComponent<Text>().text = dialogue.question.que;
        choices.transform.Find("Choi01").GetComponentInChildren<Text>().text = dialogue.question.Choice[0].choice;
        if (dialogue.question.Choice.Length > 1)
            choices.transform.Find("Choi02").GetComponentInChildren<Text>().text = dialogue.question.Choice[1].choice;
        else
            choices.transform.Find("Choi02").gameObject.SetActive(false);


    }

    public void runNextDialogue(int num)
    {
        if (dialogue.question.Choice[num].nextDialogue != null)
            dialogue.question.Choice[num].nextDialogue.GetComponent<DialogueTrigger>().TriggerDialogue();
        else
        {
            boxAnimator.SetBool("isOpen", false);
            open = false;

        }

        

    }

}

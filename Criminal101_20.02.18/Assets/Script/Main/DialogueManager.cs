using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Queue<string> sentences;
    public Text nameText;
    public Text diaText;
    public Animator boxAnimator;
    public bool open;
    //_______________________________________
    public Button switchscene ;
   


    void Start()
    {
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
            endDialogue();
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

    public void endDialogue()
    {
        if (switchscene != null)
        {
            switchscene.enabled = true;
            switchscene.image.enabled = true;
            switchscene.GetComponentInChildren<Text>().enabled = true;
        }
        boxAnimator.SetBool("isOpen", false);
        open = false;

    }

}

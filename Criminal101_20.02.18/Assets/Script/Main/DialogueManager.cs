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


    void Start()
    {
        sentences = new Queue<string>();
    }

    
   public void startDialogue(Dialogue dialogue)
   {
        boxAnimator.SetBool("open", true);
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
        boxAnimator.SetBool("open", false);

    }

}

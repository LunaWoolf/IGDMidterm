using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Queue<string> sentences;
    public Text nameText;
    public Text diaText;


    void Start()
    {
        sentences = new Queue<string>();
    }

    
   public void startDialogue(Dialogue dialogue)
   {
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
        diaText.text = curSentence;
    }

    public void endDialogue()
    {
        

    }

}

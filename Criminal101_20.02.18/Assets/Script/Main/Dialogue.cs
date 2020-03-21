using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    public string name;
    public bool hasquestion;
    public Question question;

    [TextArea(3,10)]
    public string[] sentence;
   
}

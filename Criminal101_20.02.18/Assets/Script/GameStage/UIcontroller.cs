using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIcontroller : MonoBehaviour
{
    public Text instruct;
    public Trigger trigger;
    public GameObject tri;

    void Start()
    {
        trigger = tri.GetComponent<Trigger>();
    }

    // Update is called once per frame
    void Update()
    {
        /*if (trigger.hit == true)
        {
            instruct.text = "Got the key. Now go for the box" ;
        }*/
    }

    public void changeText(string str)
    {

        instruct.text = str;
    }
}

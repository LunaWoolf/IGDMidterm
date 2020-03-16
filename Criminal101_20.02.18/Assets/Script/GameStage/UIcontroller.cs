using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIcontroller : MonoBehaviour
{
    public Text instruct;
    public Trigger trigger;
    public GameObject tri;
    public int keyCount = 0;
    public GameController gc;

    void Start()
    {
        //trigger = tri.GetComponent<Trigger>();
        gc = GameObject.Find("Main Camera").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
      

        if (keyCount == 3)
        {
            changeText("You Found everything you need!");
        }
        if (gc.barPercent > 1f)
        {
            changeText("Sorry you lost");
        }

    }

    public void changeText(string str)
    {

        instruct.text = str;
    }
}

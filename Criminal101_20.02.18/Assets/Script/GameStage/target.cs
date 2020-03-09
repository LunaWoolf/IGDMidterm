using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class target : MonoBehaviour
{
    public Trigger trigger;
    public GameObject tri;
    public UIcontroller uicontrol;
    public GameObject canvas;

    void Start()
    {
        trigger = tri.GetComponent<Trigger>();
        uicontrol = canvas.GetComponent<UIcontroller>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision col)
    {
        if (trigger.hit == true)
        {
            uicontrol.changeText("you open the box");
        }
    }
}

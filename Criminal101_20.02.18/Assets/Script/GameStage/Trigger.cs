using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public bool hit = false;
    public UIcontroller uicontrol;
    public GameObject canvas;
    // Start is called before the first frame update
    void Start()
    {
        uicontrol = canvas.GetComponent<UIcontroller>();
    }
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision col)
    {
        hit = true;
        uicontrol.changeText("Got the key. Now go for the box");
    }
}

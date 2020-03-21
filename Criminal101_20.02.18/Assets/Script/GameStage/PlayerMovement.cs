using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rd;
    public float moveSpeed;
    public bool ableToHide = false;
    public bool isHide = false;
    public bool moveable = true;
    public GameObject body;
    public GameObject head;


    void Start()
    {
        rd = GetComponent<Rigidbody>();
    }

    void Update()
    { 

        if (ableToHide && Input.GetKey(KeyCode.H))
        {
            isHide = true;
            body.GetComponent<MeshRenderer>().enabled = false;
            head.GetComponent<MeshRenderer>().enabled = false;
            moveable = false;

        }

        if (isHide && Input.GetKeyDown(KeyCode.U))
        {
            isHide = false;
            body.GetComponent<MeshRenderer>().enabled = true;
            head.GetComponent<MeshRenderer>().enabled = true;
            moveable = true;
        }
    }

    void FixedUpdate()
    {

        if (moveable)
        {
            if (Input.GetKey(KeyCode.A))
            {
                transform.position += new Vector3(0, 0, moveSpeed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.W))
            {
                transform.position += new Vector3(moveSpeed * Time.deltaTime, 0, 0);
            }

            if (Input.GetKey(KeyCode.D))
            {
                transform.position += new Vector3(0, 0, -moveSpeed * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.S))
            {
                transform.position += new Vector3(-moveSpeed * Time.deltaTime, 0, 0);
            }
        }
   
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Hideable")
        {
            ableToHide = true;
        }
        
    }
    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Hideable")
        {
            ableToHide = false;
        }

    }
}

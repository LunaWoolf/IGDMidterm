using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rd;

    //public float forwardbackward;
    //public float rightLeft;
    public float moveSpeed;

    void Start()
    {
        rd = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //forwardbackward = Input.GetAxis("Horizontal");
        //rightLeft = Input.GetAxis("Vertical");
    }

    void FixedUpdate()
    {
        //rd.AddForce(transform.forward * -forwardbackward * 0.5f, ForceMode.Impulse);

        //rd.AddForce(Vector3.right * rightLeft, ForceMode.Impulse);

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
            transform.position += new Vector3(-moveSpeed * Time.deltaTime, 0 , 0);
        }
    }
}

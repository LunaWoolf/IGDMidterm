using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rd;

    public float forwardbackward;
    public float rightLeft;

    void Start()
    {
        rd = GetComponent<Rigidbody>();
    }

    void Update()
    {
        forwardbackward = Input.GetAxis("Horizontal");
        rightLeft = Input.GetAxis("Vertical");
    }

    void FixedUpdate()
    {
        rd.AddForce(transform.forward * -forwardbackward * 0.5f, ForceMode.Impulse);

        rd.AddForce(Vector3.right * rightLeft, ForceMode.Impulse);

        //rd.AddTorque(new Vector3(0, 1, 0) * rightLeft, ForceMode.Impulse);
    }
}

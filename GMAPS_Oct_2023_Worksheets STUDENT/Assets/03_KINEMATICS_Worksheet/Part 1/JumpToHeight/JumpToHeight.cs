using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpToHeight : MonoBehaviour
{
    public float Height = 1f;
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Jump()
    {
        // v*v = u*u + 2as
        // u*u = v*v - 2as
        // u = sqrt(v*v - 2as)      <- this one :)
        // v = 0, u = ?, a = Physics.gravity, s = Height

        float u = Mathf.Sqrt(-2 * Physics.gravity.y * Height);  //Used the formula (and also the code below)
        rb.velocity = new Vector3(0, u, 0); //Updates the new Y value to u

        //float jumpForce = Mathf.Sqrt(-2 * Physics2D.gravity.y * Height);
        //rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }
}


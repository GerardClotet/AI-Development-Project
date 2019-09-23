using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private RigidBody rb;
    void Start() //called in the first frame the  script is active
    {
        rb = GetComponent<RigidBody>();
    }
   //void Update() //called before rendering a FRAME
   // {
        
   // }

    void FixedUpdate() //called before performing any phisics calculation
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement);
    }
}

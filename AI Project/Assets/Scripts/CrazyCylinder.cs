using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CrazyCylinder : MonoBehaviour
{

    public float thrust;
    public Rigidbody rb;
    PlayerController pl;
    public GameObject go;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void FixedUpdate()
    {

        //  rb.AddForceAtPosition(transform.forward * thrust,new Vector3( 10, 5, 1));
        
      
        Vector3 direction = rb.transform.position - go.transform.position;
        rb.AddForce(-direction.normalized*10);
    }
}

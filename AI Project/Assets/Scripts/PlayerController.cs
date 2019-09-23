using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
    public float speed;
    public Text countText;
    public Text WinText;
    private Rigidbody rb;
    private int count;
    void Start() //called in the first frame the  script is active
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        WinText.text = "";
    }
   //void Update() //called before rendering a FRAME
   // {
        
   // }

    void FixedUpdate() //called before performing any phisics calculation
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement*speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false); //every time we touch a trigger coll deactivate the game obj
            count += 1;
            SetCountText();
        }
       // if(other.gameObject.CompareTag("Player")) //compares gameobject tag with a string
       // Destroy(other.gameObject); //deletes the gameobject form the scene
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 8)
            WinText.text = "you win!!";
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MoveToMouse : MonoBehaviour
{
    public LayerMask mask;
    public int mouse_button = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(mouse_button))
        {
            RaycastHit hit;
            Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(r, out hit, 10000.0f, mask) == true)
            {
                transform.position = hit.point;
            }
        }
    }
}

using UnityEngine;
using System.Collections;

public class KinematicFlee : MonoBehaviour {

	Move move;

	// Use this for initialization
	void Start () {
		move = GetComponent<Move>();
	}
	
	// Update is called once per frame
	void Update () 
	{
        // TODO 6: To create flee just switch the direction to go

        //Vector3 a = move.target.transform.position - this.transform.position;

        //move.SetMovementVelocity(-a.normalized);

        Vector3 a = move.target.transform.position - this.transform.position;
        Vector3 a2 = a.normalized * move.max_mov_velocity;
        move.SetMovementVelocity(-a2);
    }
}

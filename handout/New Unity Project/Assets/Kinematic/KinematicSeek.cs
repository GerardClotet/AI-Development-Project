using UnityEngine;
using System.Collections;

public class KinematicSeek : MonoBehaviour {

	Move move;
    public float velocity;
    public GameObject go;
	// Use this for initialization
	void Start () {
		move = GetComponent<Move>();
	}
	
	// Update is called once per frame
	void Update () 
	{
        // TODO 1: Set movement velocity to max speed in the direction of the target
        //   move.SetMovementVelocity(move.target.transform.position);

        Vector3 a = move.target.transform.position -this.transform.position;
        Vector3 a2 = a.normalized * move.max_mov_velocity;
        move.SetMovementVelocity(a2);



     //   move.mov_velocity = a;
        //move.mov_velocity = 
        // Remember to enable this component in the inspector
    }
}

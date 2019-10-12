using UnityEngine;
using System.Collections;

public class SteeringPursue : MonoBehaviour {

	public float max_seconds_prediction;

	Move move;
    SteeringSeek seek;
    SteeringArrive arrive;
    public GameObject enemy;
    Move Movenemy;

	// Use this for initialization
	void Start () {
		move = GetComponent<Move>();
        seek = GetComponent<SteeringSeek>();
        arrive = GetComponent<SteeringArrive>();
        Movenemy = enemy.GetComponent<Move>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		Steer(move.target.transform.position, move.target.GetComponent<Move>().movement, move.target.GetComponent<Move>().max_mov_speed);
	}

	public void Steer(Vector3 target, Vector3 target_velocity, float max_target_speed)
	{
        // TODO 5: Create a fake position to represent

        target = Movenemy.transform.position;

        Vector3 diff = move.target.transform.position - transform.position;
        diff.Normalize();
        diff *= move.max_mov_acceleration;
        move.AccelerateMovement(diff);






        // enemies predicted movement. Then call Steer()
        // on our Steering Seek / Arrive with the predicted position in
        // max_seconds_prediction time
        // Be sure that arrive / seek's update is not called at the same time

        // TODO 6: Improve the prediction based on the distance from
        // our target and the speed we have

        seek.Steer(target);
    }
}

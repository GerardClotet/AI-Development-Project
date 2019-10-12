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
      

        target = Movenemy.transform.position;

        Vector3 diff = target - transform.position;
        float distance = diff.magnitude;
        float seconds_prediction = distance / max_target_speed;
        Vector3 prediction = target + target_velocity * seconds_prediction;
        arrive.Steer(prediction);
    }
}

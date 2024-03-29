﻿using UnityEngine;
using System.Collections;

public class SteeringArrive : MonoBehaviour {

	public float min_distance = 10.0f;
	public float slow_distance = 5.0f;
	public float time_to_accel = 0.1f;

	Move move;

	// Use this for initialization
	void Start () { 
		move = GetComponent<Move>();
	}

	// Update is called once per frame
	void Update () 
	{
		    Steer(move.target.transform.position);
	}

	public void Steer(Vector3 target)
	{
		if(!move)
			move = GetComponent<Move>();

        // TODO 3: Find the acceleration to achieve the desired velocity
        // If we are close enough to the target just stop moving and do nothing else
        // Calculate the desired acceleration using the velocity we want to achieve and the one we already have
        // Use time_to_target as the time to transition from the current velocity to the desired velocity
        // Clamp the desired acceleration and call move.AccelerateMovement()


        Vector3 currentVel = move.movement;
        Vector3 desiredVel = move.max_mov_speed * (move.target.transform.position - move.transform.position);
        // Vector3 desiredVel = (move.max_mov_speed,0.0f,move.max_mov_speed);
        Vector3 Acceleration = (desiredVel - currentVel) / time_to_accel;
        // float timez = currentVel.magnitude / distancetoTravel.magnitude;

        if ((move.target.transform.position - move.transform.position).magnitude <= min_distance) 
        {
 
  
                move.SetMovementVelocity(Vector3.zero);

        }
        else
        {
            float clamped_acceleration = Mathf.Clamp(Acceleration.magnitude, 0.0f, move.max_mov_acceleration);
            move.AccelerateMovement(Acceleration * clamped_acceleration);
        }
      
        //TODO 4: Add a slow factor to reach the target
        // Start slowing down when we get closer to the target
        // Calculate a slow factor (0 to 1 multiplier to desired velocity)
        // Once inside the slow radius, the further we are from it, the slower we go


        if((move.target.transform.position - move.transform.position).magnitude <= slow_distance)
        {
            float slow_factor = (move.target.transform.position - move.transform.position).magnitude / slow_distance;

            move.SetMovementVelocity(move.movement * slow_factor);
        }
    }

	void OnDrawGizmosSelected() 
	{
		// Display the explosion radius when selected
		Gizmos.color = Color.white;
		Gizmos.DrawWireSphere(transform.position, min_distance);

		Gizmos.color = Color.green;
		Gizmos.DrawWireSphere(transform.position, slow_distance);
	}
}

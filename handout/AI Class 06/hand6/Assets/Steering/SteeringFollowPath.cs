using UnityEngine;
using System.Collections;
using BansheeGz.BGSpline.Components;
using BansheeGz.BGSpline.Curve;

public class SteeringFollowPath : MonoBehaviour {

	Move move;
	SteeringSeek seek;
    public float ratio_increment = 0.1f;
    public float min_distance = 1.0f;
    float current_ratio = 0.0f;
    Vector3 closest_point;
    public BGCcMath path;
	// Use this for initialization
	void Start () {
		move = GetComponent<Move>();
		seek = GetComponent<SteeringSeek>();

        // TODO 1: Calculate the closest point from the tank to the curve
        float distance;
        closest_point = path.CalcPositionByClosestPoint(move.transform.position,out distance);
        current_ratio = distance / path.GetDistance();
	}
	
	// Update is called once per frame
	void Update ()
    {
        move.target.transform.position = closest_point;
        // TODO 2: Check if the tank is close enough to the desired point
        // If so, create a new point further ahead in the path
        Vector3 position = closest_point - transform.position;

        if (position.magnitude < min_distance)
        {
            current_ratio += ratio_increment;
            if (current_ratio > 1.0f)
                current_ratio = 0.0f;

            closest_point = path.CalcPositionByDistanceRatio(current_ratio);
        }
        else
            seek.Steer(closest_point);

        
	}

	void OnDrawGizmosSelected() 
	{

		if(isActiveAndEnabled)
		{
			// Display the explosion radius when selected
			Gizmos.color = Color.green;
			// Useful if you draw a sphere were on the closest point to the path
		}

	}
}

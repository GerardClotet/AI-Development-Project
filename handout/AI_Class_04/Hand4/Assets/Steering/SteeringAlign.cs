using UnityEngine;
using System.Collections;

public class SteeringAlign : MonoBehaviour {

	public float min_angle = 0.01f;
	public float slow_angle = 0.1f;
	public float time_to_target = 0.1f;

	Move move;

	// Use this for initialization
	void Start () {
		move = GetComponent<Move>();
	}

	// Update is called once per frame
	void Update () 
	{
        // TODO 7: Very similar to arrive, but using angular velocities
        // Find the desired rotation and accelerate to it
        // Use Vector3.SignedAngle() to find the angle between two directions

        float desired_rot = Vector3.SignedAngle(Vector3.forward, move.movement, Vector3.up);
        float current_rot = move.transform.localRotation.eulerAngles.y;
        float final_rot = desired_rot - current_rot;

        //Delete additional loops
        final_rot %= 360;

        if (Mathf.Abs(final_rot) > 180)
        {
            float sign = Mathf.Sign(final_rot);
            final_rot = 360 - Mathf.Abs(final_rot);
            final_rot *= -sign;
        }

        if (final_rot < slow_angle)
        {
            final_rot /= slow_angle;
        }

        if (Mathf.Abs(final_rot) <= min_angle)
        {
            move.SetRotationVelocity(0f);
        }
        else
        {
            move.AccelerateRotation(final_rot);
        }
    }
}

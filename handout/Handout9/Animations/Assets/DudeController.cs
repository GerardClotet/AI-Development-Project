//Set up a new Boolean parameter in the Unity Animator and name it, in this case “Jump”.
//Set up transitions between each state that the animation could follow. For example, the player could be running or idle before they jump, so both would need transitions into the animation.
//If the “Jump” boolean is set to true at any point, the m_Animator plays the animation. However, if it is ever set to false, the animation would return to the appropriate state (“Idle”).
//This script enables and disables this boolean in this case by listening for the mouse click or a tap of the screen.

using UnityEngine;
using UnityEngine.AI;

public class DudeController : MonoBehaviour
{
    //Fetch the Animator
    NavMeshAgent agent;
    Animator m_Animator;
    // Use this for deciding if the GameObject can jump or not
    bool stop;
    Transform target;

    void Start()
    {
        //This gets the Animator, which should be attached to the GameObject you are intending to animate.
        m_Animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        // The GameObject cannot jump
        target = FindObjectOfType<MoveToMouse>().transform;
        stop = false;
    }

    void Update()
    {
        Vector3 trgpos = target.position;
        agent.SetDestination(trgpos);
        //Click the mouse or tap the screen to change the animation


        Vector3 anim_values = transform.InverseTransformDirection(agent.desiredVelocity);

        if(anim_values != Vector3.zero)
        {
            Debug.Log(anim_values);
            m_Animator.SetFloat("vel_x", anim_values.x);
            m_Animator.SetFloat("vel_y", anim_values.z);
            m_Animator.SetBool("movement", true);
        }
        else m_Animator.SetBool("movement", false);

        //if (Input.GetMouseButtonDown(0))
        //{
        //    stop = true;
        //    Debug.Log("pressed 1");

        //}
        ////Otherwise the GameObject cannot jump.
        //else if (Input.GetMouseButtonDown(1))
        //{
        //    stop = false;
        //    Debug.Log("pressed 1");
        //}
        ////If the GameObject is not jumping, send that the Boolean “Jump” is false to the Animator. The jump animation does not play.
        //if (stop == false)
        //    m_Animator.SetBool("movement", false);

        ////The GameObject is jumping, so send the Boolean as enabled to the Animator. The jump animation plays.
        //if (stop == true)
        //    m_Animator.SetBool("movement", true);
    }
}
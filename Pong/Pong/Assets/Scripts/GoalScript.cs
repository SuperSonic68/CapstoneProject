using UnityEngine;
using System.Collections;

public class GoalScript : MonoBehaviour {

    private bool goal;
    private int goalCamTicker;

    public GameObject Player_Paddle;
    public GameObject NPC_Paddle;

    public void Goal()
    {
        Debug.Break();

        Vector3 pos = transform.position;
        float x = transform.position.x;
        if (x > 20)
        {
            pos.x = 20;
        }
        else if (x < -20)
        {
            pos.x = -20;
        }

        transform.position = pos;
        goalCamTicker = 60;
        goal = true;

        GetComponent<BallScript>().Speed = 0f;

        GetComponent<SphereCollider>().enabled = false;

        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;

        Player_Paddle.GetComponent<PlayerMovementScript>().enabled = false;
        NPC_Paddle.GetComponent<NPC_Script>().enabled = false;

    }

    void FixedUpdate()
    {
        if(goal)
        {
            if (goalCamTicker < 0)
                goal = false;
            goalCamTicker--;

            if (!goal)
                GetComponent<BallResetScript>().Reset();
        }
    }
}

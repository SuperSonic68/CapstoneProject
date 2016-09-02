using UnityEngine;
using System.Collections;

public class GoalScript : MonoBehaviour {

    private bool goal;
    private float goalCamTicker;
	public Killcam killcam;

    public GameObject Player_Paddle;
    public GameObject NPC_Paddle;

    public void Goal()
    {
        //Debug.Break();

        Vector3 pos = transform.position;
        float x = transform.position.x;
        if (x > 20)
        {
            pos.x = 20;
			goalCamTicker = 1f;
        }
        else if (x < -20)
        {
            pos.x = -20;
			goalCamTicker = 8f;
        }

        transform.position = pos;
        
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
			goalCamTicker -= Time.deltaTime;

			if (!goal) {
				GetComponent<BallResetScript>().Reset();
				killcam.Deactivate ();
			}
                
        }
    }
}

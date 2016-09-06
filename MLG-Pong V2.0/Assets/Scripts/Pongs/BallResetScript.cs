using UnityEngine;
using System.Collections;

public class BallResetScript : MonoBehaviour
{
    public GameObject Player_Paddle;
    public GameObject NPC_Paddle;
	public float BallSpeed;


    public void Reset()
    {
        transform.position = new Vector3(0f, 0f, 0f);
        GetComponent<BallScript>().Speed = BallSpeed;
        GetComponent<ScoreScript>().Scored = false;
        GetComponent<SphereCollider>().enabled = true;
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;

		transform.rotation = Quaternion.Euler (0f, 90f, 0f);

        Player_Paddle.GetComponent<PlayerMovementScript>().enabled = true;
        NPC_Paddle.GetComponent<NPC_Script>().enabled = true;
    }
}

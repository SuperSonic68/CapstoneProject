using UnityEngine;
using System.Collections;

public class BallResetScript : MonoBehaviour
{
    public GameObject Player_Paddle;
    public GameObject NPC_Paddle;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Reset()
    {
        transform.position = new Vector3(0f, 0f, 0f);
        GetComponent<BallScript>().Speed = 5f;
        GetComponent<ScoreScript>().Scored = false;
        GetComponent<SphereCollider>().enabled = true;
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;

        Player_Paddle.GetComponent<Perfect_NPC_Script>().enabled = true;
        NPC_Paddle.GetComponent<NPC_Script>().enabled = true;
    }
}

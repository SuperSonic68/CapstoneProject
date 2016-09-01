using UnityEngine;
using System.Collections;

public class NPC_Script : MonoBehaviour
{

    public GameObject Target, Paddle;
    public float WallLimit, PaddleSize;



    public float Speed;

    // Use this for initialization
    void Start()
    {

        WallLimit = 4f;
        PaddleSize = 0.25f;

        Speed = 0.4f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float y = Target.transform.position.y - transform.position.y;
        float z = Target.transform.position.z - transform.position.z;

        Vector3 pos = transform.position;

        Vector3 mov = new Vector3(0f, y, z);
        if (mov.magnitude > Speed)
        {
            mov = mov.normalized * Speed;
        }

        pos = pos + mov;

        float x = pos.x;
        y = Mathf.Max(Mathf.Min(pos.y, WallLimit - PaddleSize), -WallLimit + PaddleSize);
        z = Mathf.Max(Mathf.Min(pos.z, WallLimit - PaddleSize), -WallLimit + PaddleSize);
        //-(mov.y - pos.y)
        //(mov.z - pos.z)
        Paddle.GetComponent<PaddleScript>().DeltaYZ(-(mov.y - pos.y), (mov.z - pos.z));

        transform.position = new Vector3(x,y,z);
    }
}

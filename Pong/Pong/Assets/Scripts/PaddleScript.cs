using UnityEngine;
using System.Collections;

public class PaddleScript : MonoBehaviour
{

    public float dy, dz;
    public GameObject Player;
    private Quaternion DefaultRotation;

    // Use this for initialization
    void Start()
    {
        dy = 0;
        dz = 0;

        DefaultRotation = Player.transform.localRotation;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.Log(dy + " " + dz);
        Quaternion lq = transform.localRotation;
        Quaternion tq = Quaternion.Euler(0f, dz, dy);

        transform.localRotation = lq * tq;

        transform.localRotation = Quaternion.Lerp(transform.localRotation, DefaultRotation, 0.3f);

    }

    public void DeltaYZ(float y, float z)
    {
        y *= -5;
        z *= 5;
        if(Mathf.Abs(y) > 0.0001)
            dy = y;
        else
            dy = 0;
        if(Mathf.Abs(z) > 0.0001)
            dz = z;
        else
            dz = 0;

        dy = Mathf.Clamp(y, -8, 8);
        dz = Mathf.Clamp(z, -8, 8);
        
    }


}
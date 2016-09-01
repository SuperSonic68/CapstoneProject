using UnityEngine;
using System.Collections;

public class BallScript : MonoBehaviour
{
    public float Speed;

    // Use this for initialization
    void Start()
    {
        Speed = 5f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        //Debug.Log(Speed);

        
        RaycastHit rch;
        bool hit = Physics.Raycast(transform.position, transform.forward, out rch);
        if (hit && rch.distance < 0.2f * Speed)
        {
            Speed+= 0.1f;
            //Vector3 a = Vector3.Dot(transform.forward.normalized, rch.normal) * 2 * transform.forward.normalized - rch.normal;
            //Debug.Log(a + " " + rch.normal);

            //transform.forward = ((2 * (Vector3.Dot(transform.forward.normalized, rch.normal))) * transform.forward.normalized) - rch.normal;

            //Debug.Log(transform.forward);
            //transform.forward = rch.normal;

            //Debug.Break();
            //transform.position = rch.point + transform.forward * (Speed - rch.distance) * 0.2f;
            //Debug.Break();

            Vector3 N = rch.normal;
            Vector3 L = transform.forward * -1;

            Debug.Log(N + " " + L + " " + (2 * Vector3.Dot(L, N) * N - L));

            transform.forward = (2 * Vector3.Dot(L, N) * N - L);
        }
        else
            transform.position = transform.position + transform.forward * 0.2f * Speed;
        
       // transform.position = transform.position + transform.forward * 0.2f * Speed;
    }

    void OnCollisionEnter(Collision other)
    {
        Speed += 0.1f;

        Vector3 N = other.contacts[0].normal;

        //N = (other.contacts[0].point - transform.position).normalized * -1;

        Vector3 L = transform.forward * -1;

        Debug.Log(N + " " + L + " " + (2 * Vector3.Dot(L, N) * N - L));

        transform.forward = (2 * Vector3.Dot(L, N) * N - L);

        //transform.forward = N;
    }
}

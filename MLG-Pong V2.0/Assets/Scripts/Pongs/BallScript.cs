using UnityEngine;
using System.Collections;

public class BallScript : MonoBehaviour
{
    public float Speed;
	public float SpeedTransferScalar; //Determines the amount of speed rewarded when you hit the ball with the paddle

   
    // Update is called once per frame
    void FixedUpdate()
    {
      
        RaycastHit RaycastHitPoint;
        bool hit = Physics.Raycast(transform.position, transform.forward, out RaycastHitPoint);
        if (hit && RaycastHitPoint.distance < Speed)
        {
            if (RaycastHitPoint.transform.gameObject.CompareTag("Paddle"))
            {
                float DeltaY = RaycastHitPoint.transform.gameObject.GetComponentInParent<PaddleScript>().DeltaY;
                float DeltaZ = RaycastHitPoint.transform.gameObject.GetComponentInParent<PaddleScript>().DeltaZ;
				Speed += (new Vector3(0f, DeltaY, DeltaZ)).magnitude * SpeedTransferScalar;
            }

         //Determines angle of bounce off of objects
            Vector3 HitNormal = RaycastHitPoint.normal;
            Vector3 BallDirInverse = transform.forward * -1;

			transform.forward = (2 * Vector3.Dot(BallDirInverse, HitNormal) * HitNormal - BallDirInverse);
        }
        else
            transform.position = transform.position + transform.forward * Speed;
        
    }

    void OnCollisionEnter(Collision other)
    {
       
        if (other.transform.gameObject.CompareTag("Paddle"))
        {
            float DeltaY = other.transform.gameObject.GetComponentInParent<PaddleScript>().DeltaY;
            float DeltaZ = other.transform.gameObject.GetComponentInParent<PaddleScript>().DeltaZ;
			Speed += (new Vector3(0f, DeltaY, DeltaZ)).magnitude * SpeedTransferScalar;
        }

		Vector3 HitNormal = other.contacts[0].normal;
		Vector3 BallDirInverse = transform.forward * -1;
		transform.forward = (2 * Vector3.Dot(BallDirInverse, HitNormal) * HitNormal - BallDirInverse);
    }
}

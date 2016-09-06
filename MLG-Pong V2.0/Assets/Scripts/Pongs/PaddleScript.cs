using UnityEngine;
using System.Collections;

public class PaddleScript : MonoBehaviour
{

    public float DeltaY, DeltaZ;
    public GameObject Player;
	public float PaddleTurnFactor;
	public float MotionScale;
    private Quaternion DefaultRotation;

    // Use this for initialization
    void Start()
    {
        DeltaY = 0;
        DeltaZ = 0;

        DefaultRotation = Player.transform.localRotation;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Handles Paddle rotation
        Quaternion LocalRot = transform.localRotation;
        Quaternion DeltaRot = Quaternion.Euler(0f, DeltaZ, DeltaY);

		transform.localRotation = LocalRot * DeltaRot;

		//Smoothly rotate back to default position
        transform.localRotation = Quaternion.Lerp(transform.localRotation, DefaultRotation, 0.3f);


    }

    public void DeltaYZ(float y, float z)
    {
		//Gets paddle movement and calculates Delta y and Delta z from it.

		y *= -MotionScale;
		z *= MotionScale;

		//Regulates miniscule values to keep physics in check
        if(Mathf.Abs(y) > 0.0001)
            DeltaY = y;
        else
            DeltaY = 0;
        if(Mathf.Abs(z) > 0.0001)
            DeltaZ = z;
        else
            DeltaZ = 0;

		DeltaY = Mathf.Clamp(y, -PaddleTurnFactor, PaddleTurnFactor);
		DeltaZ = Mathf.Clamp(z, -PaddleTurnFactor, PaddleTurnFactor);
        
    }


}
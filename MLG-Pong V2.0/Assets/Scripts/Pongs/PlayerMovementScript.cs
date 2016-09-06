using UnityEngine;
using System.Collections;
using System;

public class PlayerMovementScript : MonoBehaviour {

    public float WallLimit, PaddleSize;

    public GameObject Paddle;


    // Update is called once per frame
    void FixedUpdate()
    {

        Vector3 pos = transform.position;

        RaycastHit RaycastHitPoint;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHitPoint))
        {
            Vector3 movem = new Vector3(0f, RaycastHitPoint.point.y, RaycastHitPoint.point.z);

			//Get change in Y and change in Z to calculate appropriate rotation
            Paddle.GetComponent<PaddleScript>().DeltaYZ(movem.y - pos.y, movem.z - pos.z);

			pos = PaddleRestrict(pos, movem);
			   
        }
        transform.position = pos;

    }

	//Keeps Paddles within the walls of the playspace
    private Vector3 PaddleRestrict(Vector3 pos, Vector3 movem)
    {
        float x, y, z;
        x = pos.x;
        y = Mathf.Max(Mathf.Min(movem.y, WallLimit - PaddleSize), -WallLimit + PaddleSize);
        z = Mathf.Max(Mathf.Min(movem.z, WallLimit - PaddleSize), -WallLimit + PaddleSize);

        return (new Vector3(x, y, z));
    }
}

using UnityEngine;
using System.Collections;

public class Perfect_NPC_Script : MonoBehaviour {

    public GameObject Target;
    public float WallLimit, PaddleSize;

    // Use this for initialization
    void Start () {
        WallLimit = 4f;
        PaddleSize = 0.25f;

    }

    // Update is called once per frame
    void FixedUpdate () {
        float yT = Target.transform.position.y;
        float zT = Target.transform.position.z;

        Vector3 pos = transform.position;

        float y = Mathf.Max(Mathf.Min(yT, WallLimit - PaddleSize), -WallLimit + PaddleSize);
        float z = Mathf.Max(Mathf.Min(zT, WallLimit - PaddleSize), -WallLimit + PaddleSize);

        transform.position = new Vector3(pos.x, y, z);
    }
}

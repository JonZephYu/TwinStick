using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class CameraPan : MonoBehaviour {
    public float speed = 3.5f;
    private float X;
    private float Y;

    private GameObject player;

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        Debug.Log(player.transform.position);
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log("RHoriz" + CrossPlatformInputManager.GetAxis("RHoriz"));
        Debug.Log("RVert" + CrossPlatformInputManager.GetAxis("RVert"));

        //Rotates camera transform so forward vector points at target position
        transform.LookAt(player.transform);

        //Pans camera look according to mouse movement
        //NOTE: camera is constantly LookAt the player, thus panning the camera by mouse will snap back
        if (Input.GetMouseButton(1)) {
            transform.Rotate(new Vector3(Input.GetAxis("Mouse Y") * speed, -Input.GetAxis("Mouse X") * speed, 0));
            X = transform.rotation.eulerAngles.x;
            Y = transform.rotation.eulerAngles.y;
            transform.rotation = Quaternion.Euler(X, Y, 0);
        }
    }

}

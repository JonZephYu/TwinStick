using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfieStick : MonoBehaviour {

    public float panSpeed = 10f;

    private GameObject player;
    private Vector3 armRotation;
    private float x;
    private float y;
    

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        armRotation = transform.rotation.eulerAngles;
	}
	
	// Update is called once per frame
	void Update () {
        //armRotation.y += Input.GetAxis("");


        if (Input.GetMouseButton(0)) {
        armRotation.y += Input.GetAxis("Mouse X") * panSpeed;
        armRotation.x += Input.GetAxis("Mouse Y") * panSpeed;
        //transform.Rotate(new Vector3(Input.GetAxis("Mouse Y") * panSpeed, -Input.GetAxis("Mouse X") * panSpeed, 0));

        //x = transform.rotation.eulerAngles.x;
        //y = transform.rotation.eulerAngles.y;
        //transform.rotation = Quaternion.Euler(x, y, 0);
        transform.rotation = Quaternion.Euler(armRotation); 
            
        }

        transform.position = player.transform.position;
	}
}

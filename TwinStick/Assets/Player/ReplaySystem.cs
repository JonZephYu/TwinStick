using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplaySystem : MonoBehaviour {

    private const int BUFFER_FRAMES = 100;
    private MyKeyFrame[] keyFrames = new MyKeyFrame[BUFFER_FRAMES];


    //Rigidbody needed to swap toggle isKinematic.  Want rigidBody to be kinematic during replay mode.  
    private Rigidbody rigidBody;



	// Use this for initialization
	void Start () {
        //MyKeyFrame testKey = new MyKeyFrame(2.0f, Vector3.up, Quaternion.identity);
        rigidBody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        Record();

    }

    private void PlayBack() {
        rigidBody.isKinematic = true;
        int frame = Time.frameCount % BUFFER_FRAMES;
        Debug.Log("Reading frame + " + frame);

        transform.position = keyFrames[frame].position;
        transform.rotation = keyFrames[frame].rotation;
        

    }

    private void Record() {
        rigidBody.isKinematic = false;
        //Loops between 0 and 100
        int frame = Time.frameCount % BUFFER_FRAMES;
        float time = Time.time;
        Debug.Log("Writing frame + " + frame);


        keyFrames[frame] = new MyKeyFrame(time, transform.position, transform.rotation);
    }
}


/// <summary>
/// Structure for storing time, rotation, and position for ReplaySystem
/// </summary>
public struct MyKeyFrame {
    public float frameTime;
    public Vector3 position;
    public Quaternion rotation;

    public MyKeyFrame(float time, Vector3 pos, Quaternion rot) {
        frameTime = time;
        position = pos;
        rotation = rot;
    }
}

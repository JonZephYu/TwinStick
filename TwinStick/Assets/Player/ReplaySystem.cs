using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplaySystem : MonoBehaviour {

    private GameManager gameManager;
    private const int BUFFER_FRAMES = 1000;
    private MyKeyFrame[] keyFrames = new MyKeyFrame[BUFFER_FRAMES];

    //Rigidbody needed to swap toggle isKinematic.  Want rigidBody to be kinematic during replay mode.  
    private Rigidbody rigidBody;

    private int bufferSize = BUFFER_FRAMES;
    private int lastRecordedFrame = 0, nextRecordedFrame = 0, lastPlayedFrame = 0;



	// Use this for initialization
	void Start () {
        //MyKeyFrame testKey = new MyKeyFrame(2.0f, Vector3.up, Quaternion.identity);
        rigidBody = GetComponent<Rigidbody>();
        gameManager = GameObject.FindObjectOfType<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
        if (gameManager.isRecording()) {
            Record();
        }
        else {
            //PlayBack();
            Rewind();
        }

    }

    private void PlayBack() {
        rigidBody.isKinematic = true;


        //if never reached full cycle
        //set new buffersize to last recorded frame
        //Haven't reached end of buffer yet
        if (Time.frameCount < bufferSize) {
            //Change bufferSize to current elapsed time frame.  
            bufferSize = Time.frameCount;
            lastRecordedFrame = Time.frameCount;
        }


        int frame = Time.frameCount % bufferSize;
        Debug.Log("Reading frame + " + frame);

        transform.position = keyFrames[frame].position;
        transform.rotation = keyFrames[frame].rotation;
        

    }

    private void Rewind() {
        rigidBody.isKinematic = true;


        //if never reached full cycle
        //set new buffersize to last recorded frame
        //Haven't reached end of buffer yet
        if (Time.frameCount < bufferSize) {
            //Change bufferSize to current elapsed time frame.  
            bufferSize = Time.frameCount;
            lastPlayedFrame = Time.frameCount;
        }


        int frame = Time.frameCount % bufferSize;
        //Debug.Log(lastPlayedFrame);


        //Rewind from current frame
        if (lastPlayedFrame - 1 >= 0) {
            Debug.Log("Rewinding");
            transform.position = keyFrames[lastPlayedFrame].position;
            transform.rotation = keyFrames[lastPlayedFrame].rotation;
            lastPlayedFrame--;
        }
        //If reached the beginning, loop back into the end of the keyFrames.
        else {
            lastPlayedFrame = bufferSize - 1;
            transform.position = keyFrames[lastPlayedFrame].position;
            transform.rotation = keyFrames[lastPlayedFrame].rotation;
            lastPlayedFrame--;

        }


    }

    private void Record() {
        bufferSize = BUFFER_FRAMES;

        rigidBody.isKinematic = false;
        //Loops between 0 and 100
        int frame = Time.frameCount % bufferSize;
        float time = Time.time;
        //Debug.Log("Writing frame + " + frame);
        lastPlayedFrame = frame;
        //Debug.Log(lastPlayedFrame);
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

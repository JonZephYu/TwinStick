using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameReplay : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //MyKeyFrame testKey = new MyKeyFrame(2.0f, Vector3.up, Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

public struct MyKeyFrame {
    public float timeStamp;
    public Vector3 position;
    public Quaternion rotation;

    public MyKeyFrame(float time, Vector3 pos, Quaternion rot) {
        timeStamp = time;
        position = pos;
        rotation = rot;
    }
}

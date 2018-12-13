using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class GameManager : MonoBehaviour {

    private bool recording = true;

    // Update is called once per frame
    void Update() {
        if (CrossPlatformInputManager.GetButton("Fire1")) {
            Debug.Log("Playback mode");
            recording = false;
        }
        else {
            Debug.Log("Record mode");
            recording = true;
        }
    }

    public bool isRecording() {
        return recording;
    }
}

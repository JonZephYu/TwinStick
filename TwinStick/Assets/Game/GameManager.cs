using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class GameManager : MonoBehaviour {

    private bool recording = true;
    private bool paused = false;
    private float defaultDeltaTime;
    //public static enum Status {RECORD, PLAYBACK, REWIND, PAUSE};

    private void Start() {
        PlayerPrefsManager.UnlockLevel(1);
        //Debug.Log(PlayerPrefsManager.IsLevelUnlocked(1));
        //Debug.Log(PlayerPrefsManager.IsLevelUnlocked(2));
        defaultDeltaTime = Time.fixedDeltaTime;
        //Debug.Log(defaultDeltaTime);

}

    // Update is called once per frame
    void Update() {
        if (!paused) {
            //if (CrossPlatformInputManager.GetButton("Fire1")) {
            //    Debug.Log("Playback mode");
            //    recording = false;
            //}
            if (CrossPlatformInputManager.GetButton("Fire2")) {
                Debug.Log("Rewind mode");
                recording = false;
            }
            else {
                Debug.Log("Record mode");
                recording = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.P)) {
            if (!paused) {
                PauseGame();
            }
            else {
                ResumeGame();
            }
        }

    }

    public bool isRecording() {
        return recording;
    }

    private void PauseGame() {
        Time.timeScale = 0;
        Time.fixedDeltaTime = 0;
        paused = true;
    }

    private void ResumeGame() {
        Time.timeScale = 1f;
        Time.fixedDeltaTime = defaultDeltaTime;
        paused = false;
    }

    //This message is sent by the application to pause, i.e. mobile switch windows
    private void OnApplicationPause(bool pause) {
        paused = pause;
    }

}

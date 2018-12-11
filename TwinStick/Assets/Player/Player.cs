using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour {

    

	// Use this for initialization
	void Start () {
        gameObject.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log("Horizontal: " + CrossPlatformInputManager.GetAxis("Horizontal"));
        Debug.Log("Vertical: " + CrossPlatformInputManager.GetAxis("Vertical"));
	}
}

﻿using UnityEngine;
using System.Collections;

public class Cam_Follower : MonoBehaviour {

    public GameObject mainship;
    public Vector3 camPosition;
    public Vector3 camRotation;

	// Use this for initialization
	void Awake () {
        Time.timeScale = 1;
        Cursor.visible = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (mainship == null) return;
        transform.position = mainship.transform.position +
            mainship.transform.right * camPosition.x +
            mainship.transform.up * camPosition.y +
            mainship.transform.forward * camPosition.z;
        transform.LookAt(mainship.transform);
    }
}

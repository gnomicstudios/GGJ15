﻿using UnityEngine;
using System.Collections;

public class Settings : MonoBehaviour {

    public static Settings Instance { get; private set; }

    public float CameraPanSensitvity = 1.0f;

	void Start () {
        Instance = this;
	}

	void FixedUpdate () {
        
        
	}


}
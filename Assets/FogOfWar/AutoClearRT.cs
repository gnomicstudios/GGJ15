﻿using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Camera))]
public class AutoClearRT : MonoBehaviour {

	public bool NoClearAfterStart = false;

	void Start () 
	{
		GetComponent<Camera>().clearFlags = CameraClearFlags.Color;
		GetComponent<Camera> ().backgroundColor = Color.black;
	}

	void OnPostRender () 
	{
		if(!NoClearAfterStart)
		{
			GetComponent<Camera>().clearFlags = CameraClearFlags.Depth;
		}
	}
}

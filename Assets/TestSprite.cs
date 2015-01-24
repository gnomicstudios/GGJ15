using UnityEngine;
using System.Collections;

public class TestSprite : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log ("Sprite vis: " + GetComponent<SpriteRenderer> ().isVisible.ToString ());
	}
}

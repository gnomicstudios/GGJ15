using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteColourRandomiser : MonoBehaviour {

	// Use this for initialization
	void Start () {
        var sprite = GetComponent<SpriteRenderer>();
        sprite.color = Color.HSVToRGB(Random.Range(0.0f, 1.0f), 0.7f, 0.7f);
	}
}

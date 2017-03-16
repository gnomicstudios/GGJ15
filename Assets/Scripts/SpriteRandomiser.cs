using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteRandomiser : MonoBehaviour {
    
    public SpriteRenderer spriteTarget;
    public Sprite[] sprites;

	// Use this for initialization
	void Start () {
        if (sprites != null && sprites.Length > 0)
        {
            spriteTarget.sprite = sprites[Random.Range(0, sprites.Length)];
        }
        spriteTarget.flipX = Random.Range(0, 1) == 0;
	}
}

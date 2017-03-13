using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteRandomiser : MonoBehaviour {
    
    public SpriteRenderer spriteTarget;
    public Sprite[] sprites;
    public float minScale = 0.8f;
    public float maxScale = 1.5f;

	// Use this for initialization
	void Start () {
        if (sprites != null && sprites.Length > 0)
        {
            spriteTarget.sprite = sprites[Random.Range(0, sprites.Length - 1)];
        }

        this.transform.localScale = Vector3.one * Random.Range(minScale, maxScale);
        spriteTarget.flipX = Random.Range(0, 1) == 0;
	}
}

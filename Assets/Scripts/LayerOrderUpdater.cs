using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerOrderUpdater : MonoBehaviour {

    const float SORT_Z_SCALE = -100.0f;

    public bool isMoving = false;

    Renderer theRenderer;

	// Use this for initialization
	void Start () {
        theRenderer = GetComponent<Renderer>();
        theRenderer.sortingOrder = (int)(transform.position.z * SORT_Z_SCALE);
    }
	
	// Update is called once per frame
	void Update () {
		if (isMoving)
        {
            theRenderer.sortingOrder = (int)(transform.position.z * SORT_Z_SCALE);
        }
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject[] prefabsToSpawn;
    public int count;
    public float rangeX = 300.0f;
    public float rangeZ = 300.0f;
    public float minScale = 0.8f;
    public float maxScale = 1.5f;

    // Use this for initialization
    void Start () {
		for (int i = 0; i < count; ++i)
        {
            var pos = new Vector3(Random.Range(-0.5f, 0.5f) * rangeX, 0.0f, Random.Range(-0.5f, 0.5f) * rangeZ);
            var scale = Vector3.one * Random.Range(minScale, maxScale);
            //this.transform.localScale = Vector3.one * Random.Range(minScale, maxScale);
            var newObj = GameObject.Instantiate(prefabsToSpawn[Random.Range(0, prefabsToSpawn.Length)], this.transform, false);
            newObj.transform.localPosition = pos;
            newObj.transform.localScale = scale;
        }
	}
}

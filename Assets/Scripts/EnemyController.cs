using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

    public int health;

    public bool IsAlive { get { return health > 0; } }


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

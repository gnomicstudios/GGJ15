using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour, ISelectableEntity
{
	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void OnMouseDown()
	{
		SelectionManager.Instance.CurrentSelectable = this;
	}

	#region ISelectableEntity implementation

	public void OnSelect ()
	{
		Debug.Log ("Player Selected");
	}

	public void OnDeselect ()
	{
		Debug.Log ("Player DeSelected");
	}

	#endregion
}


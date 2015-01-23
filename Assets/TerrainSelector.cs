using UnityEngine;
using System.Collections;

public class TerrainSelector : MonoBehaviour, ISelectableEntity
{
	public GameObject terrainSelectIndicator;

	// Use this for initialization
	void Start()
	{
	
	}
	
	// Update is called once per frame
	void Update()
	{
	
	}

	void OnMouseDown()
	{
		SelectionManager.Instance.CurrentSelectable = this;
	}

	#region ISelectableEntity implementation

	public void OnSelect ()
	{
		var ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit))
		{
			if (terrainSelectIndicator != null)
				terrainSelectIndicator.transform.position = hit.point;
		}
	}

	public void OnDeselect ()
	{
	}

	#endregion
}

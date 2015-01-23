using UnityEngine;
using System.Collections;

public class TerrainSelector : MonoBehaviour, ISelectableEntity
{
	public GameObject terrainSelectIndicator;

	private CameraController camController;
	private bool wasCamDragging = false;

	// Use this for initialization
	void Start()
	{
		camController = GameObject.FindObjectOfType<CameraController>();
	}
	
	// Update is called once per frame
	void Update()
	{
		wasCamDragging |= camController.IsPanning;
	}

	void OnMouseDown()
	{
		wasCamDragging = false;
	}
	void OnMouseUpAsButton()
	{
		if (!wasCamDragging)
		{
			SelectionManager.Instance.CurrentSelectable = this;
		}
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

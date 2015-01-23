using UnityEngine;
using System.Collections;

public class TerrainSelector : MonoBehaviour
{
	private CameraController camController;
	private bool wasCamDragging = false;

	public GameObject terrainSelectIndicator;


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

	void SetTargetPosition(Vector3 targetPos)
	{
		if (terrainSelectIndicator != null)
			terrainSelectIndicator.transform.position = targetPos;

		if (SelectionManager.Instance.CurrentSelectable != null)
			SelectionManager.Instance.CurrentSelectable.SetTarget(terrainSelectIndicator.transform);
	}

	void OnMouseDown()
	{
		wasCamDragging = false;
	}
	void OnMouseUpAsButton()
	{
		if (!wasCamDragging)
		{
			var ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit))
			{
				SetTargetPosition(hit.point);
			}
		}
	}
}

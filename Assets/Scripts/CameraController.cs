using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	[HideInInspector]
	public bool IsPanning;

	public float CameraPanSensitvity = 1.0f;

    bool lastIsMouseButtonDown;
    Vector3 lastMouseButtonDownPos;

	void Start () {
	
	}

	void FixedUpdate ()
	{
		if (Input.GetMouseButton(0))
		{
			// Start panning if dragged a small distance
			if (!IsPanning && Vector3.Distance(lastMouseButtonDownPos, Input.mousePosition) > 4.0f)
			{
				IsPanning = true;
			}
        }
		else
		{
			IsPanning = false;
		}

		if (IsPanning && lastMouseButtonDownPos != Input.mousePosition)
		{
			OnDragged(lastMouseButtonDownPos, Input.mousePosition);
		}
		
		lastMouseButtonDownPos = Input.mousePosition;
	}

    void OnDragged(Vector2 from, Vector2 to) {

        var delta = (to - from) * CameraPanSensitvity * -1.0f;
        var pos = camera.transform.position;

		camera.transform.position = new Vector3(pos.x + delta.x, pos.y, pos.z + delta.y);
    }

}

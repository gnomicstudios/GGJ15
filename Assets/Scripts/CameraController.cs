using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	[HideInInspector]
	public bool IsPanning;

	public float CameraHeight = 5.0f;
	public float CameraPanSensitvity = 1.0f;

    bool lastIsMouseButtonDown;
    Vector3 lastMouseButtonDownPos;

	void Start () {
	
	}

	void FixedUpdate () {

        var isMouseButtonDown = Input.GetMouseButton(0);

		if (isMouseButtonDown) {
			if (lastIsMouseButtonDown) {
				if (lastMouseButtonDownPos != Input.mousePosition)
				{
					IsPanning = true;
					OnDragged(lastMouseButtonDownPos, Input.mousePosition);
				}
			}
			lastMouseButtonDownPos = Input.mousePosition;
        }
		else
		{
			IsPanning = false;
		}
		lastIsMouseButtonDown = isMouseButtonDown;
	}

    void OnDragged(Vector2 from, Vector2 to) {

        var delta = (to - from) * CameraPanSensitvity * -1.0f;
        var pos = camera.transform.position;

		camera.transform.position = new Vector3(pos.x + delta.x, CameraHeight, pos.z + delta.y);
    }

}

using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	const float CameraHeight = 10.0f;

    bool lastIsMouseButtonDown;
    Vector2 lastMouseButtonDownPos;

	void Start () {
	
	}

	void FixedUpdate () {

        var isMouseButtonDown = Input.GetMouseButton(0);

		if (isMouseButtonDown) {
			if (lastIsMouseButtonDown) {
				OnDragged(lastMouseButtonDownPos, Input.mousePosition);
			}
			lastMouseButtonDownPos = Input.mousePosition;
        }
		lastIsMouseButtonDown = isMouseButtonDown;
	}

    void OnDragged(Vector2 from, Vector2 to) {

        var delta = (to - from) * Settings.Instance.CameraPanSensitvity * -1.0f;
        var pos = camera.transform.position;

		camera.transform.position = new Vector3(pos.x + delta.x, CameraHeight, pos.z + delta.y);
    }

}

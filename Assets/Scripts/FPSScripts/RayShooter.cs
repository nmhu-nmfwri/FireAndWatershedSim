// RayShooter.cs
// Programmer: Originally created by Joseph Hocking and modified by Robert Garner(rganer011235@gmail.com)
// Original Source: https://github.com/jhocking/uia-3e/
// Date: 04/07/2021
// Description: This script is used to handle the raycasting in the game.

using UnityEngine;

/// <summary>
/// This script is used to handle the raycasting in the game.
/// </summary>
public class RayShooter : MonoBehaviour {
	private Camera cam;

	void Start() {
		cam = GetComponent<Camera>();

		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}

	void OnGUI() {
		int size = 12;
		float posX = cam.pixelWidth/2 - size/4;
		float posY = cam.pixelHeight/2 - size/2;
		GUI.Label(new Rect(posX, posY, size, size), "*");
	}

	void Update() {
		if (Input.GetMouseButtonDown(0)) {
			Vector3 point = new Vector3(cam.pixelWidth/2, cam.pixelHeight/2, 0);
			Ray ray = cam.ScreenPointToRay(point);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit)) {
				GameObject hitObject = hit.transform.gameObject;
				ReactiveTarget target = hitObject.GetComponent<ReactiveTarget>();
				if (target != null) {
					target.ReactToHit();
				} 
				else {
					Messenger.Broadcast("NOT_HAZARD_FOUND");
				}
			}
		}
	}
}
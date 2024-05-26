// MouseLook.cs
// Programmer: Originally created by Joseph Hocking and modified by Robert Garner(rganer011235@gmail.com)
// Original Source: https://github.com/jhocking/uia-3e/
// Date: 04/07/2021
// Description: This script is used to handle the mouse look in the game.

using UnityEngine;

// MouseLook rotates the transform based on the mouse delta.
// To make an FPS style character:
// - Create a capsule.
// - Add the MouseLook script to the capsule.
//   -> Set the mouse look to use MouseX. (You want to only turn character but not tilt it)
// - Add FPSInput script to the capsule
//   -> A CharacterController component will be automatically added.
//
// - Create a camera. Make the camera a child of the capsule. Position in the head and reset the rotation.
// - Add a MouseLook script to the camera.
//   -> Set the mouse look to use MouseY. (You want the camera to tilt up and down like a head. The character already turns.)

/// <summary>
/// MouseLook rotates the transform based on the mouse delta.
/// </summary>
[AddComponentMenu("Control Script/Mouse Look")]
public class MouseLook : MonoBehaviour {
	public enum RotationAxes {
		MouseXAndY = 0,
		MouseX = 1,
		MouseY = 2
	}
	public RotationAxes axes = RotationAxes.MouseXAndY;

	public float sensitivityHor = 9.0f;
	public float sensitivityVert = 9.0f;
	
	public float minimumVert = -45.0f;
	public float maximumVert = 45.0f;

	private float verticalRot = 0;
	private float guiHorizontalRot = 0;
	private float guiVerticalRot = 0;


    void Start() {
		// Make the rigid body not change rotation
		Rigidbody body = GetComponent<Rigidbody>();
		if (body != null) {
			body.freezeRotation = true;
		}
	}


	void Update() {
		//TODO: Consider breaking this out into a separate classes. RJG
		if (axes == RotationAxes.MouseX) {
			transform.Rotate(0, (Input.GetAxis("Mouse X") + guiHorizontalRot) * sensitivityHor, 0);
		}
		else if (axes == RotationAxes.MouseY) {
			verticalRot -= Input.GetAxis("Mouse Y") * sensitivityVert;
			verticalRot -= guiVerticalRot * sensitivityVert;
			Debug.Log("Vertical Rotation: " + verticalRot);
			verticalRot = Mathf.Clamp(verticalRot, minimumVert, maximumVert);

			float horizontalRot = transform.localEulerAngles.y;

			transform.localEulerAngles = new Vector3(verticalRot, horizontalRot, 0);
		}
		else {
			verticalRot -= Input.GetAxis("Mouse Y")  * sensitivityVert;
			verticalRot -= guiVerticalRot * sensitivityVert;
			verticalRot = Mathf.Clamp(verticalRot, minimumVert, maximumVert);

			float delta = (Input.GetAxis("Mouse X") + guiHorizontalRot) * sensitivityHor;
			float horizontalRot = transform.localEulerAngles.y + delta;

			transform.localEulerAngles = new Vector3(verticalRot, horizontalRot, 0);
		}
	}

	public void SetButtonHorizontalRotation(float rotation)
	{
		Debug.Log("Setting Horizontal Rotation: " + rotation);
        guiHorizontalRot = rotation;
    }

    public void SetButtonVerticalRotation(float rotation)
    {
		Debug.Log("Setting Vertical Rotation: " + rotation);
        guiVerticalRot = rotation;
    }
}
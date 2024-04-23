// FPSInputs.cs
// Programmer: Originally created by Joseph Hocking and modified by Robert Garner(rganer011235@gmail.com)
// Original Source: https://github.com/jhocking/uia-3e/
// Date: 04/07/2021
// Description: This script is used to handle the first-person player movement.
 
using UnityEngine;

/// <summary>
/// This script is used to handle the first-person player movement. 
/// </summary>
[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/FPS Input")]
public class FPSInput : MonoBehaviour {
	public float speed = 6.0f;
	public float gravity = -9.8f;

	private CharacterController charController;
	
	void Start() {
		charController = GetComponent<CharacterController>();
	}
	
	void Update() {
		float deltaX = Input.GetAxis("Horizontal") * speed;
		float deltaZ = Input.GetAxis("Vertical") * speed;
		Vector3 movement = new Vector3(deltaX, 0, deltaZ);
		movement = Vector3.ClampMagnitude(movement, speed);

		movement.y = gravity;

		movement *= Time.deltaTime;
		movement = transform.TransformDirection(movement);
		charController.Move(movement);

		//TODO: Add head bobbing and jumping. RJG
	}
}

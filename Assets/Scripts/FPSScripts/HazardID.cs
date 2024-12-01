// ReactiveTarget.cs
// Programmer: Originally created by Joseph Hocking and modified by Robert Garner(rganer011235@gmail.com)
// Original Source: https://github.com/jhocking/uia-3e/
// Date: 04/07/2021
// Description: This script is used to handle the reaction of the target when it is hit by the player.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// This script is used to handle the reaction of the target when it is hit by the player.
/// It broadcasts a message to the game manager to indicate that the target has been found and then disables the target after a delay.
/// </summary>
[RequireComponent(typeof(BoxCollider))]
public class ReactiveTarget : MonoBehaviour {

	public string textToDisplayOnClick = "";
	bool found = false;
	public void ReactToHit() {
        if (found) {
			return;
		}
		Messenger<string>.Broadcast(GameEvent.HAZARD_FOUND, textToDisplayOnClick);
		found = true;
		StartCoroutine(React());
	}

	private IEnumerator React() 
	{		
		yield return new WaitForSeconds(4f);		
		gameObject.SetActive(false);
	}
}

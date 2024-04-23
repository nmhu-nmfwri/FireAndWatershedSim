using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour {

	bool found = false;
	public void ReactToHit() {
        if (found) {
			return;
		}
		Messenger.Broadcast(GameEvent.HAZARD_FOUND);
		found = true;
		StartCoroutine(Remove());
	}

	private IEnumerator Remove() {
		//TODO: Implement this method
		
		yield return new WaitForSeconds(1.5f);
		
		gameObject.SetActive(false);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour {
	[SerializeField] TMP_Text foundHazardText;
	[SerializeField] TMP_Text statusText;
	public int totalHazards = 3;
	public int hazardsFound=0;

	void OnEnable() {
		Messenger.AddListener(GameEvent.HAZARD_FOUND, OnHazardFound);
		Messenger.AddListener(GameEvent.NOT_HAZARD_FOUND, OnNotHazardFound);
	}
	void OnDisable() {
		Messenger.RemoveListener(GameEvent.HAZARD_FOUND, OnHazardFound);
		Messenger.RemoveListener(GameEvent.NOT_HAZARD_FOUND, OnNotHazardFound);
	}

	void Start() {
		//levelEnding.gameObject.SetActive(false);
		//popup.gameObject.SetActive(false);
	}

	void Update() {
		// if (Input.GetKeyDown(KeyCode.M)) {
		// 	bool isShowing = popup.gameObject.activeSelf;
		// 	popup.gameObject.SetActive(!isShowing);
		// 	popup.Refresh();
		// }
	}

	private void OnHazardFound() {
		string message = $"You found {++hazardsFound} of {totalHazards} hazards!";
		foundHazardText.text = message;
	}

	private void OnNotHazardFound() {
		string message = $"Not one of the hazards we are looking for. Keep looking!";
		statusText.text = message;
		StartCoroutine(WaitThenClearStatus());
	}

	private IEnumerator WaitThenClearStatus() {
		yield return new WaitForSeconds(1);
		statusText.text = "";
	}
	// private void OnLevelFailed() {
	// 	StartCoroutine(FailLevel());
	// }
	// private IEnumerator FailLevel() {
	// 	levelEnding.gameObject.SetActive(true);
	// 	levelEnding.text = "Level Failed";
		
	// 	yield return new WaitForSeconds(2);

	// 	Managers.Player.Respawn();
	// 	Managers.Mission.RestartCurrent();
	// }

	// private void OnLevelComplete() {
	// 	StartCoroutine(CompleteLevel());
	// }
	// private IEnumerator CompleteLevel() {
	// 	levelEnding.gameObject.SetActive(true);
	// 	levelEnding.text = "Level Complete!";

	// 	yield return new WaitForSeconds(2);

	// 	Managers.Mission.GoToNext();
	// }

	// private void OnGameComplete() {
	// 	levelEnding.gameObject.SetActive(true);
	// 	levelEnding.text = "You Finished the Game!";
	// }

	// public void SaveGame() {
	// 	Managers.Data.SaveGameState();
	// }

	// public void LoadGame() {
	// 	Managers.Data.LoadGameState();
	// }
}

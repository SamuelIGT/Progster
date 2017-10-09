using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
	[Header("\tMessage Controller")]
	public string message;

	[Header("\tHUD Controller")]
	public HUDController hud;

	[Header("\tPlayer Skills")]
	public float hopHeight = 1.25f;

	private bool hopping = false;
	private bool walking = false;

	private Transform playerTranform;
	private Vector3 targetPosition;

	private int stageSeedsCount;
	private int coinSeedsCount;


	void Start(){
		playerTranform = this.gameObject.transform;
		stageSeedsCount = 0;
		coinSeedsCount = 0;


	}

	void Update() {
		if (Input.GetKeyDown(KeyCode.Space)&& !hopping && !walking) {
			targetPosition = new Vector3(playerTranform.position.x + 2, playerTranform.position.y, 0.0f);
			Vector3 pos = targetPosition;
			pos.z = 0.0f;
			StartCoroutine(Hop(pos, 0.75f));
		}

		if (Input.GetKeyDown (KeyCode.RightArrow) && !walking && !hopping) {
			targetPosition = new Vector3(playerTranform.position.x + 1, playerTranform.position.y, 0.0f);
			StartCoroutine (Walk(targetPosition, 0.75f));
		}

		if (Input.GetKeyDown (KeyCode.LeftArrow) && !walking && !hopping) {
			targetPosition = new Vector3(playerTranform.position.x - 1, playerTranform.position.y, 0.0f);
			StartCoroutine (Walk(targetPosition, 0.75f));
		}

	}
	IEnumerator Walk(Vector3 target, float time){
		if (walking) yield break;

		walking = true;
		var startPos = transform.position;
		var timer = 0.0f;

		while (timer <= 1.0f) {
			transform.position = Vector3.Lerp(startPos, target, timer);

			timer += Time.deltaTime / time;
			yield return null;
		}
		walking = false;
		playerTranform.position = targetPosition;
	}


	IEnumerator Hop(Vector3 dest, float time) {
		if (hopping) yield break;

		hopping = true;
		var startPos = transform.position;
		var timer = 0.0f;

		while (timer <= 1.0f) {
			var height = Mathf.Sin(Mathf.PI * timer) * hopHeight;
			transform.position = Vector3.Lerp(startPos, dest, timer) + Vector3.up * height; 

			timer += Time.deltaTime / time;
			yield return null;
		}
		hopping = false;
		playerTranform.position = targetPosition;
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag ("Seed")) {
			other.gameObject.SetActive (false);
			stageSeedsCount = stageSeedsCount + 1;
			hud.updateStageSeedsCount (stageSeedsCount);

			Debug.Log ("Seed");
		}
		if (other.CompareTag ("Coin Seed")) {
			other.gameObject.SetActive (false);
			coinSeedsCount = coinSeedsCount + 1;
			hud.updateCoinSeedsCount (coinSeedsCount);

			Debug.Log ("Coin Seed");
		}

		if (other.CompareTag ("Enemy")) {
			hud.gameOver ();
			Debug.Log ("Enemy");
		}

		if (other.CompareTag ("Finish")) {
			hud.completeStage ();
			Debug.Log ("Flag");
		}
	}



	public bool getHopping(){
		return hopping;
	}

}
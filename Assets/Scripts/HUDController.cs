using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour {
	
	public Text coinSeedsCountText;
	public Text endGameText;

	public Image[] stageCoinHUD;

	private bool menuShown;
	public GameObject menu;

	// Use this for initialization
	void Start () {
		endGameText.gameObject.SetActive (false);
		menuShown = false;
		menu.SetActive (false);

	}
	
	// Update is called once per frame
	void Update () {
		

		
	}

	public void updateStageSeedsCount(int stageSeedsCount){
		if (stageSeedsCount > 0) {
			//Gets the current color of Stage Coin HUD image
			Color tmp = stageCoinHUD [stageSeedsCount - 1].color;
			//Sets the alpha color
			tmp.a = 1f;
			//Updates the alpha color of Stage Coin HUD image
			stageCoinHUD [stageSeedsCount - 1].color = tmp;
		}
	}

	public void updateCoinSeedsCount(int coinSeedsCount){

		if (coinSeedsCount <= 9) {
			coinSeedsCountText.text = "x0" + coinSeedsCount;
		} else {
			coinSeedsCountText.text = "x" + coinSeedsCount;
		}
	}

	public void gameOver(){
		endGameText.text = "Game Over";
		endGameText.gameObject.SetActive (true);
	}

	public void completeStage(){
		endGameText.text = "Fim da Fase";
		endGameText.gameObject.SetActive (true);
	}

	public void showMenu(){
		if (menu.activeSelf) {
			menuShown = false;
			menu.SetActive (false);
			Debug.Log ("Hiding menu");
		} else {
			menu.SetActive (true);
			menuShown = true;
			Debug.Log ("Showing menu");
		}

	}
	public bool isShowingMenu(){
		return menuShown;
	}
}

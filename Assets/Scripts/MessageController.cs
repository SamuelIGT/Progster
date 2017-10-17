using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageController : MonoBehaviour
{

	public string encryptedMessage;

	public HUDController hudController;
	public PlayerController playerController;

	private bool isCoroutineExecuting = false;

	private string[] funtion1Elements;
	private string[] funtion2Elements;
	private string[] funtion3Elements;

	private string[] repetition1Elements;
	private string[] repetition2Elements;
	private string[] repetition3Elements;
	private string[] repetition4Elements;
	private string[] repetition5Elements;

	private string[] commands;

	// Use this for initialization
	void Start ()
	{
	}

	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Space)) {
			decryptMessage ();
		}
		if (Input.GetKeyDown (KeyCode.Escape)) {
			hudController.showMenu ();
		}
	}

	void decryptMessage ()
	{
		
		if (!encryptedMessage.Equals ("")) {
			
			if (encryptedMessage.Equals ("up")) {
				if (hudController.isShowingMenu ()) {
					Debug.Log ("Menu up");
				}
			} else if (encryptedMessage.Equals ("down")) {
				if (hudController.isShowingMenu ()) {
					Debug.Log ("Menu down");
				}
			} else if (encryptedMessage.Equals ("pause")) {
				hudController.showMenu ();
				
			} else if (encryptedMessage.Equals ("play")) {
				if (hudController.isShowingMenu ()) {
					Debug.Log ("Select option");
				}
			} else {
				string[] a = encryptedMessage.Split (']');
				funtion1Elements = a [0].Split ('[') [1].Split (';');
				funtion2Elements = a [1].Split ('[') [1].Split (';');
				funtion3Elements = a [2].Split ('[') [1].Split (';');

				repetition1Elements = a [3].Split ('[') [1].Split (';');
				repetition2Elements = a [4].Split ('[') [1].Split (';');
				repetition3Elements = a [5].Split ('[') [1].Split (';');
				repetition4Elements = a [6].Split ('[') [1].Split (';');
				repetition5Elements = a [7].Split ('[') [1].Split (';');

				commands = a [8].Split ('[') [1].Split (';');

				StartCoroutine (executeCommands (commands));
			}
		}
	}

	IEnumerator executeCommands (string[] cmds)
	{
		for (int i = 0; i < cmds.Length; i++) {
			teste (cmds [i]);
			yield return new WaitForSeconds (1.0f);
		}
	}

	void teste (string cmd)
	{
		switch (cmd) {
		case "0":
			Debug.Log ("Empty");
			break;

		case "a":
			Debug.Log ("Walk");
			playerController.Walk ();
		/*	NotifyPlayerController (10f, "WALK");
			Debug.Log (isCoroutineExecuting);
			while (isCoroutineExecuting) {
				Debug.Log ("waiting");
			}*/

			break;

		case "p":
			Debug.Log ("Jump");
			playerController.Jump ();
			/*NotifyPlayerController (10f, "JUMP");
			Debug.Log (isCoroutineExecuting);
			while (isCoroutineExecuting) {
				Debug.Log ("waiting");
			}*/

			break; 

		case "d":
			Debug.Log ("Go Down");
			break;

		case "s":
			Debug.Log ("Go Up");
			break;

		case "f1":
			if (funtion1Elements.Length > 0) {
				StartCoroutine (executeCommands (funtion1Elements));
			} else {
				Debug.Log ("Função 1 vazia");
			}
			break;

		case "f2":
			if (funtion2Elements.Length > 0) {
				StartCoroutine (executeCommands (funtion2Elements));
			} else {
				Debug.Log ("Função 2 vazia");
			}
			break;

		case "f3":
			if (funtion3Elements.Length > 0) {
				StartCoroutine (executeCommands (funtion3Elements));
			} else {
				Debug.Log ("Função 3 vazia");
			}
			break;

		case "r1":
			if (repetition1Elements.Length > 1) {
				int repetitions = int.Parse (repetition1Elements [1]) - 1;

				for (int j = 0; j <= repetitions; j++) {
					StartCoroutine (executeCommands (new string[] { repetition1Elements [0] })); //call the recusion passing as parameter a new string array that has only the repetition1Elements[0] value
				}
			} else {
				Debug.Log ("Repetição 1 vazia");
			}

			break;
		case "r2":
			if (repetition2Elements.Length > 0) {
				int repetitions = int.Parse (repetition2Elements [1]) - 1;

				for (int j = 0; j <= repetitions; j++) {
					StartCoroutine (executeCommands (new string[] { repetition2Elements [0] })); //call the recusion passing as parameter a new string array that has only the repetition2Elements[0] value
				}
			} else {
				Debug.Log ("Repetição 2 vazia");
			}
			break;

		case "r3":
			if (repetition3Elements.Length > 0) {
				int repetitions = int.Parse (repetition3Elements [1]) - 1;

				for (int j = 0; j <= repetitions; j++) {
					StartCoroutine (executeCommands (new string[] { repetition3Elements [0] })); //call the recusion passing as parameter a new string array that has only the repetition3Elements[0] value
				}
			} else {
				Debug.Log ("Repetição 3 vazia");
			}

			break;

		case "r4":
			if (repetition4Elements.Length > 0) {
				int repetitions = int.Parse (repetition4Elements [1]) - 1;

				for (int j = 0; j <= repetitions; j++) {
					StartCoroutine (executeCommands (new string[] { repetition4Elements [0] })); //call the recusion passing as parameter a new string array that has only the repetition4Elements[0] value
				}
			} else {
				Debug.Log ("Repetição 4 vazia");
			}

			break;

		case "r5":
			if (repetition5Elements.Length > 0) {
				int repetitions = int.Parse (repetition5Elements [1]) - 1;

				for (int j = 0; j <= repetitions; j++) {
					StartCoroutine (executeCommands (new string[] { repetition5Elements [0] })); //call the recusion passing as parameter a new string array that has only the repetition5Elements[0] value
				}
			} else {
				Debug.Log ("Repetição 5 vazia");
			}

			break;
		}
	}

	IEnumerator NotifyPlayerController (float time, string movement)
	{
		isCoroutineExecuting = true;
		Debug.Log (isCoroutineExecuting);

		if (movement.Equals ("WALK")) {
			playerController.Walk ();
		} else if (movement.Equals ("JUMP")) {
			playerController.Jump ();	
		}

		yield return new WaitForSeconds (time);
		isCoroutineExecuting = false;
		Debug.Log (isCoroutineExecuting);

	}
}

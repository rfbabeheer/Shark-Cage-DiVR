using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using System.IO;

public class GameSystem : MonoBehaviour {

	private string fileName = "SCDScrnShot";
	private string savedFileName;
	private bool onDive = true;
	private bool onCapture = false;


	

	// Use this for initialization
	void Start () {
		//projector = ge
	}
	
	// Update is called once per frame
	void Update () {

		//Pengambilan Screenshot
		if (Cardboard.SDK.Triggered) {
			if(onDive && !onCapture){
				//StartCoroutine(ScreenCapture());
			}
		}
	}

	IEnumerator ScreenCapture()
	{
		startScreenCapture ();
		yield return new WaitForSeconds(1);
		endScreenCapture();
	}

	void startScreenCapture(){
		onCapture = true;
		Cardboard.SDK.VRModeEnabled = false;
		savedFileName = fileName + System.DateTime.Now.ToString("yyyyMMddHHmmss")+".png";
		Debug.Log(savedFileName);
		Application.CaptureScreenshot(savedFileName);
		string origin = System.IO.Path.Combine(Application.persistentDataPath, savedFileName);
		string destination = "/sdcard/Pictures/" + savedFileName; // could be anything
		if (System.IO.File.Exists(origin)) {
			System.IO.File.Move(origin, destination);
		}
		Debug.Log("Screenshot captured : "+savedFileName);
	}

	void endScreenCapture(){
		Cardboard.SDK.VRModeEnabled = true;
		onCapture = false;
	}

}

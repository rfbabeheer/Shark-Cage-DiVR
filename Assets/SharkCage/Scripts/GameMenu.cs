using UnityEngine;
using System.Collections;

public class GameMenu : MonoBehaviour {
	static bool enterVR;
	Renderer rend;
	
	void Start() {
		Debug.Log (enterVR);
		rend = GameObject.Find ("FadingPlane").GetComponent<Renderer>();
		if (Application.loadedLevelName == "scene") {
			Cardboard.SDK.VRModeEnabled = enterVR;
		}
	}
	
	void Update() {
		StartCoroutine (FadeOut ());
		//Debug.Log (rend.material.color.a);
		Debug.Log (enterVR);
		if (Input.GetKeyDown (KeyCode.Escape)) 
			ExitScene (); 
	}

	public void EnterDiveScene(bool enableVR){
		StartCoroutine (FadeIn ());
		enterVR = enableVR;
		Application.LoadLevel ("scene");
	}

	public void ExitScene(){
		if (Application.loadedLevelName == "scene") {
			Application.LoadLevel("menu");
		} else {
			Application.Quit();
		}
	}

	IEnumerator FadeOut(){
		if (rend.material.color.a>0) {
			rend.material.color -= new Color(0,0,0,0.5f*Time.deltaTime);
		}
		yield return new WaitForSeconds (2); 
	}
	IEnumerator FadeIn(){
		if (rend.material.color.a<1) {
			rend.material.color += new Color(0,0,0,0.5f*Time.deltaTime);
		}
		yield return new WaitForSeconds (2); 
	}
}
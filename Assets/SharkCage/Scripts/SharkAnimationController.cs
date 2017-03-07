using UnityEngine;
using System.Collections;

public class SharkAnimationController : MonoBehaviour {
	[SerializeField] float moveSpeed;
	[SerializeField] float sharkNumber;
	public Animation anim;
	protected float oldRot;
	// Use this for initialization
	void Start () {

		anim = GetComponent<Animation> ();
		bool onLoop = true;
		SharkAnim ();
		StartCoroutine(Example());
	}

	// Update is called once per frame
	void Update () {


	}

	void Awake(){

	}

	void SharkAnim(){
		iTween.MoveTo(gameObject, iTween.Hash("path", 
		                                      iTweenPath.GetPath("Node"+sharkNumber),
		                                      "time",moveSpeed,
		                                      "easetype","linear",
		                                      "orienttopath", true,
		                                      "looktime", 0.5f,
		                                      "oncomplete", "SharkAnim"));
	}
	
	IEnumerator Example() {
		//Debug.Log(Time.time);
		//oldRot = gameObject.transform.rotation.eulerAngles.y;
		while (true) {
			//Debug.Log("OldRot = " + (gameObject.transform.rotation.eulerAngles.y -oldRot));

			if ((gameObject.transform.rotation.eulerAngles.y - oldRot) < -15f) {
				//Debug.Log ("Swim Left");
				anim.Play ("SwimLeft");
			} else if ((gameObject.transform.rotation.eulerAngles.y - oldRot) > 15f) {
				Debug.Log ("Swim Right");
				anim.Play ("SwimRight");
			}
			else {
				//Debug.Log ("Swim");
				anim.Play("Swim");
			}
			oldRot = gameObject.transform.rotation.eulerAngles.y;
			yield return new WaitForSeconds (2);
		}
	}



	public void SwimLeft(){
		//anim.Play("SwimLeft");
	}

	public void SwimRight(){
		//anim.Play("SwimRight");
	}

	public void SwimUp(){
		//anim.Play("SwimUp");
	}

	public void SwimDown(){
		//anim.Play("SwimDown");
	}

	public void Bite(){
		//anim.Play("Bite");
	}

	public void Snap(){
		//anim.Play("Snap");
	}

}

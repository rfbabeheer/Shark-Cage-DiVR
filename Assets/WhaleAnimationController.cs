using UnityEngine;
using System.Collections;

public class WhaleAnimationController : MonoBehaviour {

	[SerializeField] float moveSpeed;
	protected Animation anim;
	protected float oldRot;
	// Use this for initialization
	void Start () {
		
		anim = GetComponent<Animation> ();
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.back * moveSpeed);
		
	}
}
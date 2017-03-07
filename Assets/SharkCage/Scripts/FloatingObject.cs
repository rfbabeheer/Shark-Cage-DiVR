using UnityEngine;
using System.Collections;

public class FloatingObject : MonoBehaviour {

	float floatX;
	float floatY;
	float floatZ;
	[SerializeField] float floatAmpX;
	[SerializeField] float floatAmpY;
	[SerializeField] float floatAmpZ;
	[SerializeField] float floatSpeed;
	float index;
	// Use this for initialization
	void Start () {
		DivingSequence ();
	}
	
	// Update is called once per frame
	void Update () {

		//transform.Rotate (new Vector3 (0,0,Mathf.Sin (floatSpeed * index)));
	}

	void DivingSequence(){
		iTween.MoveTo(gameObject, iTween.Hash("path", 
		                                      iTweenPath.GetPath("DivingPath"),
		                                      "time",45,
		                                      "easetype","linear"));
	}

	void FloatingMovement(){
		index += Time.deltaTime;
		floatX = floatAmpX * Mathf.Sin (floatSpeed * index);
		floatY = floatAmpY * Mathf.Sin (floatSpeed * index);
		floatZ = floatAmpZ * Mathf.Sin (floatSpeed * index);
		transform.localPosition = new Vector3 (floatX, floatY, floatZ);
	}
}

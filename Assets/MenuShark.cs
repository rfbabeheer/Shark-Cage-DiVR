using UnityEngine;
using System.Collections;

public class MenuShark : MonoBehaviour {
	[SerializeField] float moveSpeed;

	// Use this for initialization
	void Start () {
		iTween.MoveTo(gameObject, iTween.Hash("path", 
		                                      iTweenPath.GetPath("menu path"),
		                                      "time",moveSpeed,
		                                      "easetype","linear",
		                                      "orienttopath", true,
		                                      "looktime", 0.1f,
		                                      "looptype", "loop"));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

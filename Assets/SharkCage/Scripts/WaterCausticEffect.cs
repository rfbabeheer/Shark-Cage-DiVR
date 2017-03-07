using UnityEngine;
using System.Collections;

public class WaterCausticEffect : MonoBehaviour {

	[SerializeField] float fps = 30f;
	[SerializeField] Texture2D[] animationFrame;
	
	private int frameIndex;
	private Projector causticProjector;

	// Use this for initialization
	void Start () {
		causticProjector = GetComponent<Projector> ();
		NextFrameCausticAnimation ();
		InvokeRepeating("NextFrameCausticAnimation", 1 / fps, 1/fps);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void NextFrameCausticAnimation(){
		causticProjector.material.SetTexture ("_ShadowTex", animationFrame [frameIndex]);
		frameIndex = (frameIndex + 1) % animationFrame.Length;
	}
}

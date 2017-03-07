using UnityEngine;
using System.Collections;

public class UnderWaterEnvironment : MonoBehaviour {

	[SerializeField] float colorR;
	[SerializeField] float colorG;
	[SerializeField] float colorB;
	[SerializeField] float alpha;
	[SerializeField] float density;
	float waterLevel;
	bool isUnderWater;
	Color underwaterColor;

	private float fps = 30f;
	public Texture2D[] frames;
	
	private int frameIndex;
	private Projector projector;


	// Use this for initialization
	void Start () {

		UnderwaterRender ();
		projector = GetComponent<Projector> ();

	}
	
	// Update is called once per frame
	void Update () {
	}
	

	void UnderwaterRender(){
		underwaterColor = new Color (colorR, colorG, colorB, alpha);
		RenderSettings.fogColor = underwaterColor;
		RenderSettings.fogDensity = density;
		RenderSettings.fog = true;
	}

	void NextFrameCausticAnimation(){
		projector.material.SetTexture ("_ShadowTex", frames [frameIndex]);
		frameIndex = (frameIndex + 1) % frames.Length;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardView : MonoBehaviour {	
	public string defaultCardText;

	private TextMesh cardTextMesh;
	private ParticleSystem SelectedParticleSystem;

	// Use this for initialization
	void Start () {
		GameObject CardTextObject = this.transform.Find("CardText").gameObject;
		cardTextMesh = CardTextObject.GetComponent<TextMesh>();
		setDisplayText(defaultCardText);

		GameObject ParticleObject = this.transform.Find("CardSelectedParticles").gameObject;
		SelectedParticleSystem = ParticleObject.GetComponent<ParticleSystem>();
		var emission = SelectedParticleSystem.emission;
		emission.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void onMouseUp() {
		// useCard();
	}

	void OnMouseOver() {
		var emission = SelectedParticleSystem.emission;
		emission.enabled = true;
	}

	void OnMouseExit() {
		var emission = SelectedParticleSystem.emission;
		emission.enabled = false;
	}

	public void setDisplayText(string newText) {
		if (cardTextMesh != null) {
			cardTextMesh.text = newText;
		} else {
			defaultCardText = newText;
		}
	}
}

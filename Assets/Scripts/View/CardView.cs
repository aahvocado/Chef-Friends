using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardView : MonoBehaviour {
	public string displayText;
	
	private string id;
	private TextMesh cardText;
	private ParticleSystem SelectedParticleSystem;

	// Use this for initialization
	void Start () {
		GameObject CardTextObject = this.transform.Find("CardText").gameObject;
		cardText = CardTextObject.GetComponent(typeof(TextMesh)) as TextMesh;
		cardText.text = displayText;

		GameObject ParticleObject = this.transform.Find("CardSelectedParticles").gameObject;
		SelectedParticleSystem = ParticleObject.GetComponent<ParticleSystem>();
		var emission = SelectedParticleSystem.emission;
		emission.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		
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
		displayText = newText;
	}
}

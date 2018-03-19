using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardView : BaseView {
	// view
	private string animationName;
	private float animationTimeDefault = 22;
	private float animationTime;
	private Vector3 animStartPos;
	private Vector3 animEndPos;

	// data
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
		if (animationTime > 0) {
			Vector3 curPos = this.transform.position;
			float animPercent = 1.0f - (animationTime / animationTimeDefault);
			Vector3 pointB = new Vector3(animStartPos.x + 1, animStartPos.y + 1.5f, animStartPos.z);
			this.transform.position = CurveHelper.getQuadraticBezier(animStartPos, pointB, animEndPos, animPercent);
			animationTime --;
		}
	}

	// - called from Controller
	// when the card was used
	public void animateUseCard() {
		Vector3 curPos = this.transform.position;
		animStartPos = curPos;
		animEndPos = new Vector3(curPos.x + 3, curPos.y - 3, curPos.z);
		animationTime = animationTimeDefault;
	}

	// - setters
	public void setDisplayText(string newText) {
		if (cardTextMesh != null) {
			cardTextMesh.text = newText;
		} else {
			defaultCardText = newText;
		}
	}

	// - getters

	// MonoBehavior
	void OnMouseUp() {
		if (controller != null) {
			controller.OnViewMouseUp();
		}
	}

	void OnMouseOver() {
		var emission = SelectedParticleSystem.emission;
		emission.enabled = true;
	}

	void OnMouseExit() {
		var emission = SelectedParticleSystem.emission;
		emission.enabled = false;
	}

}

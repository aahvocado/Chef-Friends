using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardView : BaseView {
	// view
	private string animationState; // name of the animation being used
	private bool destroyOnUse; // destroy this card GameObject after being used?
	
	private float animationTimeDefault = 22;
	private float animationTime;
	private Vector3 animStartPos;
	private Vector3 animEndPos;

	// data
	public string defaultCardText;
	public Vector3 handRelativePosition; // this card's position in the hand

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

		// prepare for animation
		transform.localScale = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update () {

		if (animationTime > 0) {
			float animPercent = 1.0f - (animationTime / animationTimeDefault);

			// animate drawing a card
			if (animationState == "drawing") {
				transform.localScale = Vector3.one * animPercent;
				Vector3 pointB = animEndPos - animStartPos;
				transform.position = CurveHelper.getQuadraticBezier(animStartPos, pointB, animEndPos, animPercent);
			}
			// animate the card being used
			if (animationState == "consuming") {
				Vector3 pointB = new Vector3(animStartPos.x + 1, animStartPos.y + 1.5f, animStartPos.z);
				transform.position = CurveHelper.getQuadraticBezier(animStartPos, pointB, animEndPos, animPercent);
			}

			// done animating a frame
			animationTime --;
			if (animationTime == 0 && destroyOnUse) {
				handleViewDestroy();
			}
		}
	}

	// - called from Controller
	// when the card was drawn
	public void animateDrawCard(Vector3 start) {
		animationState = "drawing";
		animationTimeDefault = 8;
		animStartPos = start;
		animEndPos = CardConstants.handCenterPosition;
		animationTime = animationTimeDefault;
		destroyOnUse = false;
	}
	// when the card was used
	public void animateUseCard() {
		animationState = "consuming";
		Vector3 curPos = this.transform.position;
		animStartPos = curPos;
		animEndPos = new Vector3(curPos.x + 3, curPos.y - 3, curPos.z);
		animationTimeDefault = 22;
		animationTime = animationTimeDefault;
		destroyOnUse = true;
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
	public override bool isInteractable() {
		if (animationTime == 0) {
			return true;
		} else {
			return false;
		}
	}

	// MonoBehavior
	void OnMouseUp() {
		if (controller != null && isInteractable()) {
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

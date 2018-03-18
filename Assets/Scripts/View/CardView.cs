using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardView : MonoBehaviour {
	public string displayText;
	
	private string id;
	private TextMesh cardText;

	// Use this for initialization
	void Start () {
		GameObject CardTextObject = this.transform.Find("CardText").gameObject;
		cardText = CardTextObject.GetComponent(typeof(TextMesh)) as TextMesh;
		cardText.text = displayText;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void setDisplayText(string newText) {
		displayText = newText;
	}
}

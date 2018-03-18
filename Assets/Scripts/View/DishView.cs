using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DishView : BaseView {
	public string defaultCardText;
	public string defaultCompletionText;

	private TextMesh dishTextMesh;
	private TextMesh completionTextMesh;

	// Use this for initialization
	void Start () {
		GameObject DishTextObject = this.transform.Find("DishText").gameObject;
		dishTextMesh = DishTextObject.GetComponent<TextMesh>();
		setDisplayText(defaultCardText);

		GameObject CompletionTextObject = this.transform.Find("CompletionText").gameObject;
		completionTextMesh = CompletionTextObject.GetComponent<TextMesh>();
		setCompletionText(defaultCompletionText);
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void setDisplayText(string newText) {
		if (dishTextMesh != null) {
			dishTextMesh.text = newText;
		} else {
			defaultCardText = newText;
		}
	}
	public void setCompletionText(string newText) {
		if (completionTextMesh != null) {
			completionTextMesh.text = newText;
		} else {
			defaultCompletionText = newText;
		}
	}
}

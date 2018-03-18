using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardController {
	private string id;
	public string name;

	public CardController() {

	}

	// setters
	public void setId(string newId) {
		id = newId;
	}

	// getters
	public string getName() {
		return name;
	}
	public string getId() {
		return id;
	}
}

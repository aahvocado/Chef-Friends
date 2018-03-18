using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
	base Controller class for Cards
*/
public class CardController : BaseController {
    public GameController _GameController;
	public string name;
	public int power;

	private string id;

	public CardController() {
		_GameController = GameController.getInstance;
	}

	// override me
	public virtual void useCard() {}

	// view handlers
	public override void OnViewMouseUp() {
		useCard();
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

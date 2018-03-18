using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
	base Controller class for Cards
*/
public class CardController : BaseController {
    // public GameController _GameController;
    public PlayerController owner;
	public string name;
	public int power;
	public string type;

	private string id;

	public CardController() {
		// get singletons
		// _GameController = GameController.getInstance;
	}


	// view handlers
	public override void OnViewMouseUp() {
		useCard();
	}

	// setters
	public void setOwner(PlayerController newOwner) {
		owner = newOwner;
	}
	public void setId(string newId) {
		id = newId;
	}

	// override me
	public virtual void useCard() {}

	// getters
	public string getName() {
		return name;
	}
	public string getId() {
		return id;
	}
	public string getType() {
		return type;
	}
	public int getPower() {
		return power;
	}
}

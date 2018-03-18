using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookCard : CardController {
	public CookCard() {
		name = "Cook";
		power = 1;
	}

	public override void useCard() {
		_GameController.useCook(power);
	}
}

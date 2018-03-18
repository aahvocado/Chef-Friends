using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookCard : CardController {
	public CookCard() {
		name = "Cook";
		power = 1;
		type = "cook";
	}

	public override void useCard() {
		if (owner != null) {
			owner.usePlayerCard(this);
		}
	}
}

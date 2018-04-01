using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    base Controller class for Cards
*/
public class IngredientController : UIButtonController {
    public override void handleAction() {
        Element.Game.onUseAction(Element);
    }
}

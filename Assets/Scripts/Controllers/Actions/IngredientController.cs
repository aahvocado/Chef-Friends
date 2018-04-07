using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    base Controller class for Cards
*/
public class IngredientController : BaseController {
    public IngredientElement Element;

    // when the card view was clicked
    public virtual void handleOnMouseUp() {
        this.handleAction();
    }

    public void handleViewBeforeDestroy() {
        Element.View = null;
    }

    public void handleAction() {
        // Element.Game.onUseAction(Element);
    }

    /* trying to keep certain variables private */
    public void setElement(IngredientElement e) {
        Element = e;
    }
}

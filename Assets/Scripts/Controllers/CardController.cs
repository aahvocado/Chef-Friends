using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    base Controller class for Cards
*/
public class CardController : BaseController {
    public CardElement Element;

    public CardController() {

    }

    // when the card view was clicked
    public virtual void handleOnMouseUp() {
        this.useCard();
    }

    public virtual void handleOnDoneAnimation() {

    }

    // -- helpers


    // -- override by derived
    public virtual void useCard() {}

    // -- view
    public void updateView(string animName) {
        Element.View.handleUpdate(animName);
    }
    public void handleViewBeforeDestroy() {
        Element.View = null;
    }
}

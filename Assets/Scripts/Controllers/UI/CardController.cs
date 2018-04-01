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

    public void handleViewBeforeDestroy() {
        Element.View = null;
    }

    /* trying to keep the Element variable private */
    public void setElement(CardElement e) {
        Element = e;
    }
}

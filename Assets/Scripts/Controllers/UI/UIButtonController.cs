using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    base Controller class for Cards
*/
public class UIButtonController : BaseController {
    public UIButtonElement Element;

    // when the card view was clicked
    public virtual void handleOnMouseUp() {
        this.handleAction();
    }

    public virtual void handleOnDoneAnimation() {

    }

    // -- helpers

    // -- override by derived
    public virtual void handleAction() {
        Element.Game.onUseAction(Element);
    }

    public void handleViewBeforeDestroy() {
        Element.View = null;
    }

    /* trying to keep the Element variable private */
    public void setElement(UIButtonElement e) {
        Element = e;
    }
}

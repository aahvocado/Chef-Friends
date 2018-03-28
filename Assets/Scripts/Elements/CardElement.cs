using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    MVC Element
     how to make a base for this...
*/
public class CardElement {
    public CardModel Model;
    public CardView View;
    public CardController Controller;

    public CardElement(CardModel m) {
        // trying to always require a Model
        Model = m;
        Model.Element = this;
    }

    public CardElement createMVC(CardModel m, CardView v, CardController c) {
        Model = m;
        View = v;
        Controller = c;

        Model.Element = this;
        View.Element = this;
        Controller.Element = this;

        return this;
    }

    /* checks if all MVC elements are assigned */
    public bool isComplete() {
        return Model != null && View != null && Controller != null;
    }
}
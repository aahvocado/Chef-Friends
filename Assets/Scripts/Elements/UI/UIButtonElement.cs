using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    MVC Element
     how to make a base for this...
*/
public class UIButtonElement : SingletonHelper {
    public string ID; // todo - this needs to change...
    public string CardType;

    public UIButtonModel Model;
    public UIButtonView View;
    public UIButtonController Controller;

    /* Creates a new UIButtonModel */
    public UIButtonModel createUIButtonModel() {
        UIButtonModel newModel;
        switch (CardType) {
            case "cook":
                // newModel = new CookCard();
                // break;
            default:
                newModel = new UIButtonModel();
                break;
        }

        return newModel;
    }

    /* creates a new Card (View and Controller) and adds it to our Hand */
    public void instantiateElement(Vector3 startPos, Vector3 endPos) {
        UIButtonModel newModel = this.createUIButtonModel();

        // instantiate GameObject
        Vector3 newCardPos = startPos;
        GameObject newCardObject = Instantiator.instantiateCard(newCardPos);

        // get the View from GameObject
        UIButtonView newView = newCardObject.transform.GetComponent<UIButtonView>();        

        // assign MVC so everyone knows each other
        UIButtonController newController = new UIButtonController();
        this.createMVC(newModel, newView, newController);

        // update Model values - must be done after MVC is created
        newModel.Position = endPos;
        newModel.initModel();
    }
    public void instantiateElement() {
        this.instantiateElement(CardConstants.handStartPosition, CardConstants.handStartPosition);
    }

    /* sets the MVC relationships */
    public void createMVC(UIButtonModel m, UIButtonView v, UIButtonController c) {
        Model = m;
        View = v;
        Controller = c;

        Model.setElement(this);
        View.setElement(this);
        Controller.setElement(this);
    }

    /* checks if all MVC elements are assigned */
    public bool isInstantiated() {
        return Model != null && View != null && Controller != null;
    }

    public Vector3 getViewPosition() {
        return View.transform.position;
    }
}
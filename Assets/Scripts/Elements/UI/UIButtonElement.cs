using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtonElement : BaseElement {
    public new UIButtonModel Model;
    public new UIButtonView View;
    public new UIButtonController Controller;

    public override void instantiateElement(Vector3 startPos, Vector3 endPos) {
        UIButtonModel newModel = new UIButtonModel();

        // instantiate GameObject
        GameObject newObject = Singletons.Instantiator.instantiateObject(Type);

        // get the View from GameObject
        UIButtonView newView = newObject.transform.GetComponent<UIButtonView>();        

        // assign MVC so everyone knows each other
        UIButtonController newController = new UIButtonController();
        this.createMVC(newModel, newView, newController);

        // update Model values - must be done after MVC is created
        newModel.Position = endPos;
        newModel.initModel();
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
}
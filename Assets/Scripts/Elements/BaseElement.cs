using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    MVC Element
     how to make a base for this...
*/
public class BaseElement {
    public string ID; // todo - this needs to change...
    public string Type;

    public BaseModel Model;
    public BaseView View;
    public BaseController Controller;

    public SingletonHelper Singletons = new SingletonHelper();
    public GameManager Game {
        get { return Singletons.Game; }
    }

    public virtual void instantiateElement(Vector3 startPos, Vector3 endPos) {}

    public void instantiateElement() {
        Singletons.Instantiator.instantiateObject(Type);
    }

    /* sets the MVC relationships */
    // public virtual void createMVC(BaseModel m, BaseView v, BaseController c) {}

    /* checks if all MVC elements are assigned */
    public bool isInstantiated() {
        return Model != null && View != null && Controller != null;
    }
}
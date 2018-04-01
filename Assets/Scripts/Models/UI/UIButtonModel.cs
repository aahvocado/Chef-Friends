using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    card
*/
public class UIButtonModel : BaseModel {
    // [SerializeField]
    private UIButtonElement Element;
    private bool initialized;

    private Vector3 startPosition; // where the view currently is
    private Vector3 targetPosition; // where the view will end up
    public Vector3 Position {
        get { return targetPosition; } // todo - documentation
        set {
            targetPosition = value;
            if (initialized) {
                startPosition = Element.View.Position;
                Element.View.handlePositionUpdate();
            } else {
                startPosition = CardConstants.handStartPosition; // todo - placeholder do a proper default value set
            }
        }
    }
    
    // data
    private string _Text;
    public string Text {
        get { return _Text; }
        set {
            _Text = value;
            Element.View.Text = value;
        }
    }

    /* we need to have the entire MVC set up before we can safely do anything */
    public virtual void initModel() {
        if (Element != null) {
            Element.View.setDefaultPosition(startPosition);
            Element.View.handlePositionUpdate();
            initialized = true;
        }
    }

    /* trying to keep certain variables private */
    public void setElement(UIButtonElement e) {
        Element = e;
    }
    public void setDefaultPosition(Vector3 pos) {
        startPosition = pos;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class IngredientView : MonoBehaviour, BaseView {
    public IngredientElement Element;

    // -- interface implementation
    public void handleViewDoneAnimation() {
        // Element.Controller.handleOnDoneAnimation();
    }
    public void handleDestroy() {
        Element.Controller.handleViewBeforeDestroy();
        Destroy(gameObject);
    }

    /* trying to keep certain variables private */
    public void setElement(IngredientElement e) {
        Element = e;
    }
    public void setDefaultPosition(Vector3 pos) {
        // rectTransform.anchoredPosition = pos;
    }

}

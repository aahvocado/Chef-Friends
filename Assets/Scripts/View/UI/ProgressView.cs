using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressView : MonoBehaviour, BaseView {
    // data
    private UITextView UITextHandler;
    public string Text {
        get { return UITextHandler.Text; }
        set {
            if (UITextHandler == null) {
                UITextHandler = new UITextView(GameObject.Find("UI_Progress"));
            }
            UITextHandler.Text = value;
        }
    }

    public void handleViewDoneAnimation() {
    }
    public void handleDestroy() {
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressHandler {
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
}

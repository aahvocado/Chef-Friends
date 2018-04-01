/*
    This Class simplifies handling Text UI Components
    Usage Example
    ---
    private UITextView UITextHandler;
    public string Text {
        get { return UITextHandler.Text; }
        set {
            if (UITextHandler == null) {
                UITextHandler = new UITextHandler(transform.Find("UI_Text").gameObject);
            }
            UITextHandler.Text = value;
        }
    }
*/
using UnityEngine;
using UnityEngine.UI;
public class UITextView {
    // data
    private GameObject CardTextObject;
    private Text textComponent;
    private string _Text;
    public string Text {
        get { return _Text; }
        set {
            _Text = value;
            textComponent.text = value;
        }
    }

    public UITextView(GameObject obj) {
        CardTextObject = obj;
        textComponent = CardTextObject.GetComponent<Text>();
    }
}

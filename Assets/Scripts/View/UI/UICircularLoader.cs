using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICircularLoader : MonoBehaviour {
    private Image imageScript;

    private float _percent;
    public float Percent {
        get { return _percent; }
        set {
            _percent = value;
            this.handleUpdate();
        }
    }

	// Use this for initialization
	void Start () {
		imageScript = transform.gameObject.GetComponent<Image>();
        Percent = 0f;
	}

    void handleUpdate() {
        imageScript.fillAmount = Percent;
    }
}

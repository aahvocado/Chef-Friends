using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICircularLoader : MonoBehaviour {
    public bool isAnimating;
    public bool resetOnPress;
    public bool resetOnRelease;
    public bool resetOnFull;

    private int timer; // animation time remaining
    public int animationTime; // length of animation

    //
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

    void Update() {
        if (isAnimating && timer > 0) {
            float animPercent = 1.0f - ((float)timer / (float)animationTime);
            if (timer - 1 == 0) {
                animPercent = 1f;
            }

            Percent = animPercent;

            timer --;

            if (timer <= 0) {
                // this.handleViewDoneAnimation();

                // if (destroyAfterAnimation) {
                //     this.handleDestroy();
                // }

                if (resetOnFull) {
                    timer = animationTime;
                    Percent = 0f;
                }
            }
        }
    }

    void handleUpdate() {
        imageScript.fillAmount = Percent;
    }

    // pointer EventTriggers
    public void handlePointerDown() {
        if (resetOnPress) {
            timer = animationTime;
        } else if (timer == 0) {
            timer = animationTime;
        }
        isAnimating = true;
    }
    public void handlePointerUp() {
        if (resetOnRelease) {
            timer = 0;
            Percent = 0;
        }
        isAnimating = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardView : MonoBehaviour, BaseView {
    public CardElement Element;

    // view timing
    private int timer = 0; // animation time remaining

    // animation data to be set
    public string animationName; // name of the animation being used
    public string animationType = null; // name of the animation being used
    public int animationTime; // length of animation
    public Vector3 start; // animation start position
    public List<Vector3> midpoints;
    public Vector3 end; // animation end position
    public bool destroyAfterAnimation; // destroy this card GameObject after animating

    // data
    public string defaultCardText; // todo fix this
    public Vector3 handRelativePosition; // this card's position in the hand

    private TextMesh cardTextMesh;
    private ParticleSystem SelectedParticleSystem;

    void Start() {
        GameObject CardTextObject = transform.Find("CardText").gameObject;
        cardTextMesh = CardTextObject.GetComponent<TextMesh>();
        setDisplayText(defaultCardText);

        GameObject ParticleObject = transform.Find("CardSelectedParticles").gameObject;
        SelectedParticleSystem = ParticleObject.GetComponent<ParticleSystem>();
        var emission = SelectedParticleSystem.emission;
        emission.enabled = false;

        // prepare for animation
        transform.localScale = Vector3.zero;
    }
    
    void Update() {
        if (timer > 0) {
            float animPercent = 1.0f - ((float)timer / (float)animationTime);

            // -- type
            if (animationType == AnimationConstants.QUADRATIC_ANIM_TYPE) {
                transform.position = CurveHelper.getQuadraticBezier(start, midpoints[0], end, animPercent);
            }
            if (animationType == AnimationConstants.LINEAR_ANIM_TYPE) {
                // todo fix this
                transform.position = CurveHelper.getQuadraticBezier(start, (end - start), end, animPercent);
            }

            // -- card specific
            if (animationName == CardConstants.DRAW_CARD_ANIM) {    
                transform.localScale = Vector3.one * animPercent;
            }

            // done animating a frame
            timer --;

            if (timer == 0) {
                animationType = null;
                this.handleViewDoneAnimation();

                if (destroyAfterAnimation) {
                    this.handleDestroy();
                }
            }
        }
    }

    // -- animations
    public void handleUpdate(string animName) {
        if (this.isAnimatable()) {
            if (animName == CardConstants.DRAW_CARD_ANIM) {
                this.handleDrawCardAnimation();
            } else if (animName == CardConstants.USE_CARD_ANIM) {
                this.handleUseCardAnimation();
            } else if (animName == CardConstants.MOVE_CARD_ANIM) {
                this.setAnimationDefaultData(CardConstants.MOVE_CARD_ANIM, CardConstants.MOVE_CARD_ANIM_TIME);
                animationType = AnimationConstants.LINEAR_ANIM_TYPE;
            }
        }
    }

    /* animate when the card was drawn */
    public void handleDrawCardAnimation() {
        this.setAnimationDefaultData(CardConstants.DRAW_CARD_ANIM, CardConstants.DRAW_CARD_ANIM_TIME);
        animationType = AnimationConstants.LINEAR_ANIM_TYPE;
    }

    /* animate when the card was used */
    public void handleUseCardAnimation() {
        this.setAnimationDefaultData(CardConstants.USE_CARD_ANIM, CardConstants.USE_CARD_ANIM_TIME);
        destroyAfterAnimation = true;
        animationType = AnimationConstants.QUADRATIC_ANIM_TYPE;

        Vector3 currPos = transform.position;
        end = new Vector3(currPos.x + 1, currPos.y - 1.5f, currPos.z);

        Vector3 pointB = end - start;
        midpoints = new List<Vector3> { pointB };
    }

    // -- helpers
    /* handles setting a basic set up for animation data */
    private void setAnimationDefaultData(string newAnimName, int newAnimTime) {
        // reset some stuff
        destroyAfterAnimation = false;
        midpoints = new List<Vector3>();

        // set
        start = transform.position;
        end = Element.Model.Position;

        animationName = newAnimName;
        animationTime = newAnimTime;
        timer = newAnimTime;
    }
    public void setDisplayText(string newText) {
        if (cardTextMesh != null) {
            cardTextMesh.text = newText;
        } else {
            defaultCardText = newText;
        }
    }
    public bool isInteractable() {
        return timer == 0;
    }
    public bool isAnimatable() {
        return timer == 0 && (animationType == null || animationType == "");
    }

    // -- MonoBehavior
    void OnMouseUp() {
        if (this.isInteractable()) {
            Element.Controller.handleOnMouseUp();
        }
    }

    void OnMouseOver() {
        var emission = SelectedParticleSystem.emission;
        emission.enabled = true;
    }

    void OnMouseExit() {
        var emission = SelectedParticleSystem.emission;
        emission.enabled = false;
    }

    // -- interface implementation
    public void handleViewDoneAnimation() {
        Element.Controller.handleOnDoneAnimation();
    }
    public void handleDestroy() {
        Element.Controller.handleViewBeforeDestroy();
        Destroy(gameObject);
    }

}

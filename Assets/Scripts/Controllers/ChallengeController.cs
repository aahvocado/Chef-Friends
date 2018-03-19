using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// #singleton
public class ChallengeController : MonoBehaviour {
	public int defaultChallenge = 5;
    public GameInstantiator _GameInstantiator;

    private GameObject currentDish;
    private DishView dishView;
	private int challenge;

	// Use this for initialization
	void Start () {
		_GameInstantiator = GameInstantiator.getInstance;

		challenge = defaultChallenge;

		instanciateChallenge();
		updateDishCompletion();
	}

	public int applyCook(int power) {
		challenge -= power;
		updateDishCompletion();
		return challenge;
	}

	public void updateDishCompletion() {
		float completionPercent = Mathf.Round((1 - (float)challenge/(float)defaultChallenge) * 100f);
		dishView.setCompletionText(completionPercent + "%");
	}

	// handles asking to make a View of the current Hand
	public void instanciateChallenge() {
		Vector3 newDishPos = new Vector3(0, -1);
		currentDish = _GameInstantiator.instantiateDish(newDishPos);
		dishView = currentDish.transform.GetComponent<DishView>();
		dishView.setDisplayText("Dish");
	}

	// create singleton
	private static ChallengeController _instance;
    public static ChallengeController getInstance { get { return _instance; } }
    private void Awake() {
        if (_instance != null && _instance != this) {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }
    }
}

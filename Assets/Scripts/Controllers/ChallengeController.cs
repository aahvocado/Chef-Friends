using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// #singleton
public class ChallengeController : MonoBehaviour {
	private List<string> currentRecipe;

	// Use this for initialization
	void Start () {
		currentRecipe = new List<string> { "cook", "cook", "cook" };
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

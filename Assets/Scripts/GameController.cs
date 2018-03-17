using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    // singletons
    public GameInstantiator GameInstantiatorInstance;

    // component start here
    private int defaultHandSize = 3;

	// Use this for initialization
	void Start () {
		// get singletons
		GameInstantiatorInstance = GameInstantiator.getInstance;
		
		// do stuff
		instanciateDefaultCards();
	}

	void instanciateDefaultCards() {
		for (var i = 0; i < defaultHandSize; i++) {
			var newCardPos = new Vector3(-5.5f, 3 - (i * CardConstants.cardSize));
			var newCard = GameInstantiatorInstance.createCard(newCardPos);
			
		}
	}

	// Update is called once per frame
	void Update () {
		
	}

	// create singleton
	private static GameController _instance;
    public static GameController getInstance { get { return _instance; } }
    private void Awake() {
        if (_instance != null && _instance != this) {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }
    }
}

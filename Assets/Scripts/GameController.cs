using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// #singleton
public class GameController : MonoBehaviour {
    // singletons
    public PlayerController _PlayerController;
    public GameInstantiator _GameInstantiator;

    // component start here
    private int defaultHandSize = 3;

	// Use this for initialization
	void Start () {
		// get singletons
		_PlayerController = PlayerController.getInstance;
		_GameInstantiator = GameInstantiator.getInstance;
		
		// do stuff
		instanciateDeck();
	}

	public void instanciateDeck() {
		for (var i = 0; i < defaultHandSize; i++) {
			var newCardPos = new Vector3(-6f, 3 - (i * CardConstants.cardSize));
			var newCard = _GameInstantiator.instantiateCard(newCardPos);
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// #singleton
public class PlayerController : MonoBehaviour {
	DeckController PlayerDeck1;
	DeckController PlayerDeck2;

	// Use this for initialization
	void Start () {
		createPlayerDecks();
	}

	void createPlayerDecks() {
		PlayerDeck1 = new DeckController();
		PlayerDeck2 = new DeckController();
	}

	// gets a player's deck
	public DeckController getPlayerDeck1() {
		return PlayerDeck1;
	}
	public DeckController getPlayerDeck2() {
		return PlayerDeck2;
	}

	// create singleton
	private static PlayerController _instance;
    public static PlayerController getInstance { get { return _instance; } }
    private void Awake() {
        if (_instance != null && _instance != this) {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }
    }
}

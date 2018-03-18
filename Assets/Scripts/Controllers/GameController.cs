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
		handleNewDecks();
	}

	public void handleNewDecks() {
		DeckController playerDeck1 = _PlayerController.getPlayerDeck1();
		instanciateHandView(playerDeck1);

		DeckController playerDeck2 = _PlayerController.getPlayerDeck2();
	}

	public void instanciateHandView(DeckController deckController) {
		List<CardController> deckList = deckController.getDeck();

		for (int i = 0; i < defaultHandSize; i++) {
			CardController card = deckList[i];
			Vector3 newCardPos = new Vector3(-6f, 3 - (i * CardConstants.cardSize));
			GameObject newCard = _GameInstantiator.instantiateCard(newCardPos);
			CardView cardView = newCard.transform.GetComponent(typeof(CardView)) as CardView;
			cardView.setDisplayText(card.getName() + " " + card.getId());
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

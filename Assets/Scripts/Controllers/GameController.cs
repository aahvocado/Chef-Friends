using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// #singleton
public class GameController : MonoBehaviour {
    // singletons
    public PlayerController _PlayerController;
    public ChallengeController _ChallengeController;
    public GameInstantiator _GameInstantiator;

    // component start here
    private int defaultHandSize = 3;

	// Use this for initialization
	void Start () {
		// get singletons
		_PlayerController = PlayerController.getInstance;
		_ChallengeController = ChallengeController.getInstance;
		_GameInstantiator = GameInstantiator.getInstance;
		
		// do stuff
		instanciateNewDecks();
	}

	// Update is called once per frame
	void Update () {
		
	}

	public void useCook(int power) {
		_ChallengeController.applyCook(power);
	}
	
	// handles asking to make a View of the current Hand
	public void instanciateNewDecks() {
		DeckController playerDeck1 = _PlayerController.getPlayerDeck1();
		instanciateHandView(playerDeck1);

		// DeckController playerDeck2 = _PlayerController.getPlayerDeck2();
	}

	// makes a view of the current Hand
	public void instanciateHandView(DeckController deckController) {
		List<CardController> deckList = deckController.getDeck();

		for (int i = 0; i < defaultHandSize; i++) {
			CardController card = deckList[i];
			Vector3 newCardPos = new Vector3(7f, 4 - (i * CardConstants.cardSize));
			GameObject newCard = _GameInstantiator.instantiateCard(newCardPos);
			CardView cardView = newCard.transform.GetComponent<CardView>();
			cardView.setController(card);
			card.setView(cardView);
			cardView.setDisplayText(card.getName() + " " + card.getId());
		}
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

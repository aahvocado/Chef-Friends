using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInstantiator : MonoBehaviour {
	// component start here
	GameObject CardComponentPrefab;

	// Use this for initialization
	void Start () {
    	// CardComponentPrefab = Instantiate(Resources.Load("Prefabs/CardComponent", typeof(GameObject))) as GameObject;
	}

	//
	public GameObject createCard (Vector3 newPos) {
		var newCard = Instantiate(Resources.Load("Prefabs/CardComponent", typeof(GameObject))) as GameObject;
		var cardTransform = newCard.transform;
		cardTransform.position = newPos;
		return newCard;
	}

	// create singleton
	private static GameInstantiator _instance;
    public static GameInstantiator getInstance { get { return _instance; } }
    private void Awake() {
        if (_instance != null && _instance != this) {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }
    }
}

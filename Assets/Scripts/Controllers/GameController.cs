using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Super Awesome Game Controller
    
    #singleton
*/
public class GameController : MonoBehaviour {
    // singletons
    public ChallengeController _ChallengeController;
    // public GameInstantiator _GameInstantiator;

    // player stuff
    PlayerController Player1;
    PlayerController Player2;

    // Use this for initialization
    void Start () {
        // get singletons
        _ChallengeController = ChallengeController.getInstance;
        // _GameInstantiator = GameInstantiator.getInstance;

        //
        Player1 = new PlayerController();
    }

    // Update is called once per frame
    void Update () {
        
    }

    // uses the Cook card
    public void useCook(int power) {
        _ChallengeController.applyCook(power);
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

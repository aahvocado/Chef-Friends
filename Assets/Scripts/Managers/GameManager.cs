using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
    Super Awesome Game Controller
*/
public class GameManager : MonoBehaviour {
    // game stuff
    private SingletonHelper Singletons = new SingletonHelper();
    private string GameState;

    private ProgressHandler progressComponent;
    private int _currentTurn;
    public int CurrentTurn {
        get { return _currentTurn; }
        set {
            _currentTurn = value;
            progressComponent.Text = "Turn: " + _currentTurn;
        }
    }
    public int turnInterval = 3;

    // player stuff
    PlayerManager Player1;
    // PlayerManager Player2;

    // Use this for initialization
    void Start () {
        Player1 = new PlayerManager();
        progressComponent = new ProgressHandler();

        _currentTurn = 0;
        CurrentTurn = _currentTurn;
    }

    // Update is called once per frame
    void Update () {

    }

    // clicked on UI
    public void onUseAction(UIButtonElement Element) {
        this.handleUseAction(Element);
        CurrentTurn ++;
    }
    public void handleUseAction(UIButtonElement Element) {
        Singletons.Instantiator.instantiateObject(Element.Type);
    }

    // create singleton
    private static GameManager _instance;
    public static GameManager getInstance { get { return _instance; } }
    private void Awake() {
        if (_instance != null && _instance != this) {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }
    }
}

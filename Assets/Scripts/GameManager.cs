/// GameManager.cs
/// Manages game component ineractions.
/// Author: Jose A. Ciccio

using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{

    private int _CurrentLevel;
    private int _BlocksLeft;
    private bool _GameStarted;
    private bool _IntroComplete;
    private bool _IsLevelWon;
    public GameObject[] objectsToActivate;
    private LevelLoaderManager _LoaderManager;


    public static GameManager instance = null;

    public bool IntroComplete
    {
        get
        {
            return _IntroComplete;
        }

        set
        {
            _IntroComplete = value;
        }
    }

    public int BlocksLeft
    {
        get
        {
            return _BlocksLeft;
        }

        set
        {
            _BlocksLeft = value;
            Debug.Log("Blocks left: " + _BlocksLeft);
        }
    }

    public bool IsLevelWon
    {
        get
        {
            return _IsLevelWon;
        }

        set
        {
            _IsLevelWon = value;
        }
    }

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        Setup();
    }

    public void Setup()
    {
        _CurrentLevel = 0;
        _LoaderManager = gameObject.GetComponent("LevelLoaderManager") as LevelLoaderManager;
    }


    // Use this for initialization
    void Start()
    {
        _GameStarted = false;
        _IntroComplete = false;
        _IsLevelWon = false;
        PrepareLevel();
    }

    // Update is called once per frame
    void Update()
    {

        if (!_GameStarted && _IntroComplete)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                _GameStarted = true;
                StartGame();
            }
        }
        if (_BlocksLeft == 0)
        {
            // End Level
            _CurrentLevel++;
            _IsLevelWon = true;
        }
    }

    public void FinishLevel()
    {

    }

    public void IsLevelLoaded(bool status)
    {
        _IntroComplete = status;
    }

    public void PrepareLevel()
    {
        _LoaderManager.BuildLevel(_CurrentLevel);
        _IsLevelWon = false;
    }

    public void StartGame()
    {
        foreach (GameObject objectToActivate in objectsToActivate)
        {
            Debug.Log(objectToActivate);
            foreach (MonoBehaviour script in objectToActivate.GetComponents<MonoBehaviour>())
            {
                script.enabled = true;
            }
        }
    }

    public void EndLevel()
    {

    }

    public void EndGame()
    {
    }

    public void ChangeLevel()
    {

    }

    public void PlayLevelWonOutro()
    {

    }
}

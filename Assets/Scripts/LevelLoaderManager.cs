/// LevelLoaderManager.cs
/// Manages Level loading
/// Author: Jose A. Ciccio

using UnityEngine;
using System.Collections;

public class LevelLoaderManager: MonoBehaviour {


    public GameObject _FirstTileGuide;
    public GameObject _BoxPrefab;
    public GameObject _BlocksContainer;
    const float tileSize = 0.75f;
    private int tileRowCount = 10;
    private int tileColumnCount = 11;

    private float _DelayTime;

    private string[][,] _MazeArray = new string[3][,];
    private int _AnimationsRunning = 0;
    private int _PieceCounter = 0;

    void Awake()
    {
        // TODO CHANGE THIS TO LOAD FROM FILE
        // X Stands for Block in Breakout
        string[,] maze = { { "X","X","X","X","X","X","X","X","X","X","X"},
                            { "X","X","X","X","X","X","X"," ","X","X","X"},
                            { "X"," ","X"," ","X"," "," "," "," ","X","X"},
                            { "X","X","X"," ","X"," ","X"," ","X","X","X"},
                            { "X"," "," "," ","X","X","X"," ","X","X","X"},
                            { "X"," ","X","X","X","X","X"," ","X","X","X"},
                            { " "," "," "," "," "," ","X","X","X","X","X"},
                            { " "," "," "," "," "," "," "," "," ","X","X"},
                            { " "," "," "," "," "," "," "," "," "," ","X"},
                            { " "," "," "," "," "," "," "," "," "," "," "} };

    _MazeArray[0] = maze;

    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void BuildLevel(int level)
    {
        GameObject levelFloor = GameObject.Find("Floor");
        float xPos = _FirstTileGuide.transform.position.x;
        float yPos = _FirstTileGuide.transform.position.y;
        float zPos = _FirstTileGuide.transform.position.z;

        int pieceCounter = 0;
        for (int i = 0; i < tileRowCount; i++)
        {// Y Context
            for (int j = 0; j < tileColumnCount; j++)
            { // X Context
                if (!_MazeArray[level][i, j].Equals(" "))
                    _PieceCounter++;
            }
        }
        GameManager.instance.BlocksLeft = _PieceCounter;


        for (int i = 0; i < tileRowCount; i++)
        {// Y Context
            for (int j = 0; j < tileColumnCount; j++)
            { // X Context

                if (_MazeArray[level][i, j].Equals("X"))
                {
                    GameObject box = (GameObject)GameObject.Instantiate(_BoxPrefab);
                    box.transform.position = new Vector3(xPos , yPos, zPos);
                    box.transform.parent = _BlocksContainer.transform;
                    box.name = "Block";
                    Hashtable ht = new Hashtable();
                    ht.Add("time", 1);
                    ht.Add("delay", _DelayTime);
                    ht.Add("position", new Vector3(xPos + j * 0.85f, yPos - i * 0.85f, zPos));
                    ht.Add("oncomplete", "OnWallPlaced");
                    ht.Add("oncompletetarget",this.gameObject);
                    iTween.MoveTo(box, ht);
                    _DelayTime += 0.05f;

                }
            }
        }
    }


    public void OnWallPlaced()
    {
        _PieceCounter--;
        if (_PieceCounter == 0)
            GameManager.instance.IsLevelLoaded(true);
    }
}

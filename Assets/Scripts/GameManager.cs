using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject StartingPlayer;
    private GameObject CurrentPlayer;

    private  List<GameObject> _shapes;
    private int _currentIndex = 0;

	// Use this for initialization
	void Awake ()
    {
        CurrentPlayer = StartingPlayer;

        _shapes = new List<GameObject>();
        //get all the shapes
        foreach (var shape in FindObjectsOfType<Shape>())
        {
            _shapes.Add(shape.transform.parent.gameObject);
        }
	}
	
	// Update is called once per frame
	void Update () {

	}

    public void SetCurrentPlayer(GameObject player)
    {
        CurrentPlayer = player;
    }

    public bool IsCurrentPlayer(GameObject gameObject)
    {
        return CurrentPlayer == gameObject;
    }

    public ShapeType GetCurrentShapeType()
    {
        return CurrentPlayer.transform.GetChild(0).GetComponent<Shape>().Type;
    }

    public List<GameObject> GetShapes()
    {
        return _shapes;
    }
}

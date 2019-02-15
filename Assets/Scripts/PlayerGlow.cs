using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGlow : MonoBehaviour {

    public float Speed = 2.0f;
    public Color HighlightColour;

    private Color startColor;
    private Material material;
    private GameManager gameManager;

    private Shape shape;

    private void Awake()
    {
        shape = transform.GetChild(0).GetComponent<Shape>();

        material = transform.GetChild(0).GetComponent<MeshRenderer>().material;
        startColor = material.color;

        gameManager = FindObjectOfType<GameManager>();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (!gameManager.IsCurrentPlayer(gameObject))
        {
            material.color = startColor;
            return;
        }

        Color lerpedColor;
        lerpedColor = Color.Lerp(HighlightColour, startColor, Mathf.PingPong(Time.time * Speed, 1));
        material.color = lerpedColor;
    }
}

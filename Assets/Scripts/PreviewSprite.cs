using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PreviewSprite : MonoBehaviour {
    
    [System.Serializable]
    public struct ShapeUI
    {
        public ShapeType shapeType;
        public Sprite spritePreview;
        public Material Colour;
    }

    public List<ShapeUI> Shapes;
    private GameManager gameManager;
    private Image image;

	// Use this for initialization
	void Awake () {
        gameManager = FindObjectOfType<GameManager>();
        image = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		foreach(var shape in Shapes)
        {
            if(shape.shapeType == gameManager.GetCurrentShapeType())
            {
                image.sprite = shape.spritePreview;
                image.material = shape.Colour;
            }
        }
	}
}

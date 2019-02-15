using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShapeSelectUI : MonoBehaviour {

    [System.Serializable]
    public struct ShapeUIColours
    {
        public ColourType colourType;
        public Material shapeMaterial;
    }

    [System.Serializable]
    public struct ShapeUISprites
    {
        public ShapeType shapeType;
        public Sprite spritePreview;
    }

    public List<ShapeUIColours> ShapeColours;
    public List<ShapeUISprites> ShapeSprites;

    private Button[] buttons;
    private GameManager gameManager;
    private bool isActive = false;
    private Color[] defaultColours;

    private void Awake()    
    {
        buttons = new Button[8];
        defaultColours = new Color[8];
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i] = transform.GetChild(0).GetChild(i).GetComponent<Button>();
        }

        gameManager = FindObjectOfType<GameManager>();
    }

    // Use this for initialization
    void Start () {
        AssignShapesToUI();
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("ShapeSelect"))
        {
            SetActive(true);
        }
        else
        {
            SetActive(false);
            return;

        }

        for (int i = 0; i < 8; i++)
        {
            buttons[i].GetComponent<Image>().color = defaultColours[i];
        }

        //Keyboard
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
            SetCurrentPlayerShape(4);
        else if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.S))
            SetCurrentPlayerShape(5);
        else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
            SetCurrentPlayerShape(6);
        else if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.W))
            SetCurrentPlayerShape(7);
        else if (Input.GetKey(KeyCode.W))
            SetCurrentPlayerShape(0);
        else if (Input.GetKey(KeyCode.D))
            SetCurrentPlayerShape(1);
        else if (Input.GetKey(KeyCode.S))
            SetCurrentPlayerShape(2);
        else if (Input.GetKey(KeyCode.A))
            SetCurrentPlayerShape(3);

        //controller
        if (Input.GetAxis("DPadY") > 0 && Input.GetAxis("DPadX") > 0)
            SetCurrentPlayerShape(4);
        else if (Input.GetAxis("DPadX") > 0 && Input.GetAxis("DPadY") < 0)
            SetCurrentPlayerShape(5);
        else if (Input.GetAxis("DPadY") < 0 && Input.GetAxis("DPadX") < 0)
            SetCurrentPlayerShape(6);
        else if (Input.GetAxis("DPadX") < 0 && Input.GetAxis("DPadY") > 0)
            SetCurrentPlayerShape(7);
        else if (Input.GetAxis("DPadY") > 0)
            SetCurrentPlayerShape(0);
        else if (Input.GetAxis("DPadX") > 0)
            SetCurrentPlayerShape(1);
        else if (Input.GetAxis("DPadY") < 0)
            SetCurrentPlayerShape(2);
        else if (Input.GetAxis("DPadX") < 0)
            SetCurrentPlayerShape(3);
        
        
    }


    void AssignShapesToUI()
    {
        int i = 0;
        foreach(var shape in gameManager.GetShapes())
        {
            ShapeType shapeType = shape.transform.GetChild(0).GetComponent<Shape>().Type;
            ColourType colourType = shape.transform.GetChild(0).GetComponent<Colour>().colourType;


            buttons[i].GetComponent<Image>().sprite = GetShapeSprite(shapeType);
            buttons[i].GetComponent<Image>().color = GetShapeColour(colourType);
            defaultColours[i] = buttons[i].GetComponent<Image>().color;

            buttons[i].gameObject.SetActive(true);

            int index = i;
            buttons[i].onClick.AddListener((delegate { SetCurrentPlayerShape(index); }));

            i++;
        }
    }

    Color GetShapeColour(ColourType colourType)
    {
        foreach(var colour in ShapeColours)
        {
            if (colourType == colour.colourType)
                return colour.shapeMaterial.color;
        }
        return ShapeColours[0].shapeMaterial.color;
    }

    Sprite GetShapeSprite(ShapeType shapeType)
    {
        foreach(var shape in ShapeSprites)
        {
            if (shapeType == shape.shapeType)
                return shape.spritePreview;
        }
        return ShapeSprites[0].spritePreview;
    }

    void SetCurrentPlayerShape(int index)
    {
        var shapes = gameManager.GetShapes();
        if (index >= shapes.Count)
            return;

        Color lerpedColor;
        Color dark = new Color(.4f, .4f, .4f);
        lerpedColor = Color.Lerp(dark, defaultColours[index], Mathf.PingPong(Time.time * 2.0f, 1));
        buttons[index].GetComponent<Image>().color = lerpedColor;

        GameObject shape = shapes[index];
        if (shape != null)
        {
            gameManager.SetCurrentPlayer(shape);
        }
    }

    void SetActive(bool active)
    {
        if(active)
        {
            active = true;
            transform.GetChild(0).gameObject.SetActive(true);
        }
        else
        {
            active = false;
            transform.GetChild(0).gameObject.SetActive(false);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeCheck : MonoBehaviour
{
    
    bool ContainsShape = false;

    public ShapeType shapeType;
    public ColourType colour;
    public GameObject ButtonLightObject;

    private Light ButtonLight;

    public bool GetContainsShape()
    {
        return ContainsShape;
    }

    private void Awake()
    {
        SpawnLight();
    }

    // Update is called once per frame
    void Update ()
    {
        
	}

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Shape"))
        {
            if (other.gameObject.GetComponent<Shape>().Type == shapeType && other.gameObject.GetComponent<Colour>().colourType == colour)
            {
                ContainsShape = true;
            }
           
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Shape shape = other.GetComponent<Shape>();
        Colour _colour = other.GetComponent<Colour>();

        if (shape == null || (shape.Type != shapeType && _colour.colourType != colour))
            return;

        ChangeLightColour(transform.GetChild(1).GetComponent<MeshRenderer>().material.color);
        ButtonLight.gameObject.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        ContainsShape = false;
        ButtonLight.gameObject.SetActive(false);
    }

    void SpawnLight()
    {
        var gameObject = Instantiate(ButtonLightObject, transform);
        ButtonLight = gameObject.GetComponent<Light>();
        ButtonLight.gameObject.SetActive(false);
        ButtonLight.intensity = 4.0f;

        Vector3 pos = gameObject.transform.position;
        pos.y = .5f;
        gameObject.transform.position = pos;
    }

    void ChangeLightColour(Color color)
    {
        ButtonLight.color = color;
    }

}

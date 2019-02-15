using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeDoor : MonoBehaviour {

    public GameObject Door;
    public Material NewDoorMat;
    public ColourType Col;
    public GameObject ButtonLightObject;

    private Light ButtonLight;
    
    private void OnTriggerEnter(Collider other)
    {
        Material temp = Door.GetComponent<Renderer>().material;
        Door.GetComponent<Renderer>().material = NewDoorMat;
        NewDoorMat = temp;
        IgnoreColourType(Col);
        ColourType tempShape = Door.GetComponent<Door>().colour;
        Door.GetComponent<Door>().colour = Col;
        Col = tempShape;
        Material temp2 = gameObject.GetComponent<Renderer>().material;
        gameObject.GetComponent<Renderer>().material = Door.GetComponent<Door>().buttonColour;
        Door.GetComponent<Door>().buttonColour = temp2;

        GetComponent<AudioSource>().Play();

        ButtonLine line = GetComponent<ButtonLine>();
        if (line != null)
        {
            line.SetColour(GetComponent<MeshRenderer>().material);
        }

        //set the color of the light
        ChangeLightColour(GetComponent<MeshRenderer>().material.color);
        ButtonLight.gameObject.SetActive(true);
    }
    private void OnTriggerExit(Collider other)
    {
        ButtonLight.gameObject.SetActive(false);
    }


    // Use this for initialization
    void Start ()
    {
        IgnoreColourType(Door.GetComponent<Door>().colour);

        ButtonLine line = GetComponent<ButtonLine>();
        if (line != null)
        {
            line.SetColour(GetComponent<MeshRenderer>().material);
        }
        SpawnLight();
    }

    // Update is called once per frame
    void Update () {
		
	}

    void IgnoreColourType(ColourType type)
    {
        var colours = FindObjectsOfType<Colour>();

        foreach (var col in colours)
        {
            if (col.colourType == type)
            {
                Physics.IgnoreCollision(col.gameObject.GetComponent<Collider>(), Door.GetComponent<Collider>());
            }
            else
            {
                Physics.IgnoreCollision(col.gameObject.GetComponent<Collider>(), Door.GetComponent<Collider>(), false);
            }
        }
    }

    void SpawnLight()
    {
        var gameObject = Instantiate(ButtonLightObject, transform);
        ButtonLight = gameObject.GetComponent<Light>();
        ButtonLight.gameObject.SetActive(false);
    }

    void ChangeLightColour(Color color)
    {
        ButtonLight.color = color;
    }


}
  

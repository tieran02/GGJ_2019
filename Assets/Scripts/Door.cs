using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public ColourType colour;
    public Material buttonColour;


    // Use this for initialization
    void Start()
    {
        IgnoreColourType(colour);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void IgnoreColourType(ColourType type)
    {
        var colours = FindObjectsOfType<Colour>();

        foreach (var col in colours)
        {
            if (col.colourType == type)
            {
                Physics.IgnoreCollision(col.gameObject.GetComponent<Collider>(), GetComponent<Collider>());
            }
            else
            {
                Physics.IgnoreCollision(col.gameObject.GetComponent<Collider>(), GetComponent<Collider>(), false);
            }
        }
    }
}

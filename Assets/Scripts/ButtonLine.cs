using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonLine : MonoBehaviour {

    public GameObject[] Waypoints;
    public float LineWidth = 0.1f;

    private LineRenderer lineRenderer;

    public void SetColour(Material mat)
    {
        lineRenderer.material = mat;
    }

	// Use this for initialization
	void Awake () {
        CreateLines();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void CreateLines()
    {
        GameObject line = new GameObject("Line");
        line.transform.parent = transform;
        lineRenderer = line.AddComponent<LineRenderer>();
        lineRenderer.startWidth = LineWidth;
        lineRenderer.endWidth = LineWidth;
        lineRenderer.generateLightingData = true;

        lineRenderer.positionCount = Waypoints.Length + 1;
        lineRenderer.SetPosition(0, transform.position);
        for (int i = 0; i < Waypoints.Length; i++)
        {
            lineRenderer.SetPosition(i+1, Waypoints[i].transform.position);
        }
    }
}

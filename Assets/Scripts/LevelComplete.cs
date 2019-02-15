using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
    List<HomeCheck> homes;
    public string nextLevel;

    bool FinishedSound = false;
    private void Awake()
    {
        /*
        if(SceneManager.GetActiveScene().buildIndex == 1)
        {
            GetComponent<AudioSource>().Stop();
        }
        */
    }

    // Use this for initialization
    void Start ()
    {
        homes = new List<HomeCheck>();
		foreach(var h in FindObjectsOfType<HomeCheck>())
        {
            homes.Add(h);
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        int i = 0;
        foreach (HomeCheck h in homes)
        {            
            if(h.GetComponent<HomeCheck>().GetContainsShape())
            {
                i++;
            }           
        }
        if (i == homes.Count && !FinishedSound)
        {
            StartCoroutine(NextLevel());

        }
	}

    IEnumerator NextLevel()
    {
        FinishedSound = true;
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(.75f);
        LvlComplete();
    }


    void LvlComplete()
    {
        SceneManager.LoadScene(nextLevel, LoadSceneMode.Single);
    }

}


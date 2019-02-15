using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public GameObject MainMenuPanel;
    public GameObject LevelSelectPanel;
    public GameObject CreditPanel;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ShowLevelSelect()
    {
        MainMenuPanel.SetActive(false);
        CreditPanel.SetActive(false);
        LevelSelectPanel.SetActive(true);
    }

    public void ShowMainMenu()
    {
        LevelSelectPanel.SetActive(false);
        CreditPanel.SetActive(false);
        MainMenuPanel.SetActive(true);
    }

    public void ShowCreditsMenu()
    {
        LevelSelectPanel.SetActive(false);
        MainMenuPanel.SetActive(false);
        CreditPanel.SetActive(true);
    }

    public void LoadLevel(int level)
    {
        SceneManager.LoadScene(level, LoadSceneMode.Single);
    }

    public void CloseGame()
    {
        Application.Quit();
    }
}

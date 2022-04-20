using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    //public Button[] levelButtons;
    public GameObject controlsMenu;
    public GameObject levelSelect;
    public GameObject mainMenu;
    public GameObject optionsMenu;
    public GameObject creditsMenu;

    //private void Start()
    //{
        //int levelAt = PlayerPrefs.GetInt("levelAt", 1);

        //for(int i=0; i<levelButtons.Length; i++)
        //{
           // if(i+1>levelAt)
            //{
              //  levelButtons[i].interactable = false;
            //}
        //}
    //}

    public void PlayGame()
    {
        levelSelect.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void optionsButton()
    {
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }

    public void optionsBackButton()
    {
        optionsMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void creditsButton()
    {
        creditsMenu.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void creditsBackButton()
    {
        creditsMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void controlsButton()
    {
        controlsMenu.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void controlsBackButton()
    {
        controlsMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void level1()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void levelSelectBackButton()
    {
        mainMenu.SetActive(true);
        levelSelect.SetActive(false);
    }

    public void level2()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

    public void level3()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
    }

    public void level4()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 4);
    }

    public void level5()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 5);
    }    
}

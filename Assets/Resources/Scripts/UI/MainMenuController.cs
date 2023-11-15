using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public Button startButton;
    public Button configButton;
    public Button creditsButton;
    public Button exitButton;
    public Button goBack;
    public Button goBack2;

    public GameObject mainMenuPrefab;
    public GameObject configMenuPrefab;
    public GameObject creditsMenuPrefab;
    
    
    private void Start()
    {
        startButton.onClick.AddListener(startGame);
        configButton.onClick.AddListener(viewConfig);
        creditsButton.onClick.AddListener(viewCredits);
        exitButton.onClick.AddListener(exitGame);
        goBack.onClick.AddListener(goBackToMainMenu);
        goBack2.onClick.AddListener(goBackToMainMenu);
    }

    public void startGame()
    {
        SceneManager.LoadSceneAsync("Scenes/MainGame");
    }

    public void viewConfig()
    {
        mainMenuPrefab.SetActive(false);
        configMenuPrefab.SetActive(true);
    }

    public void viewCredits()
    {
        mainMenuPrefab.SetActive(false);
        creditsMenuPrefab.SetActive(true);
    }

    public void goBackToMainMenu()
    {
        creditsMenuPrefab.SetActive(false);
        configMenuPrefab.SetActive(false);
        mainMenuPrefab.SetActive(true);
    }

    public void exitGame()
    {
        Application.Quit();
    }
    
    
}
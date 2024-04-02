using AMVRGames.Singleton;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : Singleton<UIManager>
{
    [Header("UI Options")]
    [SerializeField]
    private float offsetPositionFromPlayer = 1.0f; //How far from the camera

    [SerializeField]
    private GameObject menuContainer; //Canvas with a couple of buttons

    private const string GAME_SCENE_NAME = "CabinEscape"; //Allows us private void restart the scene

    [Header("Events")]
    public Action onGameResumeActionExecuted; //Notifies the GameManager to update class

    private Menu menu; //Referenceing the Menu.cs script

    public void Awake()
    {
        menu = GetComponentInChildren<Menu>(true);

        menu ResumeButton.onClick.AddListener(() =>
        {
            HandleMenuOptions(GameState.Playing);
            onGameResumeActionExecuted?.Invoke();
        });

        menu RestartButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(GAME_SCENE_NAME);
            onGameResumeActionExecuted?.Invoke();
        });
    }

    private void OnEnable()
    {
        //GameManager.Instance.onGamePaused += HandleMenuOptions
    }

    private void OnDisable()
    {

    }

    private void HandleMenuOptions(GameState gameState)
    {
        if (gameState == GameState.Paused) 
        { 
            menuContainer.SetActive(true);
            PlaceMenuInFrontOfPlayer();
        }

        else if (gameState == GameState.PuzzleSolved) 
        {
            menuContainer.SetActive(true);
            menu.ResumeButton.gameObject.SetActive(false);
            menu.SolvedText.gameObject.SetActive(true);
            //PlaceMenuInFrontOfPlayer();
        }

        else 
        { 
            menuContainer.SetActive(false);
        }    
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPageManager : MonoBehaviour
{
    [SerializeField] GameObject MenuScreen;
    [SerializeField] GameObject GameScreen;
    [SerializeField] GameObject WinScreen;
    [SerializeField] GameObject LostScreen;

    private void Start()
    {
        MenuScreen.SetActive(true);
    }
    private void OnEnable()
    {
        GameInstance.Instance.GameStarted += OnGameStarted;
        GameInstance.Instance.Won += OnGameWon;
        GameInstance.Instance.Lost += OnGameLost;
    }
    private void OnDisable()
    {
        GameInstance.Instance.GameStarted -= OnGameStarted;
        GameInstance.Instance.Won -= OnGameWon;
        GameInstance.Instance.Lost -= OnGameLost;
    }
    void OnGameStarted()
    {
        GameScreen.SetActive(true);
        MenuScreen.SetActive(false);
        //GameInstance.Instance.StartGame();
    }
    void OnGameLost()
    {
        GameScreen.SetActive(false);
        LostScreen.SetActive(true);
      
    }
    void OnGameWon()
    {
        GameScreen.SetActive(false);
        WinScreen.SetActive(true);
    }

}

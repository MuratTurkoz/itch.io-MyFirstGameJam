using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameInstance : MonoBehaviour
{
    private static GameInstance _instance;
    public static GameInstance Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameInstance>();
            }
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    public event Action GameStarted;
    public event Action GameEnded;
    public event Action Won;
    public event Action Lost;
    public event Action<int> GoldChanged;
    public event Action<int> LevelChanged;
    public int _gold;
    public int Gold
    {
        get => _gold;
        set
        {
            _gold = value;
            GoldChanged?.Invoke(_gold);
        }
    }
    private int _level;
    public int Level
    {
        get => _level;
        set
        {
            _level = value;
            LevelChanged?.Invoke(_level);
        }
    }
    //public void Lost()
    //{

    //}
    public bool isGameStarted { get; private set; }
    public bool isGameLost { get; private set; }
    public void StartGame()
    {
        isGameStarted = true;
        GameStarted?.Invoke();

    }
    public void EndGame()
    {
        isGameStarted = false;
        GameEnded?.Invoke();
    }
    public void Win()
    {
        Level++;
     EndGame();
        Won?.Invoke();
    }
    public void Lose()
    {
        isGameStarted = false;
        EndGame();
        Lost?.Invoke();

        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] Button startButton;

    private void OnEnable()
    {
        startButton.onClick.AddListener(OnStartGame);
    }
    private void OnDisable()
    {
        startButton.onClick.RemoveListener(OnStartGame);
    }
    void OnStartGame()
    {
        GameInstance.Instance.StartGame();
    }
}

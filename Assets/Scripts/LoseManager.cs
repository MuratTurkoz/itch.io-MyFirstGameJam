using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoseManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Button tryButton;
    private void OnEnable()
    {
        tryButton.onClick.AddListener(OnGameLost);
    }
    private void OnDisable()
    {
        tryButton.onClick.RemoveListener(OnGameLost);
    }
    void OnGameLost()
    {
        GameInstance.Instance.StartGame();
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GoldDisplay : MonoBehaviour
{
    [SerializeField] TMP_Text goldText;
    private void OnEnable()
    {
        GameInstance.Instance.GoldChanged += OnGoldChanged;
        UpdateUI();
    }
    private void OnDisable()
    {
        GameInstance.Instance.GoldChanged -= OnGoldChanged;
    }
    private void OnGoldChanged(int _gold)
    {
        UpdateUI(_gold);
    }
    private void UpdateUI()
    {
        UpdateUI(GameInstance.Instance.Gold);
    }
    private void UpdateUI(int value)
    {
        goldText.text = $"Gold : {value}";
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    public int NumberOfCoins;
    [SerializeField] TextMeshProUGUI _text;
    [SerializeField] GameObject _advButton;

    [DllImport("__Internal")]
    private static extern void AddCoinsExtern(int value);

    private void Start()
    {
        NumberOfCoins = Progress.Instance.PlayerInfo.Coins;
        _text.text = NumberOfCoins.ToString();
        transform.parent = null;
    }

    public void AddOne()
    {
        NumberOfCoins++;
        _text.text = NumberOfCoins.ToString();
    }

    public void SaveToProgress()
    {
       Progress.Instance.PlayerInfo.Coins = NumberOfCoins;
    }

    public void SpendMoney(int value)
    {
        NumberOfCoins -= value;
        _text.text = NumberOfCoins.ToString();
    }

    public void ShowAdvButton()
    {
        AddCoinsExtern(100);
        _advButton.SetActive(false);
    }

    public void AddCoins(int value)
    {
        NumberOfCoins += value;
        _text.text = NumberOfCoins.ToString();
        SaveToProgress();
    }
}

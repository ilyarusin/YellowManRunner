using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] CoinManager _coinManager;

    PlayerModifier _playerModifier;

    [DllImport("__Internal")]
    private static extern void SetToLeaderboard(int value);

    private void Start()
    {
        _playerModifier = FindObjectOfType<PlayerModifier>();
    }
    public void BuyWidth()
    {
        if (_coinManager.NumberOfCoins >= 20)
        {
            _coinManager.SpendMoney(20);
            Progress.Instance.PlayerInfo.Coins = _coinManager.NumberOfCoins;
            Progress.Instance.PlayerInfo.Width += 25;
            _playerModifier.SetWidth(Progress.Instance.PlayerInfo.Width);
        }
    }

    public void BuyHeight() {
        if (_coinManager.NumberOfCoins >= 20)
        {
            _coinManager.SpendMoney(20);
            Progress.Instance.PlayerInfo.Coins = _coinManager.NumberOfCoins;
            Progress.Instance.PlayerInfo.Height += 25;
            SetToLeaderboard(Progress.Instance.PlayerInfo.Height);
            _playerModifier.SetHeight(Progress.Instance.PlayerInfo.Height);    
        }
    }
}

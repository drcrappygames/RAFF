using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPanel : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI _gemsBalanceText;
    [SerializeField] private TMPro.TextMeshProUGUI _coinBalanceText;

    private void Awake()
    {
        WalletController.CoinsBalanceChanged += OnCoinsBalanceChanged;
        WalletController.GemsBalanceChanged += OnGemsBalanceChanged;

    }
    private void OnDisable()
    {
        WalletController.CoinsBalanceChanged -= OnCoinsBalanceChanged;
        WalletController.GemsBalanceChanged -= OnGemsBalanceChanged;
    }
    private void OnCoinsBalanceChanged(int ammount)
    {
        _coinBalanceText.text = ammount.ToString();
    }
    private void OnGemsBalanceChanged(int ammount)
    {
        _gemsBalanceText.text = ammount.ToString();
    }
}

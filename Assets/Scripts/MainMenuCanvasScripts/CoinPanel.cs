using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPanel : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI _coinBalanceText;

    private void Awake()
    {
        WalletController.BalanceChanged += OnBalanceChanged;
    }
    private void OnDisable()
    {
        WalletController.BalanceChanged -= OnBalanceChanged;
    }
    private void OnBalanceChanged(int ammount)
    {
        _coinBalanceText.text = ammount.ToString();
    }
}

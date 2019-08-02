using System;
using UnityEngine;

//Obviously make that class operate on server
public class WalletController : MonoBehaviour
{
    public static WalletController Instance { get; private set; }
    public static event Action<int> BalanceChanged = delegate { };

    public int Coins
    {
        get
        {
            return _coins;
        }
        private set
        {
            _coins = value;
            BalanceChanged(_coins);
        }
    }

    private int _coins;
    private void Start()
    {
        Coins = 50;
    }

    public bool AddCoins(int ammount)
    {
        if (ammount < 0)
            return false;

        Coins += ammount;
        return true;
    }
    public bool RemoveCoins(int ammount)
    {
        if (ammount < 0)
            return false;

        if((Coins - ammount) > 0)
        {
            Coins -= ammount;
            return true;
        }

        return false;
    }
}

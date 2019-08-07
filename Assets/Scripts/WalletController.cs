using System;
using UnityEngine;

//Obviously make that class operate on server
public class WalletController : MonoBehaviour
{
    public static WalletController Instance { get; private set; }
    public static event Action<int> CoinsBalanceChanged = delegate { };
    public static event Action<int> GemsBalanceChanged = delegate { };

    public int Coins
    {
        get
        {
            return _coins;
        }
        set
        {
            _coins = value;
            CoinsBalanceChanged(_coins);
        }
    }
    public int Gems
    {
        get
        {
            return _gems;
        }
        set
        {
            _gems = value;
            GemsBalanceChanged(_gems);
        }
    }

    private int _coins;
    private int _gems;
    private void Start()
    {
        Instance = this;
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

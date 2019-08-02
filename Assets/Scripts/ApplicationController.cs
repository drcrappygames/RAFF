using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplicationController : MonoBehaviour
{
    public static ApplicationController Instance { get; private set; }
    public static WalletController Wallet { get; private set; }
    public static SettingsController Settings { get; private set; }

    private void Start()
    {
        DontDestroyOnLoad(this);
        Instance = this;
        Wallet = GetComponent<WalletController>();
    }

    private void OnApplicationQuit()
    {
        SaveLoadController.SaveData();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplicationController : MonoBehaviour
{
    [SerializeField] private GameObject _camera;
    [SerializeField] private GameObject _eventSystem;
    [SerializeField] private GameObject _menu;

    public static ApplicationController Instance { get; private set; }
    public static WalletController Wallet { get; private set; }
    public static SettingsController Settings { get; private set; }

    private void Awake()
    { 
        Instance = this;
    }
    private void Start()
    {
        DontDestroyOnLoad(this);
        DontDestroyOnLoad(_camera);
        DontDestroyOnLoad(_eventSystem);
        DontDestroyOnLoad(_menu);
        Wallet = GetComponent<WalletController>();
        LostPanelController.EndOfGame += OnEndOfGame;
    }
    private void OnDisable()
    {
        LostPanelController.EndOfGame -= OnEndOfGame;
    }

    public void Quit()
    {
        SaveLoadController.SaveData();
        Application.Quit();
    }

    private void OnEndOfGame(int points)
    {
        if(OnlineConnectionController.IsOnline)
            StartCoroutine(OnlineConnectionController.Instance.SendScore(points));
    }
}

using System;
using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private Image _playerSkin;
    [SerializeField] private Image[] _spikesSkins;
    [SerializeField] private RectTransform _screenPanel;
    [SerializeField] private TimerController _timerController;

    public static event Action PlayerFailed = delegate { };
    public static GameController Instance { get; private set; }

    private Vector2 _playerVelocity;

    private void Start()
    {
        Instance = this;
        LostPanelController.GameContinue += OnGameContinue;
        OnLevelStart();
    }
    private void OnDisable()
    {
        LostPanelController.GameContinue -= OnGameContinue;
    }

    public void StartGameplay()
    {
        _timerController.StartTimer();
    }
    public void Failed()
    {
        PlayerFailed();
        PauseGame();
    }

    private void OnLevelStart()
    {
        AdjustSkins();
    }
    private void PauseGame()
    {

    }
    private void OnGameContinue()
    {
        StartCoroutine(UnpauseGame());
    }
    private void OnRestartGame()
    {
        
    }
    private IEnumerator UnpauseGame()
    {
        yield return new WaitForSecondsRealtime(0.5f);
    }
    private void AdjustSkins()
    {
        _playerSkin.sprite = SkinController.PlayerSkins[SkinController.SelectedSkin[(int)SkinSelectionType.Player]];
        _playerSkin.color = SkinController.Colors[SkinController.SelectedColor[(int)SkinSelectionType.Player]];
        foreach (Image i in _spikesSkins)
        {
            i.sprite = SkinController.SpikeSkins[SkinController.SelectedSkin[(int)SkinSelectionType.Spikes]];
            i.color = SkinController.Colors[SkinController.SelectedColor[(int)SkinSelectionType.Spikes]];
        }
    }
}

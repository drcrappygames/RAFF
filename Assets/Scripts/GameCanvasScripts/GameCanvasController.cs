using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCanvasController : MonoBehaviour
{
    public static GameCanvasController Instance { get; private set; }

    [SerializeField] private GameCanvasView _gameCanvasView;

    private void Start()
    {
        Instance = this;
        GetComponent<Canvas>().worldCamera = Camera.main;
        GameController.PlayerFailed += OnPlayerFailed;
        OnLevelStart();
    }

    private void OnLevelStart()
    {
        _gameCanvasView.SlidePanelInVertical(GamePanelType.Game);
    }
    private void OnPlayerFailed()
    {
        _gameCanvasView.SlidePanelInVertical(GamePanelType.LooseScreen);
    }
}

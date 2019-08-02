using System;
using UnityEngine.UI;
using UnityEngine;

public class LostPanelController : MonoBehaviour
{
    public static event Action GameContinue = delegate { };
    public static event Action ExitToMainMenu = delegate { };

    [SerializeField] private GameCanvasView _gameCanvasView;
    [SerializeField] private Button _continueButton;
    [SerializeField] private Button _exitButton;
    [SerializeField] private TMPro.TextMeshProUGUI _pointsCount;

    private void Start()
    {
        _continueButton.onClick.AddListener(OnContinueClick);
        _exitButton.onClick.AddListener(OnExitClick);
        GameController.PlayerFailed += OnPlayerFailed;
    }
    private void OnDisable()
    {
        GameController.PlayerFailed -= OnPlayerFailed;
    }

    private void OnContinueClick()
    {
        _gameCanvasView.SlidePanelOutVertical(GamePanelType.LooseScreen);
        GameContinue();
    }
    private void OnExitClick()
    {
        _gameCanvasView.SlidePanelOutVertical(GamePanelType.LooseScreen);
        ExitToMainMenu();
    }
    private void OnPlayerFailed()
    {
        _pointsCount.text = PointsCounter.Instance.Points.ToString();
    }
}

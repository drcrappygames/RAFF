using System;
using UnityEngine.UI;
using UnityEngine;

public class LostPanelController : MonoBehaviour
{
    public static event Action GameContinue = delegate { };
    public static event Action ExitToMainMenu = delegate { };
    public static event Action Retry = delegate { };
    public static event Action<int> EndOfGame = delegate { };

    [SerializeField] private GameCanvasView _gameCanvasView;
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _exitButton;
    [SerializeField] private TMPro.TextMeshProUGUI _pointsCount;

    private void Start()
    {
        _restartButton.onClick.AddListener(OnRetryClick);
        _exitButton.onClick.AddListener(OnExitClick);
        GameController.PlayerFailed += OnPlayerFailed;
    }
    private void OnDisable()
    {
        GameController.PlayerFailed -= OnPlayerFailed;
    }

    private void OnRetryClick()
    {
        _gameCanvasView.SlidePanelOutVertical(GamePanelType.LooseScreen);
        Retry();
        EndOfGame(PointsController.Instance.Points);
    }
    private void OnExitClick()
    {
        _gameCanvasView.SlidePanelOutVertical(GamePanelType.LooseScreen);
        ExitToMainMenu();
        EndOfGame(PointsController.Instance.Points);
    }
    private void OnPlayerFailed()
    {
        _pointsCount.text = PointsController.Instance.Points.ToString();
    }
}

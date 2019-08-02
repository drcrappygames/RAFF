using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    public static MainMenuController Instance { get; private set; }

    [SerializeField] private MainMenuView _mainMenuView;
    [SerializeField] private Button _settingsButton;
    [SerializeField] private Button _shopButton;
    [SerializeField] private Button[] _backButtons;

    private Vector2 _directionLeft = new Vector2(-1, 1);
    private Vector2 _directionRight = new Vector2(1, 1);
    private void Start()
    {
        Instance = this;
        _settingsButton.onClick.AddListener(OnSettingsClick);
        _shopButton.onClick.AddListener(OnShopClick);
        LostPanelController.ExitToMainMenu += OnExitToMainMenu;
        foreach (Button b in _backButtons)
            b.onClick.AddListener(OnBackClick);
    }

    private void OnSettingsClick()
    {
        _mainMenuView.PanelHorizontalSlideIn(PanelType.Settings, _directionLeft);
        _mainMenuView.PanelHorizontalSlideOut(PanelType.Main, _directionLeft);
        _mainMenuView.PanelHorizontalSlideOut(PanelType.Shop, _directionRight);
    }
    private void OnShopClick()
    {
        _mainMenuView.PanelHorizontalSlideIn(PanelType.Shop, _directionLeft);
        _mainMenuView.PanelHorizontalSlideOut(PanelType.Main, _directionLeft);
        _mainMenuView.PanelHorizontalSlideOut(PanelType.Settings, _directionRight);
    }
    private void OnBackClick()
    {
        _mainMenuView.PanelHorizontalSlideIn(PanelType.Main, _directionRight);
        _mainMenuView.PanelHorizontalSlideOut(PanelType.Shop, _directionRight);
        _mainMenuView.PanelHorizontalSlideOut(PanelType.Settings, _directionRight);
    }
    private void OnExitToMainMenu()
    {
        _mainMenuView.PanelSlideInVertical(PanelType.Main);
        UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync(1);
    }
    public void OnStartClick()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1, UnityEngine.SceneManagement.LoadSceneMode.Additive);
        _mainMenuView.PanelSlideOutVertical(PanelType.Main, -1);
    }
}

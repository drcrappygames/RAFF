using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public static MainMenuController Instance { get; private set; }

    [SerializeField] private MainMenuView _mainMenuView;
    [SerializeField] private Button _settingsButton;
    [SerializeField] private Button _shopButton;
    [SerializeField] private Button[] _backButtons;

    private Vector2 _directionLeft = new Vector2(-1, 1);
    private Vector2 _directionRight = new Vector2(1, 1);

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        _settingsButton.onClick.AddListener(OnSettingsClick);
        _shopButton.onClick.AddListener(OnShopClick);
        LostPanelController.ExitToMainMenu += OnExitToMainMenu;
        LostPanelController.Retry += OnRetry;
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
        Scene temp;
        temp = SceneManager.GetSceneByName("Temp");
        if (!temp.IsValid())
            temp = SceneManager.CreateScene("Temp");

        SceneManager.SetActiveScene(temp);
        SceneManager.UnloadSceneAsync("GameScene");
    }
    private void OnRetry()
    {
        SceneManager.LoadSceneAsync("GameScene");
    }
    public void OnStartClick()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1, UnityEngine.SceneManagement.LoadSceneMode.Additive);
        _mainMenuView.PanelSlideOutVertical(PanelType.Main, -1);
    }
    public void OnShowMessage()
    {
        _mainMenuView.PanelSlideInVertical(PanelType.MessageBox);
    }
    public void OnHideMessage()
    {
        _mainMenuView.PanelSlideOutVertical(PanelType.MessageBox, -1);
    }
}

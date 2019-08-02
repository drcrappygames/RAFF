using UnityEngine.UI;
using UnityEngine;
using DG.Tweening;

public class MainPanelController : MonoBehaviour
{
    [SerializeField] private Button _startButton;
    [SerializeField] private Button _exitButton;

    private void Start()
    {
        _startButton.onClick.AddListener(OnStartClick);
        _exitButton.onClick.AddListener(OnExitClick);
    }

    private void OnStartClick()
    {
        MainMenuController.Instance.OnStartClick();
    }
    private void OnExitClick()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}

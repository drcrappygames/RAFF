using DG.Tweening;
using UnityEngine;

public class GameCanvasView : MonoBehaviour
{
    [Tooltip("Panels order must reflect order in GamePanelType enum, which is : game, looseScreen")]
    [SerializeField] private RectTransform[] _gamePanels;
    [SerializeField] private Vector2 _slideInPosition;
    [SerializeField] private Vector2 _slideOutPosition;
    [SerializeField] private float _verticalAnimationDuration;

    public void SlidePanelInVertical(GamePanelType type)
    {
        _gamePanels[(int)type]?.DOAnchorPos(_slideInPosition, _verticalAnimationDuration);
    }
    public void SlidePanelOutVertical(GamePanelType type)
    {
        _gamePanels[(int)type]?.DOAnchorPos(_slideOutPosition, _verticalAnimationDuration);
    }
}
public enum GamePanelType
{
    Game,
    LooseScreen
}

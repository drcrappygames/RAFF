using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MainMenuView : MonoBehaviour
{
    [Tooltip("Order of panels have to reflect order in PanelType enum, which is : main, settings, shop.")]
    [SerializeField] private RectTransform[] _panels;
    [SerializeField] private Vector2 _slideOutPosition;
    [SerializeField] private Vector2 _slideInPosition;
    [SerializeField] private float _horizontalAnimationDuration;
    [SerializeField] private float _verticalAnimationDuration;

    public void PanelHorizontalSlideIn(PanelType type, Vector2 directionMultipler)
    {
        _panels[(int)type]?.DOAnchorPos(_slideInPosition * directionMultipler, _horizontalAnimationDuration);
    }
    public void PanelHorizontalSlideOut(PanelType type, Vector2 directionMultipler)
    {
        _panels[(int)type]?.DOAnchorPos(_slideOutPosition * directionMultipler, _horizontalAnimationDuration);
    }
    public void PanelSlideOutVertical(PanelType type, int directionMultipler)
    {
        _panels[(int)type]?.DOAnchorPos(new Vector2(0, 1920 * directionMultipler), _verticalAnimationDuration);
    }
    public void PanelSlideInVertical(PanelType type)
    {
        _panels[(int)type]?.DOAnchorPos(_slideInPosition, _verticalAnimationDuration);
    }
}

public enum PanelType
{
    Main,
    Settings,
    Shop
}

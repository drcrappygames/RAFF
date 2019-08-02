using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ShopPanelController : MonoBehaviour
{
    [Header("FocusButtons")]
    [SerializeField] private Button _playerFocusButton;
    [SerializeField] private Button _spikesFocusButton;
    [Header("Colors")]
    [SerializeField] private Color _unpressedColor;
    [SerializeField] private Color _pressedColor;
    [Header("Holders")]
    [SerializeField] private RectTransform _colorButtonsHolder;
    [SerializeField] private RectTransform _playerSkinsButtonsHolder;
    [SerializeField] private RectTransform _spikesSkinsButtonsHolder;
    [SerializeField] private GameObject _playerSkinsRootObject;
    [SerializeField] private GameObject _spikesSkinsRootObject;
    [Header("SelectionMarks")]
    [SerializeField] private Image _colorSelectionMark;
    [SerializeField] private Image _playerSkinSelectionMark;
    [SerializeField] private Image _spikesSkinSelectionMark;

    private List<Image> _colorButtonsImages;
    private List<Image> _playerSkinsButtonImages;
    private List<Image> _spikesSkinsButtonImages;

    private void Start()
    {
        InitializeShopContent();
        _playerFocusButton.onClick.AddListener(OnPlayerFocusClick);
        _spikesFocusButton.onClick.AddListener(OnSpikesFocusClick);
    }

    private void InitializeShopContent()
    {
        _colorButtonsImages = new List<Image>();
        _playerSkinsButtonImages = new List<Image>();
        _spikesSkinsButtonImages = new List<Image>();

        for (int i = 0; i < _colorButtonsHolder.childCount; i++)
        {
            _colorButtonsImages.Add(_colorButtonsHolder.GetChild(i).GetComponent<Image>());
            _colorButtonsImages[i].color = SkinController.Colors[i];
        }
        for (int i = 0; i < _playerSkinsButtonsHolder.childCount; i++)
        {
            _playerSkinsButtonImages.Add(_playerSkinsButtonsHolder.GetChild(i).GetComponent<Image>());
            _playerSkinsButtonImages[i].sprite = SkinController.PlayerSkins[i];
        }
        for (int i = 0; i < _spikesSkinsButtonsHolder.childCount; i++)
        {
            _spikesSkinsButtonImages.Add(_spikesSkinsButtonsHolder.GetChild(i).GetComponent<Image>());
            _spikesSkinsButtonImages[i].sprite = SkinController.SpikeSkins[i];
        }

        UpdateColorSelectionMark();
        UpdatePlayerSkinSelectionMark();
        UpdateSpikesSkinsSelectionMark();
    }

    private void UpdateColorSelectionMark()
    {
        _colorSelectionMark.rectTransform.SetParent(_colorButtonsImages[SkinController.SelectedColor[(int)SkinController.SelectionFocus]].transform);
        _colorSelectionMark.color = _colorButtonsImages[SkinController.SelectedColor[(int)SkinController.SelectionFocus]].color.Invert();
        _colorSelectionMark.rectTransform.anchoredPosition = Vector2.zero;
    }
    private void UpdatePlayerSkinSelectionMark()
    {
        _playerSkinSelectionMark.rectTransform.SetParent(_playerSkinsButtonImages[SkinController.SelectedSkin[(int)SkinSelectionType.Player]].transform);
        _playerSkinSelectionMark.rectTransform.anchoredPosition = Vector2.zero;
    }
    private void UpdateSpikesSkinsSelectionMark()
    {
        _spikesSkinSelectionMark.rectTransform.SetParent(_spikesSkinsButtonImages[SkinController.SelectedSkin[(int)SkinSelectionType.Spikes]].transform);
        _spikesSkinSelectionMark.rectTransform.anchoredPosition = Vector2.zero;
    }

    public void OnAddCoinsClick()
    {

    }
    private void OnPlayerFocusClick()
    {
        SkinController.SelectionFocus = SkinSelectionType.Player;
        UpdateColorSelectionMark();
        _playerFocusButton.GetComponent<Image>().color = _pressedColor;
        _spikesFocusButton.GetComponent<Image>().color = _unpressedColor;
        _spikesSkinsRootObject.SetActive(false);
        _playerSkinsRootObject.SetActive(true);
    }
    private void OnSpikesFocusClick()
    {
        SkinController.SelectionFocus = SkinSelectionType.Spikes;
        UpdateColorSelectionMark();
        _spikesFocusButton.GetComponent<Image>().color = _pressedColor;
        _playerFocusButton.GetComponent<Image>().color = _unpressedColor;
        _spikesSkinsRootObject.SetActive(true);
        _playerSkinsRootObject.SetActive(false);
    }

    public void OnColorButtonClick(int colorIndex)
    {
        SkinController.SelectedColor[(int)SkinController.SelectionFocus] = colorIndex;
        UpdateColorSelectionMark();
    }
    public void OnPlayerSkinButtonClick(int skinIndex)
    {
        SkinController.SelectedSkin[(int)SkinSelectionType.Player] = skinIndex;
        UpdatePlayerSkinSelectionMark();
    }
    public void OnSpikeSkinButtonClick(int skinIndex)
    {
        SkinController.SelectedSkin[(int)SkinSelectionType.Spikes] = skinIndex;
        UpdateSpikesSkinsSelectionMark();
    }
}

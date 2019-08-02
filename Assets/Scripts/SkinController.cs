using System;
using System.Collections.Generic;
using UnityEngine;

public class SkinController : MonoBehaviour
{
    [SerializeField] private List<Sprite> _playerSkins;
    [SerializeField] private List<Sprite> _spikeSkins;
    [SerializeField] private List<Color> _colors;

    public static event Action SkinChanged = delegate { };

    public static List<Sprite> PlayerSkins { get; private set; }
    public static List<Sprite> SpikeSkins { get; private set; }
    public static List<Color> Colors { get; private set; }

    public static int[] SelectedSkin;
    public static int[] SelectedColor;
    public static SkinSelectionType SelectionFocus;

    private void Start()
    {
        PlayerSkins = _playerSkins;
        SpikeSkins = _spikeSkins;
        Colors = _colors;

        SelectedSkin = new int[2];
        SelectedColor = new int[2];
    }
}

public enum SkinSelectionType
{
    Player,
    Spikes
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoadController : MonoBehaviour
{
    //Keys
    public const string SOUND_VOLUME_KEY = "SoundVolume";
    public const string PLAYER_SELECTED_SKIN = "PlayerSelectedSkin";
    public const string PLAYER_SELECTED_COLOR = "PlayerSelectedColor";
    public const string SPIKES_SELECTED_SKIN = "SpikesSelectedSkin";
    public const string SPIKES_SELECTED_COLOR = "SpikesSelectedColor";

    private void Start()
    {
        LoadData();
        StartCoroutine(SyncData());
    }

    private static void LoadData()
    {
        SettingsController.SoundVolume = PlayerPrefs.GetFloat(SOUND_VOLUME_KEY, 1f);
        SkinController.SelectedColor[(int)SkinSelectionType.Player] = PlayerPrefs.GetInt(PLAYER_SELECTED_COLOR, 0);
        SkinController.SelectedSkin[(int)SkinSelectionType.Player] = PlayerPrefs.GetInt(PLAYER_SELECTED_SKIN, 0);
        SkinController.SelectedColor[(int)SkinSelectionType.Spikes] = PlayerPrefs.GetInt(SPIKES_SELECTED_COLOR, 0);
        SkinController.SelectedSkin[(int)SkinSelectionType.Spikes] = PlayerPrefs.GetInt(SPIKES_SELECTED_SKIN, 0);
    }

    public static void SaveData()
    {
        PlayerPrefs.SetFloat(SOUND_VOLUME_KEY, SettingsController.SoundVolume);
        PlayerPrefs.SetInt(PLAYER_SELECTED_COLOR, SkinController.SelectedColor[(int)SkinSelectionType.Player]);
        PlayerPrefs.SetInt(PLAYER_SELECTED_SKIN, SkinController.SelectedSkin[(int)SkinSelectionType.Player]);
        PlayerPrefs.SetInt(SPIKES_SELECTED_COLOR, SkinController.SelectedColor[(int)SkinSelectionType.Spikes]);
        PlayerPrefs.SetInt(SPIKES_SELECTED_SKIN, SkinController.SelectedSkin[(int)SkinSelectionType.Spikes]);
    }

    private IEnumerator SyncData()
    {

        yield return null;
    }
}

using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class SettingsPanelController : MonoBehaviour
{
    [SerializeField] private Slider _volumeSlider;

    private void Start()
    {
        _volumeSlider.onValueChanged.AddListener(OnVolumeChanged);
    }

    private void OnVolumeChanged(float value)
    {
        SettingsController.SoundVolume = value;
    }
}

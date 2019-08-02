using System;
using UnityEngine;

public class SettingsController : MonoBehaviour
{
    public static event Action SettingsChanged = delegate { };

    public static float SoundVolume
    {
        get
        {
            return _soundVolume;
        }
        set
        {
            _soundVolume = value;
            SettingsChanged();
        }
    }
    private static float _soundVolume;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectDisplayer : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI _nextForceText;

    public void DisplayNextForce(float force)
    {
        _nextForceText.text = force.ToString("0");
    }
}

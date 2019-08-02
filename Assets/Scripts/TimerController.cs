using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerController : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI _timerMinutesText;
    [SerializeField] private TMPro.TextMeshProUGUI _timerSecondsText;

    public bool IsTimerActive { get; set; } = true;
    private Coroutine _timerCoroutine;
    private float _startTime = 0f;
    private float _currentTime = 0f;
    public void StartTimer()
    {
        _startTime = Time.time;
        _timerCoroutine = StartCoroutine(Timer());
    }

    public void PauseTimer()
    {

    }

    public void StopTimer()
    {
        StopCoroutine(_timerCoroutine);
        _startTime = 0f;
        _currentTime = 0f;
    }

    private void UpdateTime()
    {
        _currentTime = Time.time - _startTime;
    }
    private void DisplayTimer()
    {
        _timerMinutesText.text = ((int)_currentTime / 60).ToString("0");
        _timerSecondsText.text = (_currentTime % 60f).ToString("0");
    }
    private IEnumerator Timer()
    {
        while(IsTimerActive)
        {
            UpdateTime();
            DisplayTimer();
            yield return new WaitForSeconds(1f);
        }
    }
}

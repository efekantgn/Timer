using System;
using System.Globalization;
using Efekan.Timer;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Timer))]
public class TimerDemo : MonoBehaviour
{
    private Timer timer;
    public Slider slider;
    public TextMeshProUGUI Text;

    private void Awake()
    {
        timer = GetComponent<Timer>();
    }
    private void OnEnable()
    {
        timer.OnTimerStart += TimerStarted;
        timer.OnTimerUpdate += TimerUpdated;
        timer.OnTimerComplete += TimerCompleted;
        slider.onValueChanged.AddListener(UpdateText);
    }
    private void OnDisable()
    {
        timer.OnTimerStart -= TimerStarted;
        timer.OnTimerUpdate -= TimerUpdated;
        timer.OnTimerComplete -= TimerCompleted;
        slider.onValueChanged.RemoveListener(UpdateText);
    }
    private void Start()
    {
        Text.text = slider.value.ToString("N2");
    }
    private void UpdateText(float arg0)
    {
        Text.text = arg0.ToString("N2");
    }
    private void TimerCompleted()
    {
        Debug.Log("Timer Complete");
    }

    private void TimerUpdated(float obj)
    {
        slider.value = obj;
    }

    private void TimerStarted()
    {
        Debug.Log("Timer started");
    }

    public void StartTimer()
    {
        timer.StartTimer(slider.value);
    }
    public void PauseTimer()
    {
        timer.PauseTimer();
    }
    public void ResumeTimer()
    {
        timer.ResumeTimer();
    }
    public void ResetTimer()
    {
        timer.ResetTimer();
    }
}
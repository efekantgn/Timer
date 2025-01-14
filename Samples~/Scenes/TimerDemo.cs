using Efekan.Systems.Timer;
using TMPro;
using UnityEngine;

public class TimerDemo : MonoBehaviour
{
    public ParticleSystem ParticleSystem;
    public TextMeshProUGUI TextMeshProUGUI;
    public Timer Timer;

    private void Awake()
    {
        if (Timer == null)
            Timer = FindObjectOfType<Timer>();

        Timer.OnComplete += () => ParticleSystem.Play();
        Timer.OnUpdate += (remainingSeconds) => TextMeshProUGUI.text = remainingSeconds.ToString("N2");
    }
}
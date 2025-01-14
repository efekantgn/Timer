namespace Efekan.Systems.Timer
{
    using System;
    using UnityEngine;

    public class Timer : MonoBehaviour
    {
        public float Duration { get; private set; } // Timer süresi
        public bool IsRunning { get; private set; } // Timer çalışıyor mu?

        private float timeRemaining; // Kalan süre

        // Action'lar
        public Action OnStart;
        public Action OnPause;
        public Action OnResume;
        public Action OnReset;
        public Action OnComplete;
        public Action<float> OnUpdate; // Kalan süreyi sağlayan güncelleme Action'ı

        /// <summary>
        /// Timer'ı başlatır.
        /// </summary>
        /// <param name="duration">Timer süresi (saniye cinsinden).</param>
        public void StartTimer(float duration)
        {
            Duration = duration;
            timeRemaining = duration;
            IsRunning = true;

            OnStart?.Invoke();
        }

        /// <summary>
        /// Timer'ı duraklatır.
        /// </summary>
        public void PauseTimer()
        {
            if (IsRunning)
            {
                IsRunning = false;
                OnPause?.Invoke();
            }
        }

        /// <summary>
        /// Timer'ı devam ettirir.
        /// </summary>
        public void ResumeTimer()
        {
            if (!IsRunning && timeRemaining > 0)
            {
                IsRunning = true;
                OnResume?.Invoke();
            }
        }

        /// <summary>
        /// Timer'ı sıfırlar.
        /// </summary>
        public void ResetTimer()
        {
            timeRemaining = Duration;
            IsRunning = false;
            OnReset?.Invoke();
        }

        private void Update()
        {
            if (IsRunning && timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;

                // Kalan süreyi güncelle
                OnUpdate?.Invoke(timeRemaining);

                if (timeRemaining <= 0)
                {
                    timeRemaining = 0;
                    IsRunning = false;
                    OnComplete?.Invoke();
                    ResetTimer(); // Timer tamamlanınca sıfırla
                }
            }
        }
    }

}

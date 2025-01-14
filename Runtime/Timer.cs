namespace Efekan.Systems.Timer
{
    using System;
    using UnityEngine;

    public class Timer : MonoBehaviour
    {
        /// <summary>
        /// Timer Süresi
        /// </summary>
        public float Duration { get; private set; }
        /// <summary>
        /// Timer çalışıyor mu?
        /// </summary>
        public bool IsRunning { get; private set; }

        /// <summary>
        /// Kalan süre
        /// </summary>
        private float timeRemaining; // Kalan süre


        /// <summary>
        /// Timer Başladığı zaman ateşleniyor.
        /// </summary> 
        public event Action OnStart;

        /// <summary>
        /// Timer Duraklatıldığı zaman ateşleniyor.
        /// </summary> 
        public event Action OnPause;
        /// <summary>
        /// Timer Devam ettiği zaman ateşleniyor.
        /// </summary> 
        public event Action OnResume;
        /// <summary>
        /// Timer Sıfırlandığı zaman ateşleniyor.
        /// </summary> 
        public event Action OnReset;
        /// <summary>
        /// Timer Tamamlandığı zaman ateşleniyor.
        /// </summary> 
        public event Action OnComplete;
        /// <summary>
        /// Timer Güncellendiği zaman ateşleniyor.
        /// Kalan süreyi döndürüyor.
        /// </summary>
        public Action<float> OnUpdate;

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

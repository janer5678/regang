using System;
using UnityEngine;

namespace GH.Scripts.Timers
{
    public class Timer : MonoBehaviour
    {
        [SerializeField] private float totalTimeSeconds;
        private float _remainingTimeSeconds;
        private Action _onComplete;

        public float RemainingTimeSeconds => _remainingTimeSeconds;
        public bool IsRunning { get; private set; }

        public void Init(float totalTimeSecs, Action onComplete)
        {
            totalTimeSeconds = totalTimeSecs;
            _onComplete = onComplete;
        }

        public void StartTimer()
        {
            _remainingTimeSeconds = totalTimeSeconds;
            IsRunning = true;
        }

        public void PauseTimer()
        {
            IsRunning = false;
        }

        public void StopTimer()
        {
            IsRunning = false;
            _remainingTimeSeconds = 0;
        }

        public void ResetTimer()
        {
            if (IsRunning)
                throw new Exception("The timer must be stopped or paused before resetting.");

            _remainingTimeSeconds = totalTimeSeconds;
            IsRunning = false;
        }

        private void Update()
        {
            if (!IsRunning)
                return;

            _remainingTimeSeconds -= Time.deltaTime;

            if (!(_remainingTimeSeconds <= 0)) return;

            StopTimer();
            _onComplete();
        }
    }
}

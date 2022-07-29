using System;
using UnityEngine;

namespace SGC.VisualDebug
{
    public sealed class DestroyObjectOverTime : MonoBehaviour
    {
        public Action OnDestroy;

        public float DestroyDuration { set => _destroyDuration = value; }

        private float _destroyDuration;
        private float _currentDestroyDuration;

        private void Update() => DestroyTimer();

        private void DestroyTimer()
        {
            _currentDestroyDuration += Time.deltaTime;
            if (_currentDestroyDuration >= _destroyDuration)
            {
                OnDestroy?.Invoke();

                Destroy(gameObject);
            }
        }
    }
}

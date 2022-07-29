using UnityEngine;
using UnityEngine.UI;

namespace SGC.VisualDebug
{
    public sealed class UI_VisualDebug : MonoBehaviour
    {
        private const int MAX_TEXTLOG_TO_SCROLL = 6;
        private const float SCROLLRECT_TO_ADD = 54;

        private const KeyCode HIDE_KEYCODE = KeyCode.F6;

        [Header("Settings")]
        [SerializeField] private CanvasGroup canvasGroup;

        [Space(6)]

        [SerializeField] private GameObject textLogPrefab;
        [SerializeField] private Transform textLogParent;

        [Space(12)]

        [SerializeField] private RectTransform logScrollRect;

        [Space(12)]

        [SerializeField] private Color logColor = Color.green;
        [SerializeField] private Color warningLogColor = Color.yellow;
        [SerializeField] private Color errorLogColor = Color.red;

        private int _currentTextLogs;
        private bool _visualDebugHided;

        private void Start() => SetupUserInterface();

        private void SetupUserInterface()
        {
            HideCanvas(_visualDebugHided);
        }

        private void Update() => HideVisualDebug();

        private void HideVisualDebug()
        {
            if(Input.GetKeyDown(HIDE_KEYCODE))
            {
                _visualDebugHided = !_visualDebugHided;

                HideCanvas(_visualDebugHided);
            }
        }

        private void HideCanvas(bool hide)
        {
            if(hide)
            {
                canvasGroup.alpha = 0;
            }
            else 
            {
                canvasGroup.alpha = 1;
            }
        }

        public void LogMessage(string message)
        {
            var textLog = Instantiate(textLogPrefab, textLogParent).GetComponent<Text>();

            textLog.text = message;
            textLog.color = logColor;

            IncrementScrollRect();
        }

        public void LogMessage(string message, float messageDuration)
        {
            var textLog = Instantiate(textLogPrefab, textLogParent);

            var destroyComponent = textLog.AddComponent<DestroyObjectOverTime>();

            destroyComponent.DestroyDuration = messageDuration;
            destroyComponent.OnDestroy += DecreaseScrollRect;

            var textComponent = textLog.GetComponent<Text>();

            textComponent.text = message;
            textComponent.color = logColor;

            IncrementScrollRect();
        }

        public void LogWarningMessage(string message)
        {
            var textLog = Instantiate(textLogPrefab, textLogParent).GetComponent<Text>();

            textLog.text = message;
            textLog.color = warningLogColor;

            IncrementScrollRect();
        }

        public void LogWarningMessage(string message, float messageDuration)
        {
            var textLog = Instantiate(textLogPrefab, textLogParent);

            var destroyComponent = textLog.AddComponent<DestroyObjectOverTime>();

            destroyComponent.DestroyDuration = messageDuration;
            destroyComponent.OnDestroy += DecreaseScrollRect;

            var textComponent = textLog.GetComponent<Text>();

            textComponent.text = message;
            textComponent.color = warningLogColor;

            IncrementScrollRect();
        }

        public void LogErrorMessage(string message)
        {
            var textLog = Instantiate(textLogPrefab, textLogParent).GetComponent<Text>();

            textLog.text = message;
            textLog.color = errorLogColor;

            IncrementScrollRect();
        }

        public void LogErrorMessage(string message, float messageDuration)
        {
            var textLog = Instantiate(textLogPrefab, textLogParent);

            var destroyComponent = textLog.AddComponent<DestroyObjectOverTime>();

            destroyComponent.DestroyDuration = messageDuration;
            destroyComponent.OnDestroy += DecreaseScrollRect;

            var textComponent = textLog.GetComponent<Text>();

            textComponent.text = message;
            textComponent.color = errorLogColor;

            IncrementScrollRect();
        }

        private void IncrementScrollRect()
        {
            if (_currentTextLogs > MAX_TEXTLOG_TO_SCROLL)
            {
                logScrollRect.sizeDelta += SCROLLRECT_TO_ADD * Vector2.up;
            }
            else { _currentTextLogs++; }
        }

        private void DecreaseScrollRect()
        {
            if (_currentTextLogs > MAX_TEXTLOG_TO_SCROLL)
            {
                logScrollRect.sizeDelta -= SCROLLRECT_TO_ADD * Vector2.up;
            }
            else { _currentTextLogs--; }
        }
    }
}

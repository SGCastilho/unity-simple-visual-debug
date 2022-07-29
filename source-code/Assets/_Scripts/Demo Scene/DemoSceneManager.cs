using UnityEngine;

namespace SGC.VisualDebug
{
    public sealed class DemoSceneManager : MonoBehaviour
    {
        private const KeyCode F1_HOTKEY = KeyCode.F1;
        private const KeyCode F2_HOTKEY = KeyCode.F2;
        private const KeyCode F3_HOTKEY = KeyCode.F3;
        private const KeyCode F4_HOTKEY = KeyCode.F4;
        private const KeyCode F5_HOTKEY = KeyCode.F5;
        private const KeyCode F7_HOTKEY = KeyCode.F7;

        private const float LOG_DURATION = 4f;

        private void Update() => DemoInputs();

        private void DemoInputs()
        {
            if(Input.GetKeyDown(F1_HOTKEY))
            {
                VisualDebug.Log("Log Message Example!");
            }

            if (Input.GetKeyDown(F2_HOTKEY))
            {
                VisualDebug.LogWarning("Log Warning Message Example!");
            }

            if (Input.GetKeyDown(F3_HOTKEY))
            {
                VisualDebug.LogError("Log Error Message Example!");
            }

            if (Input.GetKeyDown(F4_HOTKEY))
            {
                VisualDebug.Log("Log With Seconds Message Example!", LOG_DURATION);
            }

            if (Input.GetKeyDown(F5_HOTKEY))
            {
                VisualDebug.LogWarning("Log Warning With Seconds Message Example!", LOG_DURATION);
            }

            if (Input.GetKeyDown(F7_HOTKEY))
            {
                VisualDebug.LogError("Log Error With Seconds Message Example!", LOG_DURATION);
            }
        }
    }
}

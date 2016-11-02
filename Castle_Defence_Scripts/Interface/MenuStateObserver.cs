using UnityEngine;

namespace Assets.Scripts.Interface
{
    public class MenuStateObserver : MonoBehaviour
    {

        // ReSharper disable once InconsistentNaming
        private MouseLook _cameraLook;
        private MouseLook _characterLook;

        public void Awake()
        {
            _characterLook = GameObject.FindWithTag("Player").gameObject.GetComponent<MouseLook>();
            _cameraLook = GameObject.FindWithTag("MainCamera").gameObject.GetComponent<MouseLook>();
        }

        public void OnEnable()
        {
            Time.timeScale = 0;
            if (_characterLook != null) _characterLook.enabled = false;
            if (_cameraLook != null) _cameraLook.enabled = false;
            Cursor.visible = true;
        }

        public void OnDisable()
        {
            Time.timeScale = 1;

            if (_characterLook != null) _characterLook.enabled = true;
            if (_cameraLook != null) _cameraLook.enabled = true;
            Cursor.visible = false;
        }
    }
}

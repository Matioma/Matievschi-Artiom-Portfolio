using UnityEngine;

namespace Assets.Scripts.Interface
{
    public class NotEnoughMoney : MonoBehaviour
    {
        private float _countDown = 2f;

        public void OnEnable()
        {
            _countDown = 2f;
        }

        public void Update()
        {
            _countDown -= Time.deltaTime;
            if (_countDown < 0)
            {
                gameObject.SetActive(false);
            }
        }
    }
}

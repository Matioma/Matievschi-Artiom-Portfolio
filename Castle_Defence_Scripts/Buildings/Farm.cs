using Assets.Utilities;
using UnityEngine;

namespace Assets.Scripts.Buildings
{
    public class Farm : MonoBehaviour
    {
        private float _timer;

        public void Update()
        {
            _timer -= Time.deltaTime;
            if ( _timer >= 0 )
            {
                return;
            }

            Database.GetValue().Money += Database.GetValue().FarmIncome;
            _timer = 1f;
        }
    }
}

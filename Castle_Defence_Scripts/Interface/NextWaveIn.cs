using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Interface
{
    public class NextWaveIn : MonoBehaviour
    {
        public static float NextWaveTime;

        public void Update()
        {
            gameObject.GetComponent<Text>().text = string.Format(
                "Next wave in:{0:F} sec",
                NextWaveTime > 0 ? NextWaveTime : 0f);
        }
    }
}

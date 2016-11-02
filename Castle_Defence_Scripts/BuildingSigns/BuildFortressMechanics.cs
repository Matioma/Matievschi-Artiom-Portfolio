using UnityEngine;

namespace Assets.Scripts.BuildingSigns
{
    public class BuildFortressMechanics : MonoBehaviour
    {
        public GameObject Fortress;

        public void Start()
        {
            Fortress.gameObject.SetActive(false);
        }
    }
}

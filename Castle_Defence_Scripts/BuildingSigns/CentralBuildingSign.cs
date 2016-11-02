using UnityEngine;

namespace Assets.Scripts.BuildingSigns
{
    public class CentralBuildingSign : MonoBehaviour
    {
        public void OnTriggerEnter(Collider col)
        {
            if ( col.gameObject.tag == "Player" )
            {
                transform.parent.GetComponent<CentralMechanics>().PressButton = true;
            }
        }

        public void OnTriggerExit(Collider col)
        {
            if ( col.gameObject.tag == "Player" )
            {
                transform.parent.GetComponent<CentralMechanics>().PressButton = false;
            }
        }
    }
}

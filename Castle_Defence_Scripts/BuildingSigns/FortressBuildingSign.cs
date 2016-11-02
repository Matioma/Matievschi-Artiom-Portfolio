using Assets.Utilities;
using UnityEngine;

namespace Assets.Scripts.BuildingSigns
{
    public class FortressBuildingSign : MonoBehaviour
    {
        public GameObject FortressBuyMenu;
        private bool _pressButton;

        public void Start()
        {
            gameObject.transform.GetComponent<SphereCollider>().radius =
                Database.GetValue().SignActivationRange;
            FortressBuyMenu = Database.GetValue().FortressBuyMenu;
        }

        public void Update()
        {
            if ( _pressButton )
            {
                if ( Input.GetKey(KeyCode.F) )
                {
                    if ( Database.GetValue().Money >= Database.GetValue().FortressPrice )
                    {
                        Database.GetValue().Money -= Database.GetValue().FortressPrice;
                        transform.parent.GetComponent<BuildFortressMechanics>().Fortress.SetActive(true);
                        FortressBuyMenu.gameObject.SetActive(false);
                        gameObject.SetActive(false);
                        _pressButton = false;
                    }
                    else
                    {
                        Database.SetNotEnoughMoney(true);
                    }
                }
            }

            FortressBuyMenu.SetActive(_pressButton);
        }

        public void OnTriggerEnter(Collider col)
        {
            if ( col.gameObject.tag == "Player" )
            {
                _pressButton = true;
            }
        }

        public void OnTriggerExit(Collider col)
        {
            if ( col.gameObject.tag == "Player" )
            {
                _pressButton = false;
            }
        }
    }
}

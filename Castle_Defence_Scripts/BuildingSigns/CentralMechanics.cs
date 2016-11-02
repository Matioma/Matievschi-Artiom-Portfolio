using Assets.Utilities;
using UnityEngine;

namespace Assets.Scripts.BuildingSigns
{
    public class CentralMechanics : MonoBehaviour
    {
        public GameObject BuildSign;
        public GameObject Farm;
        public GameObject Barracks;
        public GameObject Tower;

        public GameObject CentralBuildingBuyMenu;

        public bool PressButton;

        public void Awake()
        {
            BuildSign = gameObject.transform.GetChild(0).gameObject;
            Barracks = gameObject.transform.GetChild(1).gameObject;
            Farm = gameObject.transform.GetChild(2).gameObject;
            Tower = gameObject.transform.GetChild(3).gameObject;

            CentralBuildingBuyMenu = gameObject.transform.GetChild(4).gameObject;
            CentralBuildingBuyMenu.SetActive(false);

            BuildSign.gameObject.transform.GetComponent<SphereCollider>().radius =
                Database.GetValue().SignActivationRange;
        }

        public void Start()
        {
            Farm.gameObject.SetActive(false);
            Barracks.gameObject.SetActive(false);
            Tower.gameObject.SetActive(false);
        }

        public void Update()
        {
            if ( PressButton )
            {
                if ( Input.GetKey(KeyCode.F) )
                {
                    if ( Database.GetValue().Money >= Database.GetValue().FarmPrice )
                    {
                        Database.GetValue().Money -= Database.GetValue().FarmPrice;
                        Farm.gameObject.SetActive(true);
                        BuildSign.gameObject.SetActive(false);
                        PressButton = false;
                    }
                    else
                    {
                        Database.SetNotEnoughMoney(true);
                    }
                }

                if ( Input.GetKey(KeyCode.B) )
                {
                    if ( Database.GetValue().Money >= Database.GetValue().BarracksPrice )
                    {
                        Database.GetValue().Money -= Database.GetValue().BarracksPrice;
                        Barracks.gameObject.SetActive(true);
                        BuildSign.gameObject.SetActive(false);
                        PressButton = false;
                    }
                    else
                    {
                        Database.SetNotEnoughMoney(true);
                    }
                }
                if ( Input.GetKey(KeyCode.T) )
                {
                    if ( Database.GetValue().Money
                        >= Database.GetValue().TowerPrice )
                    {
                        Database.GetValue().Money -= Database.GetValue().TowerPrice;
                        Tower.gameObject.SetActive(true);
                        BuildSign.gameObject.SetActive(false);
                        PressButton = false;
                    }
                }
            }

            CentralBuildingBuyMenu.SetActive(PressButton);
        }
    }
}

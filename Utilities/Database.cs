using Assets.Scripts;
using UnityEngine;

namespace Assets.Utilities
{
    public class Database
    {
        public static AllObjectParameters GetValue()
        {
            var dataBase = GameObject.FindWithTag("DataBase");
            return dataBase.gameObject.GetComponent<AllObjectParameters>();
        }

        public static void SetNotEnoughMoney(bool activeState)
        {
            GetValue().NotEnoughMoney.SetActive(activeState);
        }
    }
}

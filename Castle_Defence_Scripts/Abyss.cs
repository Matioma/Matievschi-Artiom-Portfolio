using Assets.Scripts.Enemy;
using UnityEngine;
using System.Collections;

namespace Assets.Scripts
{
    public class Abyss : MonoBehaviour
    {

        public void OnTriggerEnter(Collider col) //if collider is gameOBject with tag enemy deal damageto this object
        {
            if (col.gameObject.tag == "Enemy")
            {
                col.gameObject.GetComponent<EnemyUnit>().EnemyHealth = 0;
            }
            if (col.gameObject.tag == "Player")
            {
                col.gameObject.GetComponent<MainCharacter>().Health = 0;
            }
        }
    }
}

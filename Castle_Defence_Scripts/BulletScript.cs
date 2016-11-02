using Assets.Scripts.Enemy;
using Assets.Utilities;
using UnityEngine;

namespace Assets.Scripts
{
    public class BulletScript : MonoBehaviour
    {
        private int _bulletDamage;

        public void Awake()
        {
            _bulletDamage = Database.GetValue().ArrowDamage;
        }

        public void OnCollisionEnter(Collision col)//if collider is gameOBject with tag enemy deal damageto this object
        {
            if ( col.gameObject.tag == "Enemy" )
            {
                col.gameObject.GetComponent<EnemyUnit>().EnemyHealth -= _bulletDamage;
            }
            if ( col.gameObject.tag == "Terrain" )
            {
                gameObject.SetActive(false);
            }
            // else
            // {
            //     gameObject.SetActive(false);
            // }
            //Debug.Log(col.gameObject.name);
        }
    }
}

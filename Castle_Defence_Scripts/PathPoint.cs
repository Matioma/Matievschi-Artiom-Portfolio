using Assets.Scripts.Enemy;
using UnityEngine;

namespace Assets.Scripts
{
    public class PathPoint : MonoBehaviour
    {
        const int ArraySize = 13;

        public void OnTriggerEnter(Collider col)
        {
            if ( col.gameObject.tag != "Enemy" )
            {
                return;
            }

            if ( col.gameObject.GetComponent<EnemyUnit>().PathPointIndex < ArraySize )
            {
                col.gameObject.GetComponent<EnemyUnit>().PathPointIndex++;
            }
        }
    }
}

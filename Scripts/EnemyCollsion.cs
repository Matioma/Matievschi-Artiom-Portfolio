using UnityEngine;
using System.Collections;

public class EnemyCollsion : MonoBehaviour
{
    private void OnTriggerEnter(Collider col)
    {
        if ( col.tag == "Enemy" )
        {
            Movement.Defeat = true;
            Movement.referenceMovementSpeed = 0f;
            DefeatMenu.Defeat = true;
        }
    }
}

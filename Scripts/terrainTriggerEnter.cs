using UnityEngine;
using System.Collections;

public class terrainTriggerEnter : MonoBehaviour
{

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Player" )
        {
            Movement.interactionWithTerrain = true;
        }
    }
}
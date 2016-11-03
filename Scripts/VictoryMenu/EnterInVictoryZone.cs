using UnityEngine;
using System.Collections;

public class EnterInVictoryZone : MonoBehaviour
{

    private bool entered;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            MenuSetActive.Victory = true;
            Movement.referenceMovementSpeed = 0f;
        }
    }
}

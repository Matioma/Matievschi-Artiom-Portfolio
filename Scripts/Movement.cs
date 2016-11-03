using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{
    private Vector3 initailPosition;
    public float movementSpeed,lateralMovement,jump;
    public static float referenceMovementSpeed;
    public static bool interactionWithTerrain;
    public static bool Defeat;

    public static bool restartButtonPressed;
	void Start ()
	{
	    restartButtonPressed = false;
	    Defeat = false;
	    initailPosition = transform.position;
	    interactionWithTerrain = true;
	    referenceMovementSpeed = movementSpeed;
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if (Defeat == true)
	    {
	        Time.timeScale = 0;
	    }
        ConstantMovement();


	    if (Input.GetKey(KeyCode.A))
	    {
           rigidbody.AddRelativeForce(-lateralMovement,0,0);
	    }
        if ( Input.GetKey(KeyCode.D) )
        {
            rigidbody.AddRelativeForce(lateralMovement, 0, 0);
        }
	    if ( Input.GetKeyDown(KeyCode.Space) && (interactionWithTerrain == true))
	    {
	        interactionWithTerrain = false;
	        rigidbody.AddForce(transform.up * jump);
	    }

	    if (restartButtonPressed == true)
	    {
            transform.position = new Vector3(initailPosition.x, initailPosition.y, initailPosition.z);
            interactionWithTerrain = true;
            Defeat = false;
            Time.timeScale = 1;
            referenceMovementSpeed = movementSpeed;
	        restartButtonPressed = false;
	    }
    }

    private void ConstantMovement()
    {
        transform.Translate(0, 0, referenceMovementSpeed);
    }
}

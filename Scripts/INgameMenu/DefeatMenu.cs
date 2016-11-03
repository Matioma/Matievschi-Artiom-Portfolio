using UnityEngine;
using System.Collections;

public class DefeatMenu : MonoBehaviour
{
    public GameObject Menu, RestartButton, MEnuButton;

    public static bool Defeat;
	// Use this for initialization
	void Start ()
	{
	    Defeat = false;
        Menu.gameObject.SetActive(Defeat);
        RestartButton.gameObject.SetActive(Defeat);
        MEnuButton.gameObject.SetActive(Defeat);
    }
	
	// Update is called once per frame
	void Update ()
    {
        if( Defeat == true)
        {   
            Menu.gameObject.SetActive(Defeat);
            RestartButton.gameObject.SetActive(Defeat);
            MEnuButton.gameObject.SetActive(Defeat);
        }
        else
        {
            Menu.gameObject.SetActive(Defeat);
            RestartButton.gameObject.SetActive(Defeat);
            MEnuButton.gameObject.SetActive(Defeat);
        }
    }
	
}

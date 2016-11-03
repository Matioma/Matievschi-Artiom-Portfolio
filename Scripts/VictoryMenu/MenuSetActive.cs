using UnityEngine;
using System.Collections;

public class MenuSetActive : MonoBehaviour
{
    public static bool Victory;
    public GameObject Menu, BackToMainMenu,Restart;

	void Start ()
    {
        Menu.gameObject.SetActive(Victory);
	    BackToMainMenu.gameObject.SetActive(Victory);
        Restart.gameObject.SetActive(Victory);
    }
	void Update ()
    {
        Menu.gameObject.SetActive(Victory);
        BackToMainMenu.gameObject.SetActive(Victory);
        Restart.gameObject.SetActive(Victory);
    }
}

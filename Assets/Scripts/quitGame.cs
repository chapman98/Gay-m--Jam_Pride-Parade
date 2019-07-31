using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class quitGame : MonoBehaviour {

    public void OnMouseClick()
    {
        //Debug.Log("Application Exited");
        Application.Quit();
    }
}

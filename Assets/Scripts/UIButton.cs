using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButton : MonoBehaviour {

    public void OnMouseClick(string SceneName)
	{
        /*
		if (SceneName == "R-Bar" || SceneName == "Beach" || SceneName == "The Level" || SceneName == "uni" || SceneName == "Pier")
		{
			global.DaysRemaining--;
			PlayerPrefs.SetInt("rDays", global.DaysRemaining);
			Debug.Log(global.DaysRemaining);
		}
        */
        SceneManager.LoadScene(SceneName, mode: LoadSceneMode.Single); //Loads game when menu button is pressed
        Debug.Log(global.people);
    }
}

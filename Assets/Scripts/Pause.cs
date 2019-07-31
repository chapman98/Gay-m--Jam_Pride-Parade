using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {
    GameObject[] pause;
	GameObject[] map_invent;
	GameObject[] flag_invent;

	GameObject[] Tarot;
	GameObject[] Heels;
	GameObject[] Dounut;
    
	// lesbian, gay, bisexual, transexual, asxual
	GameObject[] lesbian;
	GameObject[] gay;
	GameObject[] bisexual;
	GameObject[] transexual;
	GameObject[] asxual;

	// Use this for initialization
	void Start () {

        Time.timeScale = 1;
        pause = GameObject.FindGameObjectsWithTag("pause");
		map_invent = GameObject.FindGameObjectsWithTag("Inventory panel");
		flag_invent = GameObject.FindGameObjectsWithTag("Flags pannel");

		Tarot = GameObject.FindGameObjectsWithTag("Tarot Card");
		Heels = GameObject.FindGameObjectsWithTag("Heels");
		Dounut = GameObject.FindGameObjectsWithTag("Dounut");

		lesbian = GameObject.FindGameObjectsWithTag("lesbian");
		gay = GameObject.FindGameObjectsWithTag("gay");
		bisexual = GameObject.FindGameObjectsWithTag("bisexual");
		transexual = GameObject.FindGameObjectsWithTag("transexual");
		asxual = GameObject.FindGameObjectsWithTag("asxual");

		hide(pause);
		hide(flag_invent);
    }

    // Update is called once per frame
    void Update()
    {
        //uses the p button to pause and unpause the game
		if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
                show(pause);
            }
            else if (Time.timeScale == 0)
            {
                Time.timeScale = 1;
                hide(pause);
            }

        }
		//Debug.Log("hey: " + PlayerPrefs.GetInt("Tarot"));
		if (PlayerPrefs.GetInt("Tarot") == 0 || PlayerPrefs.GetInt("Tarot") == 2) 
		{
			//Debug.Log("hey");
			hide(Tarot);
		}
		if (PlayerPrefs.GetInt("Heels") == 0 || PlayerPrefs.GetInt("Heels") == 2) 
		{
			hide(Heels);
		}
		if (PlayerPrefs.GetInt("Donut") == 0 || PlayerPrefs.GetInt("Donut") == 2) 
		{
			hide(Dounut);
		}



		if (PlayerPrefs.GetInt("Tarot") == 1) 
		{
			show(Tarot);
		}
		if (PlayerPrefs.GetInt("Heels") == 1) 
		{
			show(Heels);
		}
		if (PlayerPrefs.GetInt("Donut") == 1) 
		{
			show(Dounut);
		}




		if (PlayerPrefs.GetInt("Homosexual") == 0) 
		{
			//Debug.Log("hello");
			hide(gay);
		}
		if (PlayerPrefs.GetInt("Bisexual") == 0) 
		{
			hide(bisexual);
		}
		if (PlayerPrefs.GetInt("Transgender") == 0) 
		{
			hide(transexual);
		}
		
		if (PlayerPrefs.GetInt("Asexual") == 0) 
		{
			hide(asxual);
		}
		if (PlayerPrefs.GetInt("Lesbian") == 0) 
		{
			hide(lesbian);
		}


		if (PlayerPrefs.GetInt("Homosexual") == 1) 
		{
			show(gay);
		}
		if (PlayerPrefs.GetInt("Bisexual") == 1) 
		{
			show(bisexual);
		}
		if (PlayerPrefs.GetInt("Transgender") == 1) 
		{
			show(transexual);
		}
		
		if (PlayerPrefs.GetInt("Asexual") == 1) 
		{
			show(asxual);
		}
		if (PlayerPrefs.GetInt("Lesbian") == 1) 
		{
			show(lesbian);
		}






    }

	public void show(GameObject[] change)
    {
		foreach (GameObject g in change)
        {
            g.SetActive(true);
        }
    }

    //hides objects with ShowOnPause tag
	public void hide(GameObject[] change)
    {
		foreach (GameObject g in change)
        {
            g.SetActive(false);
        }
    }

	public void OnMouseClick(string tag)
	{
		hide(map_invent);
		hide(flag_invent);

		if(tag == "invent")
		{
			show(map_invent);
		}

		if(tag == "flag")
		{
			show(flag_invent);
		}

		if(tag == "play")
		{
			Time.timeScale = 1;
			hide(pause);
			show(map_invent);
		}
	}

}

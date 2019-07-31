using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadMap : MonoBehaviour
{
	GameObject[] map;
    // Start is called before the first frame update
    void Start()
    {
		map = GameObject.FindGameObjectsWithTag("map");
		Time.timeScale = 1;
		hideMap();
	}
	
    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown(KeyCode.M))
		{
			if (Time.timeScale == 1)
			{
				Time.timeScale = 0;
				showMap();
			}
			else if (Time.timeScale == 0)
			{
				Time.timeScale = 1;
				hideMap();
			}
		}

	}
		
		public void showMap()
		{
			foreach (GameObject g in map)
			{
				g.SetActive(true);
			}
		}
		
		//hides objects with ShowOnPause tag
	public void hideMap()
	{
			foreach (GameObject g in map)
		{
				//Debug.Log("test");
				g.SetActive(false);
		}
	}


}

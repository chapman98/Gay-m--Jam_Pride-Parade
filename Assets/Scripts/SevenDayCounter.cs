using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SevenDayCounter : MonoBehaviour {
    // Start is called before the first frame update
    
    //public Text dayTime;
	public static int timeFramesLeft;

    void Start() {
        Debug.Log("Saturday Morning");
    }

    // Update is called once per frame
    void Update(){
        if(Input.GetKeyDown(KeyCode.Space)) {
            timeFramesLeft = PlayerPrefs.GetInt("rDays");
            switch (timeFramesLeft) {
                case 7:
                    Debug.Log("Saturday");
                    break;
                case 6:
                    Debug.Log("Sunday");
                    break;
                case 5:
                    Debug.Log("Monday");
                    break;
                case 4:
                    Debug.Log("Tuesday");
                    break;
                case 3:
                    Debug.Log("Wednesday");
                    break;
                case 2:
                    Debug.Log("Thursday");
                    break;
                case 1:
                    Debug.Log("Wednesday");
                    break;
                case 0:
                    Debug.Log("PRIDE!!!!!");
                    break;
            }
  
        }
        
    }
}

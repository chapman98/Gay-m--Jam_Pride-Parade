using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class global : MonoBehaviour
{
    static global instance = null;
    string playerName;
    public static int DaysRemaining;
    [SerializeField] Toggle toggleHe;
    [SerializeField] Toggle toggleShe;
    [SerializeField] Toggle toggleThem;
    [SerializeField] InputField NameField;
    //[SerializeField] int example;
    // Invetory Varibles
    //private Sprite[] sprites;
    // Items (cards, Heels, Donuts)
    public static bool[] inventory = /*{ true, true, true };*/{ false, false, false };
    // Flags (lesbian, gay, bisexual, transexual, asexual)
    public static bool[] flags = /*{ true, true, true, true, true };*/{ false, false, false, false, false };
    // People Met (Lucy, Millie, Michal, Lucas) People Convinced (Matt, Emily)
    public static bool[] people = /*{ true, true, true, true, true, true};*/{ false, false, false, false, false, false };
    // END

    void setSpokenTo()
    {
        PlayerPrefs.SetInt("Michael", 0);
        PlayerPrefs.SetInt("Matt", 0);
        PlayerPrefs.SetInt("Millie", 0);
        PlayerPrefs.SetInt("Lucy", 0);
        PlayerPrefs.SetInt("Charly", 0);
        PlayerPrefs.SetInt("James", 0);
        PlayerPrefs.SetInt("Sammy", 0);
        PlayerPrefs.SetInt("Lucas", 0);
        PlayerPrefs.SetInt("Emily", 0);
        PlayerPrefs.SetInt("Zach", 0);
    }

    void setInventory()
    {
        PlayerPrefs.SetInt("Heels", 0);
        PlayerPrefs.SetInt("Tarot", 0);
        PlayerPrefs.SetInt("Donut", 0);
    }

    void setFlags()
    {
        PlayerPrefs.SetInt("Homosexual", 0);
        PlayerPrefs.SetInt("Bisexual", 0);
        PlayerPrefs.SetInt("Transgender", 0);
        PlayerPrefs.SetInt("Asexual", 0);
        PlayerPrefs.SetInt("Lesbian", 0);
    }

    public static bool checkFlags()
    {
        //Debug.Log("Checking flags");
        int numFlags = 0;
        if (PlayerPrefs.GetInt("Homosexual") == 1)      numFlags++;
        if (PlayerPrefs.GetInt("Bisexual") == 1)        numFlags++;
        if (PlayerPrefs.GetInt("Transgender") == 1)     numFlags++;
        if (PlayerPrefs.GetInt("Lesbian") == 1)         numFlags++;
        if (PlayerPrefs.GetInt("Asexual") == 1)         numFlags++;
        PlayerPrefs.SetInt("NumFlags", numFlags);
        return numFlags > 2 ? true : false;
    }
    // Use this for initialization
    void Start()
    {
		setSpokenTo();
		setInventory();
		setFlags();

        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }
        playerName = "";
        DaysRemaining = 7;
		DaysRemaining++; //used to allow for level switch to be correct.
        toggleHe.onValueChanged.AddListener(delegate   { updatePronouns(); });
        toggleShe.onValueChanged.AddListener(delegate  { updatePronouns(); });
        toggleThem.onValueChanged.AddListener(delegate { updatePronouns(); });
        NameField.onValueChanged.AddListener(delegate { updateName(); });
        PlayerPrefs.SetInt("rDays", DaysRemaining);
        setSpokenTo();
        // Inventory Setup
        // END
    }



    void updatePronouns()
    {
        if (toggleHe.isOn)
        {
            PlayerPrefs.SetString("Pronoun", "He/Him");
            //Debug.Log("He");
        }
        else if (toggleShe.isOn)
        {
            PlayerPrefs.SetString("Pronoun", "She/Her");
            //Debug.Log("She");
        }
        else if (toggleThem.isOn)
        {
            PlayerPrefs.SetString("Pronoun", "They/Them");
            //Debug.Log("Them");
        }
        //Debug.Log(PlayerPrefs.GetString("Pronoun"));
    }

    void updateName() {
        playerName = NameField.text;
        PlayerPrefs.SetString("Name", playerName);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) { Debug.Log(PlayerPrefs.GetString("Name")); }
        if (Input.GetKeyDown(KeyCode.O)) { Debug.Log(PlayerPrefs.GetInt("rDays")); }
        if (Input.GetKeyDown(KeyCode.I)) { Debug.Log(PlayerPrefs.GetString("Pronoun")); }
        checkFlags();
        // Used to test inventory access
        //UpdateInventory();
    }

    public static bool HasThreeFlags() {
        int count = 0;
        for (int i = 0; i < flags.Length; i++) {
            if (flags[i] == true) {
                count++;
            }
        }
        if (count >= 3) {
            return true;
        }
        return false;
    }

    public static bool ADDThing(int item, string type)
    {
        type = type.ToLower();
        if (type.Equals("item"))
        {
            if (inventory[item] == false)
            {
                inventory[item] = true;
                return true;
            }
        } else if (type.Equals("flag")) {
            if (flags[item] == false)
            {
                flags[item] = true;
                return true;
            }
        } else if (type.Equals("person")) {
            if (people[item] == false)
            {
                people[item] = true;
                Debug.Log(people[item]);
                return true;
            }
        }
        return false;
    }

    public static bool exist(int item, string type)
    {
        type = type.ToLower();
        if (type.Equals("item"))
        {
            for (int i = 0; i < inventory.Length; i++)
            {
                if (inventory[item] == true)
                {
                    return true;
                }
            }
        }
        else if (type.Equals("flag"))
        {
            for (int i = 0; i < flags.Length; i++)
            {
                if (flags[item] == true)
                {
                    return true;
                }
            }
        }
        else if (type.Equals("person"))
        {
            for (int i = 0; i < people.Length; i++)
            {
                if (people[item] == true)
                {
                    return true;
                }
            }
        }
        return false;
    }

    public static bool REMThing(int item, string type)
    {
		//Debug.Log(item);
		//Debug.Log(type);

		type = type.ToLower();
        if (type.Equals("item"))
        {
            if (inventory[item] == true)
            {
                inventory[item] = false;
				Debug.Log("done");
                return true;
            }
        }
        else if (type.Equals("flag"))
        {
            if (flags[item] == true)
            {
                flags[item] = false;
                return true;
            }
        }
        else if (type.Equals("human")) {
            if (people[item] == true)
            {
                return true;
            }
        }
        return false;
    }
}
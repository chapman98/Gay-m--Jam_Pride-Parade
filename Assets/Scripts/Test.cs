
/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class global : MonoBehaviour
{
    static global instance = null;
    string playerName;
    static int DaysRemaining;
    [SerializeField] Toggle toggleHe;
    [SerializeField] Toggle toggleShe;
    [SerializeField] Toggle toggleThem;
    [SerializeField] InputField NameField;
    //[SerializeField] int example;
    // Invetory Varibles
    private static Sprite[] sprites;
    [SerializeField] public Sprite[] tempsprites;
    enum Item
    {
        ITEM_EMPTY,
        ITEM_DONUT,
        ITEM_DRINK
    }
    private static GameObject[] inventoryspaces;
    private static Item[] inv = { (Item)0, (Item)0, (Item)0 };
    public static bool[] flags = { false, false, false, false, false };
    // lesbian, gay, bisexual, transexual, asxual
    // END

    // Use this for initialization
    void Start()
    {
        // couldnt set sprites when static
        sprites = tempsprites;
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
        toggleHe.onValueChanged.AddListener(delegate { updatePronouns(); });
        toggleShe.onValueChanged.AddListener(delegate { updatePronouns(); });
        toggleThem.onValueChanged.AddListener(delegate { updatePronouns(); });
        // Inventory Setup
        inventoryspaces = new GameObject[3];
        FindInventory();
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

    // Update is called once per frame
    void Update()
    {
        playerName = NameField.text;
        PlayerPrefs.SetString("Name", playerName);
        PlayerPrefs.SetInt("rDays", DaysRemaining);
        if (Input.GetKeyDown(KeyCode.P)) { Debug.Log(PlayerPrefs.GetString("Name")); }
        if (Input.GetKeyDown(KeyCode.O)) { Debug.Log(PlayerPrefs.GetInt("rDays")); }
        if (Input.GetKeyDown(KeyCode.I)) { Debug.Log(PlayerPrefs.GetString("Pronoun")); }
        // Used to test inventory access
        UpdateInventory();
    }

    // Inventory Methods
    public static void RefreshInv()
    {
        for (int i = 0; i < inv.Length; i++)
        {
            inventoryspaces[i].gameObject.GetComponent<SpriteRenderer>().sprite = sprites[(int)inv[i]];
        }
    }

    public static bool ADDInven(int item)
    {
        for (int i = 0; i < inv.Length; i++)
        {
            if (inv[i] == (Item)0)
            {
                inv[i] = (Item)item;
                RefreshInv();
                return true;
            }
        }
        return false;
    }

    public static bool REMInven(int item)
    {
        for (int i = 0; i < inv.Length; i++)
        {
            if (inv[i] == (Item)item)
            {
                DeleteAtPos(i);
                RefreshInv();
                return true;
            }
        }
        return false;
    }

    private static void DeleteAtPos(int del)
    {
        inv[del] = (Item)0;
    }

    // Used to find the rigid bodys within the scene
    public void FindInventory()
    {
        // Ensure the invetory boxes are named as below
        inventoryspaces[0] = GameObject.Find("Inven1");
        inventoryspaces[1] = GameObject.Find("Inven2");
        inventoryspaces[2] = GameObject.Find("Inven3");
        RefreshInv();
    }
    // Test inventory
    private void UpdateInventory()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Debug.Log(ADDInven(1) + " add item1");
        }
        else if (Input.GetKeyDown(KeyCode.X))
        {
            Debug.Log(REMInven(1) + " delete item1");
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            Debug.Log(ADDInven(2) + " add item2");
        }
        else if (Input.GetKeyDown(KeyCode.V))
        {
            Debug.Log(REMInven(2) + " delete item2");
        }
        else if (Input.GetKeyDown(KeyCode.B))
        {
            ToggleHideInventory();
        }

    }

    private void ToggleHideInventory()
    {
        bool change = true;
        if (inventoryspaces[0].activeSelf == true)
        {
            change = false;
        }
        for (int i = 0; i < inv.Length; i++)
        {
            inventoryspaces[i].SetActive(change);
        }
    }

    // END
}
*/
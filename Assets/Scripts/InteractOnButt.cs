using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class InteractOnButt : MonoBehaviour {

    public UnityEvent OnButtonPress;
    bool canExecuteButtons;
    [SerializeField] TextMeshProUGUI interactText;
    [SerializeField] Collider2D player;
    [SerializeField] GameObject npc;
    [SerializeField] GameObject textBox;
    [SerializeField] TextMeshProUGUI npcText;

    private int txtCounter;

    private void Start() {
        txtCounter = 0;
    }

    public void OnTriggerEnter2D(Collider2D collision){
        canExecuteButtons = true;
        //Execute script which displays interact button
        interactText.gameObject.SetActive(true);
        //Debug.Log("Enter interact area");
    }

    public void OnTriggerExit2D(Collider2D collision) {
        canExecuteButtons = false;
        //Execute script which removes interact button display
        interactText.gameObject.SetActive(false);
        textBox.SetActive(false);
        //Debug.Log("Exit interact area");
    }
    
    public void npcInteraction() {
        if (Input.GetKeyDown(KeyCode.E))  {
            textBox.SetActive(true);
            // npcText.SetActive(true);
            //Execute code which interacts with specific person
            if (npc.name == "Matt") {
                if (txtCounter == 10) {
                }
                else if (txtCounter > 7) {
                    txtCounter = 6; //Idle talk if already talked to.
                }
                //Else txtCounter = 6
                switch (txtCounter)
                {
                    case 0:
                        npcText.SetText("*New Zealand Voice*");
                        //Debug.Log("*New Zealand Voice*");
                        break;
                    case 1:
                        npcText.SetText("Hi, thanks for inviting me to the parade " + PlayerPrefs.GetString("Name"));
                        //Debug.Log("Hi, thanks for inviting me to the parade " + PlayerPrefs.GetString("Name"));
                        break;
                    case 2:
                        npcText.SetText("I've lost my tarot deck though so I need to find that before I come.");
                        //Debug.Log("I've lost my tarot deck though so I need to find that before I come.");
                        break;
                    case 3:
                        npcText.SetText("If I do, I'll totally join you!");
                        //Debug.Log("If I do, I'll totally join you!");
                        //textBox.SetActive(false);
                        if (PlayerPrefs.GetInt("Tarot") == 1)
                        {
                            txtCounter = 4;
                        } else {
                            txtCounter = 6;
                        }
                        break;
                    case 4:
                        PlayerPrefs.SetInt("Tarot", 2);
                        npcText.SetText("Oh my god, you found it! Thanks, so much " + PlayerPrefs.GetString("Name"));
                        //Debug.Log("Oh my god, you found it! Thanks, so much " + PlayerPrefs.GetString("Name"));
                        break;
                    case 5:
                        npcText.SetText("I’m really looking forward to the parade now");
                        //Debug.Log("I’m really looking forward to the parade now");
                        PlayerPrefs.SetInt("Homosexual", 1);
                        PlayerPrefs.SetInt("Matt", 2);
                        txtCounter = 9;
                        break;
                    case 6:
                        if (PlayerPrefs.GetInt("Tarot") == 2 && PlayerPrefs.GetInt("Matt") == 2) {
                            txtCounter = 6;
                        } else if (PlayerPrefs.GetInt("Tarot") == 1)
                        {
                            txtCounter = 4;
                        }
                        else {
                            npcText.SetText("Any luck finding my deck?");
                            //Debug.Log("Any luck finding my deck?");
                        }
                        break;
                    case 7:
                        textBox.SetActive(false);
                        break;
                    default:
                        break;
                } //Matt conversations

            }
            else if (npc.name == "Michael") {
                //Debug.Log("Does player have heels = "+ global.REMThing(1, "item"));
                PlayerPrefs.SetInt("Michael", 1);
                if (txtCounter == 10) { }
                else if (txtCounter > 7) {
                    txtCounter = 6; //Idle talk if already talked to.
                }
                switch (txtCounter) {
                    case 0:
                        npcText.SetText("Uhh hey. I hear you’re looking for a homosexual for your parade.");
                        //Debug.Log("Uhh hey. I hear you’re looking for a homosexual for your parade.");
                        break;
                    case 1:
                        npcText.SetText("I’d love to take part but I need to buy new shoes that day");
                        //Debug.Log("I’d love to take part but I need to buy new shoes that day");
                        break;
                    case 2:
                        npcText.SetText("I was going to meet Lucas to get them from him.");
                        //Debug.Log("I was going to meet Lucas to get them from him.");
                        if (PlayerPrefs.GetInt("Heels") == 1) {
                            txtCounter = 2; //heels in inventory txt counter = 4;
                        } else {
                            txtCounter = 6;
                        }
                        break;
                    case 3:
                        PlayerPrefs.SetInt("Heels", 2);
                        npcText.SetText("Oh thanks, these are perfect!");
                        //Debug.Log("Oh thanks, these are perfect!");
                        global.REMThing(1, "item");
                        break;
                    case 4:
                        npcText.SetText("*Transform*");
                        //Debug.Log("*Transform*");
                        break;
                    case 5:
                        npcText.SetText("Meet Crystal Midnight, now we can really liven up that parade of yours gurrrl!!");
                        //Debug.Log("Meet Crystal Midnight, now we can really liven up that parade of yours gurrrl!!");
                        PlayerPrefs.SetInt("Homosexual", 1);
                        PlayerPrefs.SetInt("Michael", 2);
                        break;
                    case 6:
                        if (PlayerPrefs.GetInt("Heels") == 2 && PlayerPrefs.GetInt("Michael") == 2)
                        {
                            txtCounter = 6;
                        } else if (PlayerPrefs.GetInt("Heels") == 1)
                        {
                            txtCounter = 2; //heels in inventory txt counter = 4;
                        }
                        else
                        {
                            npcText.SetText("Have you had a chance to talk to Lucas yet?");
                        }
                        //Debug.Log("Have you had a chance to talk to Lucas yet?");
                        break;
                    case 7:
                        textBox.SetActive(false);
                        break;
                    default:
                        break;
                } //Michael conversation
            }
            else if (npc.name == "Lucy") {
                if (txtCounter == 10) { }
                else if (txtCounter > 8) {
                    txtCounter = 7; //Idle talk if already talked to.
                }
                switch (txtCounter) {
                    case 0:
                        npcText.SetText("NEEEXXTT!");
                        //Debug.Log("NEEEXXTT!");
                        break;
                    case 1:
                        npcText.SetText("Sorry " + PlayerPrefs.GetString("Name") + ", I thought you were another person here for the speed dating rubbish.");
                        //Debug.Log("Sorry " + PlayerPrefs.GetString("Name") + ", I thought you were another person here for the speed dating rubbish.");
                        break;
                    case 2:
                        npcText.SetText("I’ve been here for hours and no such luck yet");
                        //Debug.Log("I’ve been here for hours and no such luck yet");
                        break;
                    case 3:
                        npcText.SetText("You wouldn’t happen to know any lucky women looking would you");
                        //Debug.Log("You wouldn’t happen to know any lucky women looking would you");
                        if (PlayerPrefs.GetInt("Millie") == 1) {
                            txtCounter = 3; //If spoken to Millie;
                        }
                        else {
                            txtCounter = 7;
                        }
                        break;
                    case 4:
                        npcText.SetText("Thank you so much for introducing us!");
                        //Debug.Log("Thank you so much for introducing us!");
                        break;
                    case 5:
                        npcText.SetText("We think this could go somewhere!");
                        //Debug.Log("We think this could go somewhere!");
                        break;
                    case 6:
                        npcText.SetText("Especially that parade, we’ll both be there together. Adios!");
                        //Debug.Log("Especially that parade, we’ll both be there together. Adios!");
                        PlayerPrefs.SetInt("Lesbian", 1);
                        PlayerPrefs.SetInt("Lucy", 2);
                        PlayerPrefs.SetInt("Millie", 2);
                        break;
                    case 7:
                        if (PlayerPrefs.GetInt("Lucy") == 2 && PlayerPrefs.GetInt("Millie") == 2)
                        { } else if (PlayerPrefs.GetInt("Millie") == 1)
                        {
                            txtCounter = 3; //If spoken to Millie;
                        }
                        else {
                            npcText.SetText("If only I could find love! *Dramatic swoon* ");
                        }
                        //Debug.Log("If only I could find love! *Dramatic swoon* ");
                        break;
                    case 8:
                        textBox.SetActive(false);
                        break;
                    default:
                        break;
                } //Lucy conversation
            }
            else if (npc.name == "Emily") {
                if (txtCounter == 10) { }
                else if (txtCounter > 7) {
                    txtCounter = 6; //Idle talk if already talked to.
                }
                switch (txtCounter) {
                    case 0:
                        npcText.SetText("Hey, " + PlayerPrefs.GetString("Name") + ", a parade sounds amazing!");
                        //Debug.Log("Hey, " + PlayerPrefs.GetString("Name") + ", a parade sounds amazing!");
                        break;
                    case 1:
                        npcText.SetText("But I had planned to buy donuts then!");
                        //Debug.Log("But I had planned to buy donuts then");
                        break;
                    case 2:
                        npcText.SetText("So I’m going to have to decline, sorry");
                        //Debug.Log("So I’m going to have to decline, sorry");
                        break;
                    case 3:
                        npcText.SetText("Sorry again");
                        //Debug.Log("Sorry again");
                        if (PlayerPrefs.GetInt("Donut") == 1) {
                            Debug.Log("DONNUUTTTSS");
                            txtCounter = 3; //Donuts in inventory txt counter = 4;
                        }
                        else {
                            txtCounter = 6;
                        }
                        break;
                    case 4:
                        npcText.SetText("Oh my god! Donuts! Thaaanks!!!");
                        //Debug.Log("Oh my god! Donuts! Thaaanks!!");
                        // REMOVE DONUT
                        PlayerPrefs.SetInt("Donut", 2);
                        break;
                    case 5:
                        npcText.SetText("I can definitely come now, Sorry for the delayed yes!");
                        //Debug.Log("I can definitely come now, Sorry for the delayed yes");
                        PlayerPrefs.SetInt("Asexual", 1);
                        break;
                    case 6:
                        if (PlayerPrefs.GetInt("Donut") == 2) { txtCounter = 6; } else if (PlayerPrefs.GetInt("Donut") == 1)
                        {
                            txtCounter = 3; //Donuts in inventory txt counter = 4;
                        }
                        else {
                            npcText.SetText("Maan, I wish I had a donut now.");
                        }
                        //Debug.Log("Maan, I wish I had a donut now."); //Fill in idle phase
                        break;
                    case 7:
                        textBox.SetActive(false);
                        break;
                    default:
                        break;
                } //Emily conversation

            }
            else if (npc.name == "James")
            {
                if (txtCounter == 10) { }
                else if (txtCounter > 7)
                {
                    txtCounter = 6; //Idle talk if already talked to.
                }
                switch (txtCounter)
                {
                    case 0:
                        npcText.SetText("Oh hi, I was just doing some coursework.");
                        //Debug.Log("Oh hi, I was just doing some coursework.");
                        break;
                    case 1:
                        npcText.SetText("What can I do you for?");
                        //Debug.Log("What can I do you for?");
                        break;
                    case 2:
                        npcText.SetText("The parade for pride sounds good but not quite my thing.");
                        //Debug.Log("The parade for pride sounds good but not quite my thing.");
                        break;
                    case 3:
                        npcText.SetText("I’ll probably keep doing coursework.");
                        //Debug.Log("I’ll probably keep doing coursework.");
                        if ((PlayerPrefs.GetInt("Emily") == 2 || PlayerPrefs.GetInt("Matt") == 2)) {
                            txtCounter = 3; //Convinced Matt or Emily to go
                        }
                        else {
                            txtCounter = 7;
                        }
                        break;
                    case 4:
                        npcText.SetText("Well if they're is going then I think I can find the time");
                        PlayerPrefs.SetInt("James", 2);
                        //Debug.Log("Well if they're is going then I think I can find the time");
                        break;
                    case 5:
                        npcText.SetText("Hey do you know if they’re single?");
                        //Debug.Log("Hey do you know if they’re single?");
                        break;
                    case 6:
                        npcText.SetText("Don’t worry, See you there " + PlayerPrefs.GetString("Name"));
                        //Debug.Log("Don’t worry, See you there " + PlayerPrefs.GetString("Name"));
                        PlayerPrefs.SetInt("Bisexual", 1);
                        break;
                    case 7:
                        if (PlayerPrefs.GetInt("James") == 2) { }
                        else {
                            npcText.SetText("I wonder who else is doing the parade, maybe I'll see Matt or Emily.");
                        }
                        //Debug.Log("I wonder who else is doing the parade, maybe I'll see Matt or Emily."); //Fill in idle phase
                        break;
                    case 8:
                        textBox.SetActive(false);
                        break;
                    default:
                        break;
                } //Emily conversation

            }
            else if (npc.name == "Sammy")
            {
                if (txtCounter == 10) { }
                else if (txtCounter > 9)
                {
                    txtCounter = 8; //Idle talk if already talked to.
                }
                switch (txtCounter)
                {
                    case 0:
                        npcText.SetText("How do you know who you are?");
                        //Debug.Log("How do you know who you are?");
                        break;
                    case 1:
                        npcText.SetText("I’ve spent hours thinking it over and I keep questioning everything .");
                        //Debug.Log("I’ve spent hours thinking it over and I keep questioning everything .");
                        break;
                    case 2:
                        npcText.SetText("It’s driving me crazy");
                        //Debug.Log("It’s driving me crazy");
                        break;
                    case 3:
                        npcText.SetText("You wouldn’t happen to be able to help me work out myself?");
                        //Debug.Log("You wouldn’t happen to be able to help me work out myself?");
                        if (global.checkFlags())
                        {
                            txtCounter = 3; //Talked to with 3+ flags
                        }
                        else
                        {
                            txtCounter = 8;
                        }
                        break;
                    case 4:
                        npcText.SetText(PlayerPrefs.GetString("Name") + ": Be whatever or whoever you feel like and try anything you fancy!");
                        //Debug.Log(PlayerPrefs.GetString("Name") + ": Be whatever or whoever you feel like and try anything you fancy!");
                        break;
                    case 5:
                        npcText.SetText(PlayerPrefs.GetString("Name") + ":You can only be you no matter what you choose.");
                        //Debug.Log(PlayerPrefs.GetString("Name") + ":You can only be you no matter what you choose.");
                        break;
                    case 6:
                        npcText.SetText("Oh thanks, " + PlayerPrefs.GetString("Name") + ", that’s really cleared up a few things for me.");
                        //Debug.Log("Oh thanks, " + PlayerPrefs.GetString("Name") + ", that’s really cleared up a few things for me.");
                        break;
                    case 7:
                        npcText.SetText("I'll walk proud at your parade!");
                        //Debug.Log("I'll walk proud at your parade!");
                        PlayerPrefs.SetInt("Transgender", 1);
                        PlayerPrefs.SetInt("Sammy", 2);
                        break;
                    case 8:
                        npcText.SetText("I wonder a wonder.");
                        //Debug.Log("I wonder a wonder.");
                        break; //Idle talk
                    case 9:
                        textBox.SetActive(false);
                        break;
                    default:
                        break;
                } //Emily conversation
            }
            else if (npc.name == "Charly")
            {
                if (txtCounter == 10) { }
                else if (txtCounter > 9)
                {
                    txtCounter = 8; //Idle talk if already talked to.
                }
                switch (txtCounter)
                {
                    case 0:
                        npcText.SetText("Oh hay gurrrl, how’s it goin’?");
                        //Debug.Log("Oh hay gurrrl, how’s it goin’?");
                        break;
                    case 1:
                        npcText.SetText("You’re looking for different flags to fly for your parade, riight?!?");
                        //Debug.Log("You’re looking for different flags to fly for your parade, riight?!?");
                        break;
                    case 2:
                        npcText.SetText("Well have I got news for you.");
                        //Debug.Log("Well have I got news for you.");
                        break;
                    case 3:
                        npcText.SetText("I am a loud and proud BISEXUALLLLL");
                        //Debug.Log("I am a loud and proud BISEXUALLLLL");
                        break;
                    case 4:
                        npcText.SetText("I bet I’m the first person you’ve asked and I’m so honoured");
                        //Debug.Log("I bet I’m the first person you’ve asked and I’m so honoured");
                        break;
                    case 5:
                        npcText.SetText("So Am I?");
                        //Debug.Log("So Am I?");
                        break;
                    case 6:
                        npcText.SetText("YYYYaaasss, I love you.");
                        //Debug.Log("YYYYaaasss, I love you.");
                        break;
                    case 7:
                        npcText.SetText("Can’t wait to see you there, toodels!!");
                        //Debug.Log("Can’t wait to see you there, toodels!!");
                        PlayerPrefs.SetInt("Bisexual", 1);
                        PlayerPrefs.SetInt("Charly", 2);
                        break;
                    case 8:
                        if (PlayerPrefs.GetInt("Charly") == 2) { } else
                        {
                            npcText.SetText("Am I not good enough?");
                        }
                        //Debug.Log("Am I not good enough?");
                        break; //Idle talk
                    case 9:
                        textBox.SetActive(false);
                        break;
                    default:
                        break;
                }
            }
            else if (npc.name == "Zach")
            {
                if (txtCounter == 11) { }
                else if (txtCounter > 10)
                {
                    txtCounter = 9; //Idle talk if already talked to.
                }
                switch (txtCounter)
                {
                    case 0:
                        npcText.SetText("The sea is so beautiful don’t you think.");
                        //Debug.Log("The sea is so beautiful don’t you think.");
                        break;
                    case 1:
                        npcText.SetText("It’s difficult right now. People don’t understand who I am and that hurts");
                        //Debug.Log("It’s difficult right now. People don’t understand who I am and that hurts");
                        break;
                    case 2:
                        npcText.SetText("I just feel so closed off from people.");
                        //Debug.Log("I just feel so closed off from people.");
                        if (global.checkFlags())
                        {
                            txtCounter = 2; //Talked to with 3+ flags
                        }
                        else
                        {
                            txtCounter = 9;
                        }
                        break;
                    case 3:
                        npcText.SetText(PlayerPrefs.GetString("Name") + ":The LGBT + community is inclusive of everyone in the +.");
                        //Debug.Log(PlayerPrefs.GetString("Name") + ":The LGBT+ community is inclusive of everyone in the +.");
                        break;
                    case 4:
                        npcText.SetText(PlayerPrefs.GetString("Name") + ":This mean those who know what they are and those that don’t");
                        //Debug.Log(PlayerPrefs.GetString("Name") + ":This mean those who know what they are and those that don’t");
                        break;
                    case 5:
                        npcText.SetText(PlayerPrefs.GetString("Name") + ":Look at all these flags, it’s a big family with many unique and colourful individuals.");
                        //Debug.Log(PlayerPrefs.GetString("Name") + ":Look at all these flags, it’s a big family with many unique and colourful individuals.");
                        break;
                    case 6:
                        npcText.SetText(PlayerPrefs.GetString("Name") + ":No matter who you are or like you’re a part of us!");
                        //Debug.Log(PlayerPrefs.GetString("Name") + ":No matter who you are or like you’re a part of us!");
                        break;
                    case 7:
                        npcText.SetText("Huh, I hadn’t thought of it like that, I feel better and more welcomed now.");
                        //Debug.Log("Huh, I hadn’t thought of it like that, I feel better and more welcomed now.");
                        break;
                    case 8:
                        npcText.SetText("I’ll see, you at the parade.");
                        //Debug.Log("I’ll see, you at the parade.");
                        PlayerPrefs.SetInt("Asexual", 1);
                        PlayerPrefs.SetInt("Zach", 2);
                        break;
                    case 9:
                        npcText.SetText("*Le Sigh*");
                        //Debug.Log("*Le Sigh*");
                        break;
                    case 10:
                        textBox.SetActive(false);
                        break;
                    default:
                        break;
                }
            }
            else if (npc.name == "Millie")
            {
                if (txtCounter == 10) { }
                else if (txtCounter > 8)
                {
                    txtCounter = 7; //Idle talk if already talked to.
                }
                switch (txtCounter)
                {
                    case 0:
                        npcText.SetText("Hi " + PlayerPrefs.GetString("Name") + ", *sigh* How’s it going?");
                        //Debug.Log("Hi " + PlayerPrefs.GetString("Name") + ", *sigh* How’s it going?");
                        break;
                    case 1:
                        npcText.SetText("I’m just a bit lonely, y’know how it is");
                        //Debug.Log("I’m just a bit lonely, y’know how it is");
                        break;
                    case 2:
                        npcText.SetText("Nobody to keep me company this summer");
                        //Debug.Log("Nobody to keep me company this summer");
                        if (PlayerPrefs.GetInt("Lucy") == 1)
                        {
                            txtCounter = 2; //Spoken to Lucy
                        }
                        else
                        {
                            txtCounter = 7;
                        }
                        break;
                    case 3:
                        npcText.SetText(PlayerPrefs.GetString("Name") + ":Hey, have you met Lucy?");
                        //Debug.Log(PlayerPrefs.GetString("Name") + ":Hey, have you met Lucy?");
                        break;
                    case 4:
                        npcText.SetText("Thank you so much for introducing us!");
                        //Debug.Log("Thank you so much for introducing us!");
                        break;
                    case 5:
                        npcText.SetText("We think this could go somewhere");
                        //Debug.Log("We think this could go somewhere");
                        break;
                    case 6:
                        npcText.SetText("Especially that parade, we’ll both be there together.");
                        //Debug.Log("Especially that parade, we’ll both be there together.");
                        PlayerPrefs.SetInt("Lesbian", 1);
                        PlayerPrefs.SetInt("Millie", 2);
                        break;
                    case 7:
                        if (PlayerPrefs.GetInt("Lucy") == 1)
                        {
                            txtCounter = 2; //Spoken to Lucy
                        }
                        else if (PlayerPrefs.GetInt("Millie") == 2) { txtCounter = 7; }
                        else
                        {
                            npcText.SetText("Am I the only one alone?");
                        }
                        
                        //Debug.Log("Am I the only one alone?");
                        break;
                    case 8:
                        textBox.SetActive(false);
                        break;
                    default:
                        break;
                }
            }
            else if (npc.name == "Lucas")
            {
                if (txtCounter == 10) { }
                else if (txtCounter > 9)
                {
                    txtCounter = 8; //Idle talk if already talked to.
                }
                switch (txtCounter)
                {
                    case 0:
                        npcText.SetText("*Going to throw Heels off end of pier*");
                        //Debug.Log("*Going to throw Heels off end of pier*");
                        break;
                    case 1:
                        npcText.SetText("It’s the end of an era " + PlayerPrefs.GetString("Name"));
                        //Debug.Log("It’s the end of an era " + PlayerPrefs.GetString("Name"));
                        break;
                    case 2:
                        npcText.SetText("I want to let go but it’s difficult. I’ve been someone else my whole life");
                        //Debug.Log("I want to let go but it’s difficult. I’ve been someone else my whole life");
                        break;
                    case 3:
                        npcText.SetText("Now that I’m me it’s so freeing but I’m scared of letting go completely");
                        //Debug.Log("Now that I’m me it’s so freeing but I’m scared of letting go completely");
                        if (PlayerPrefs.GetInt("Michael") == 1)
                        {
                            Debug.Log("spoken to michael");
                            txtCounter = 3; //If spoken to Michael
                        }
                        else {
                            Debug.Log("Not spoken to michael");
                            txtCounter = 8;
                        }
                        break;
                    case 4:
                        npcText.SetText(PlayerPrefs.GetString("Name") + ": Michael is looking for heels, you could donate yours?");
                        //Debug.Log(PlayerPrefs.GetString("Name") + ": Michael is looking for heels, you could donate yours?");
                        break;
                    case 5:
                        PlayerPrefs.SetInt("Heels", 1);
                        npcText.SetText("Thank you a lot " + PlayerPrefs.GetString("Name") + ", you’ve helped me let go");
                        //Debug.Log("Thank you a lot " + PlayerPrefs.GetString("Name") + ", you’ve helped me let go");
                        break;
                    case 6:
                        npcText.SetText("I need time to think but I want to help with your parade.");
                        //Debug.Log("I need time to think but I want to help with your parade.");
                        break;
                    case 7:
                        npcText.SetText("I’ll be proud for the day and the future!");
                        //Debug.Log("I’ll be proud for the day and the future!");
                        PlayerPrefs.SetInt("Transgender", 1);
                        PlayerPrefs.SetInt("Lucas", 2);
                        break;
                    case 8:
                        //Debug.Log("Is letting go really what I want?");
                        if (PlayerPrefs.GetInt("Michael") == 1) {
                            Debug.Log("spoken to michael");
                            txtCounter = 4; //If spoken to Michael
                        } else
                        {
                            npcText.SetText("Is letting go really what I want?");
                        }
                        break;
                    case 9:
                        textBox.SetActive(false);
                        break;
                    default:
                        break;
                }
            }
            else if (npc.name == "DonutStand") {
                //Add donut to inventory
                switch (txtCounter) {
                    case 0:
                        PlayerPrefs.SetInt("Donut", 1);
                        npcText.SetText("You Picked up a donut!");
                        break;
                    case 1:
                        textBox.SetActive(false);
                        break;
                }
            }
            else if (npc.name == "TarotTable") {
                //Add tarot deck to inventory
                switch (txtCounter)
                {
                    case 0:
                        PlayerPrefs.SetInt("Tarot", 1);
                        npcText.SetText("You Picked up a tarot deck!");
                        break;
                    case 1:
                        textBox.SetActive(false);
                        break;
                }
            }
            txtCounter++;
        }
    }

    IEnumerator waiting(int time)
    {
        yield return new WaitForSecondsRealtime(time);
    }

    // Update is called once per frame
    void Update() {
        if (canExecuteButtons) {
            if (Input.GetKeyDown(KeyCode.E)) {
                //Execute code which interacts with specific person
                npcInteraction();
                //Debug.Log("Interact with NPC");
            }
        }
    }
}

// Lucy- Correct dialog give lesbian flag
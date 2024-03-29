﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room_02_Keypad_System : MonoBehaviour {

    /*
        Keypad System which waits for an input from the Keypad_Button_Press.cs script and the Keypad_Reset.cs script.
    */

    // Inits vars
    public string password = "";
    public string input = "";

    // Waits for input from Keypad_Button_Press Script
    public void keyinputed(string keyedNum)
    {
        input += keyedNum;

        Room_02_Keypad_Change_Screen ChangeText = FindObjectOfType<Room_02_Keypad_Change_Screen>();
        Room_02_DoubleDoorControl DoorOpen = FindObjectOfType<Room_02_DoubleDoorControl>();
        
        // Checks if the length of the number inputed is less than maxNumbers
        if (input.Length <= password.Length)
        {
            // Sends text to the TextMeshPro text element on the keypad
            ChangeText.ChangeText(keyedNum);

            // Checks if the inputed string is equal to the password which then opens the door and moves the player
            if (input == password)
            {
                DoorOpen.opendoor = true;
            }
            // else if the password is not the correct password and the length of the password is equal to the length of the password
            else if (input != password && input.Length == password.Length)
            {
                input = "";
                ChangeText.InputError();
            }
        }
        // Checks if the inputed value is longer than maxNumbers calls InputError function if it is and resets input
        else if (input.Length > password.Length)
        {
            input = "";
            ChangeText.InputError();
        }

    }

    // Called when the user presses on the screen part of the keypad
    public void InputReset()
    {
        // Finds script to change the textmeshpro object
        Room_02_Keypad_Change_Screen ChangeText = FindObjectOfType<Room_02_Keypad_Change_Screen>();
        Room_02_DoubleDoorControl DoorOpen = FindObjectOfType<Room_02_DoubleDoorControl>();

        //Resets the input to default parameters and closes the door if its open.
        input = "";
        ChangeText.ResetText();

        if (DoorOpen.opendoor == true)
        {
            DoorOpen.opendoor = false; // Used for play testing
        }
    }

}

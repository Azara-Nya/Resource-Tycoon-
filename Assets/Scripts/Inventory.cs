using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Inventory : MonoBehaviour
{
[SerializeField] private TextMeshProUGUI Text;
public int selectedSlot;
public string[] Inv;
public GameObject[] InvContent;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            selectedSlot=0;
        }
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            selectedSlot=1;
        }
        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            selectedSlot=2;
        }
        if(Input.GetKeyDown(KeyCode.Alpha4))
        {
            selectedSlot=3;
        }
        if(Input.GetKeyDown(KeyCode.Alpha5))
        {
            selectedSlot=4;
        }

        for( int i=0; i<5; i++ ) 
        {
            if(Inv[i]=="")
            {
                Inv[i] = "Nothing";
            }
        }
        
        Text.text= $"Slot 1: {Inv[0]} \n Slot 2: {Inv[1]} \n Slot 3: {Inv[2]} \n Slot 4: {Inv[3]} \n Slot 5: {Inv[4]}";

        if(Inv[selectedSlot] != "Nothing")
        {
            if(Input.GetKeyDown(KeyCode.Backspace))
            {
                Inv[selectedSlot] = "Nothing";
       InvContent[selectedSlot] = null;
        //spawn pick up item
            }
            if(Input.GetKeyDown(KeyCode.Space))
            {
                InvContent[selectedSlot].GetComponent<Item>().Action();
            }
        }
    }
}

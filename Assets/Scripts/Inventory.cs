using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Inventory : MonoBehaviour
{
[SerializeField] private TextMeshProUGUI Text;
[SerializeField] private Transform dropPoint;
[SerializeField] private Player player;
public int selectedSlot;
public string[] Inv;
public string heldType;
public GameObject[] possibleItems;
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
        
    if(Inv[selectedSlot]=="Axe")
    {
        heldType="Axe";
        if(player.currentResourceInRange=="Wood")
        {
        player.ResourceSpeed=0.5f;
        }
    }

    if(Inv[selectedSlot]=="Pickaxe")
    {
        heldType="Pickaxe";
        if(player.currentResourceInRange=="Stone")
        {
            player.ResourceSpeed=1f;
        }
    }

    if(Inv[selectedSlot]=="Nothing")
    {
        heldType=null;
        player.ResourceSpeed=0f;
    }
        Text.text= $"Slot 1: {Inv[0]} \n Slot 2: {Inv[1]} \n Slot 3: {Inv[2]} \n Slot 4: {Inv[3]} \n Slot 5: {Inv[4]}";

        if(Inv[selectedSlot] != "Nothing")
        {
            if(Input.GetKeyDown(KeyCode.Backspace))
            {
                Instantiate(InvContent[selectedSlot], dropPoint.position, dropPoint.rotation);
                Inv[selectedSlot] = "Nothing";
                InvContent[selectedSlot] = null;
                heldType=null;
            }
            if(Input.GetKeyDown(KeyCode.Space))
            {
                InvContent[selectedSlot].GetComponent<Item>().Action();
            }
        }
    }
}

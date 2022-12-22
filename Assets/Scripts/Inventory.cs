using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Inventory : MonoBehaviour
{
[SerializeField] private TextMeshProUGUI Text;
public string[] Inv;

    void Update()
    {
        for( int i=0; i<5; i++ ) 
        {
            if(Inv[i]=="")
            {
                Inv[i] = "Nothing";
            }
        }
        
        Text.text= $"Slot 1: {Inv[0]} \n Slot 2: {Inv[1]} \n Slot 3: {Inv[2]} \n Slot 4: {Inv[3]} \n Slot 5: {Inv[4]}";
    }
}

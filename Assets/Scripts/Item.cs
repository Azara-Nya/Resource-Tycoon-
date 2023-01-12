using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{

[SerializeField] private string matterial="Wood";
[SerializeField] private int matterialID=0;
private bool canPickUp;
Inventory Inven;

    void Start()
    {
        Inven = FindObjectOfType<Inventory>();
    }

    void Update()
    {
            if(Input.GetKeyDown(KeyCode.Space) && canPickUp)
            {
            for(int i=0; i<5; i++)
            {
                if(Inven.Inv[i]=="Nothing")
                {
                    Inven.InvContent[i] = Inven.possibleItems[matterialID];
                    Inven.Inv[i] = matterial;
                    Destroy(gameObject);
                    break;
                }
            }
            }
    }

    public void Action()
    {
        //if(Inven.Inv[selectedSlot] == "Torch") toggle on/off
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            canPickUp=true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            canPickUp=false;
        }
    }
}

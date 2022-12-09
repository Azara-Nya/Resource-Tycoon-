using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceGiver : MonoBehaviour
{
    [SerializeField] private int Resource; //Wood:0, Stone:1
    [SerializeField] private int PaymentResource;
    [SerializeField] private int cost;
    [SerializeField] private bool Unlocked;
    private bool canGive;
    [SerializeField] ResourceManger ReM;

    public void Add_Resource()
    {
        if(Unlocked)
        {
        //Wait Specific Amount of Time
        ReM.Resources[Resource] += 1;
        Debug.Log($"{ReM.Resources[Resource]}, {Resource}");
        }

        if(!Unlocked && ReM.Resources[PaymentResource] >= cost)
        {
                Unlocked = !Unlocked;
                ReM.Resources[PaymentResource] -= cost;
        }    
    }

    void Update()
    {
        if(canGive && Input.GetKeyDown(KeyCode.E))
        {
            Add_Resource();
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {          
            canGive = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {          
            canGive = false;
        }
    }
}

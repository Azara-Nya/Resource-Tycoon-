using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceGiver : MonoBehaviour
{
    [SerializeField] private string Resource="Wood"; 
    [SerializeField] private int Resource_Number=0;
    [SerializeField] private string PaymentResource;
    [SerializeField] private int PaymentResource_Number=0;
    [SerializeField] private int cost;
    [SerializeField] private bool Unlocked;
    [SerializeField] private float Resource_Time=1f;
    [SerializeField] private GameObject ResourcePrefab;
    private bool canGive;
    private int times;
    public bool currently_adding;
    [SerializeField] ResourceManger ReM;
    [SerializeField] Inventory Inven;

    public void Add_Resource()
    {
        if(!currently_adding)
        {
        StartCoroutine(Resource_Adder());
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
            currently_adding = false;
        }
    }

    IEnumerator Resource_Adder()
    {
        
        {
        if(Unlocked)
        {
            currently_adding = !currently_adding;
        yield return new WaitForSeconds(Resource_Time);

        if(canGive)
        {
            for(int i = 0; i < Inven.Inv.Length; i++)
            {
                if(Inven.Inv[i]=="Nothing")
               {
                   Inven.Inv[i] = Resource;
                   Inven.InvContent[i] = ResourcePrefab;
                   ReM.Resources[Resource_Number] += 1;
                    break;
               }
          }
             currently_adding = !currently_adding;
        }
        }

        if(!Unlocked && ReM.Resources[PaymentResource_Number] >= cost)
        {
                Unlocked = !Unlocked;
                ReM.Resources[PaymentResource_Number] -= cost;

                for(int i = 0; i < Inven.Inv.Length; i++)
                {         
                    if(Inven.Inv[i] == PaymentResource && times != cost)
                    {
                        times++;
                        Inven.Inv[i] = "Nothing";
                        Inven.InvContent[i] = null;
                        ReM.Resources[Resource_Number]-=1;
                    }
                }    
                times=0;
        }
         
    }
}}

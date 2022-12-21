using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceGiver : MonoBehaviour
{
    [SerializeField] private int Resource; //Wood:0, Stone:1
    [SerializeField] private int PaymentResource;
    [SerializeField] private int cost;
    [SerializeField] private bool Unlocked;
    [SerializeField] private float Resource_Time=1f;
    private bool canGive;
    public bool currently_adding;
    [SerializeField] ResourceManger ReM;

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
        ReM.Resources[Resource] += 1;
        Debug.Log($"{ReM.Resources[Resource]}, {Resource}");
         currently_adding = !currently_adding;
        }
        }

        if(!Unlocked && ReM.Resources[PaymentResource] >= cost)
        {
                Unlocked = !Unlocked;
                ReM.Resources[PaymentResource] -= cost;
        }    
        }
         
    }
}

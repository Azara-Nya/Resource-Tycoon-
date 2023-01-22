using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceGiver : MonoBehaviour
{
    [SerializeField] private int Charges=2;
    [SerializeField] private int dropAmount=1;
    [SerializeField] private float Resource_Time=1f;
    [SerializeField] private GameObject ResourcePrefab;
    [SerializeField] private Transform dropPoint;
    [SerializeField] private Player player;
    [SerializeField] private string ResourceType="Wood";
    private bool canGive;
    public bool currently_adding;
    private int times;
    private int uses;


void Start()
    {
        player = FindObjectOfType<Player>();
    }

    void Update()
    {
        if(uses < Charges)
        {
            if(canGive && Input.GetKeyDown(KeyCode.E))
                {
                  Add_Resource();
                }
        }
        else
        {
            for(int i=0;i<dropAmount;i++)
                {
                 Instantiate(ResourcePrefab, dropPoint.position, dropPoint.rotation);
                }
            Destroy(gameObject);
        } 
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {          
        canGive = true;
        player.currentResourceInRange=ResourceType;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {          
            canGive = false;
            currently_adding = false;
            player.ResourceSpeed=0f;
            player.currentResourceInRange=null;
        }
    }

    public void Add_Resource()
    {
        if(!currently_adding)
        {
            StartCoroutine(Resource_Adder());
        }
    }

    IEnumerator Resource_Adder()
    {    
        {  
            currently_adding = !currently_adding;
        yield return new WaitForSeconds((Resource_Time - player.ResourceSpeed));

        if(canGive)
        {
            uses += 1;
        }
             currently_adding = !currently_adding;
        }
    
         
    }
}


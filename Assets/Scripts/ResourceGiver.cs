using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceGiver : MonoBehaviour
{
    [SerializeField] private int Resource; //Wood:0, Stone:1
    [SerializeField] ResourceManger ReM;

    public void Add_Resource()
    {
        //Wait Specific Amount of Time
        ReM.Resources[Resource] += 1;
        Debug.Log(ReM.Resources[Resource]);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Inventory : MonoBehaviour
{
[SerializeField] private TextMeshProUGUI Text;
[SerializeField] ResourceManger ReM;

    void Update()
    {
        Text.text= $"Wood: {ReM.Resources[0]} \n Stone: {ReM.Resources[1]}";
    }
}

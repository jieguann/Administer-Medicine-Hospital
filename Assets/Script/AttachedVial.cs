using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachedVial : MonoBehaviour
{
    
    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Vial")
        {
            print("++++");
        }
    }


    
}

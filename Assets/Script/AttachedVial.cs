using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachedVial : MonoBehaviour
{
    
    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Vial")
        {
            //other.transform.SetParent(this.transform);
            other.transform.position = this.transform.position;
            other.transform.rotation = this.transform.rotation;
        }

        if(other.tag == "Arm")
        {

        }
    }


    
}

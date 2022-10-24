using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WearGlove : MonoBehaviour
{
    public Material gloveColor;
    private void OnTriggerEnter(Collider other)
    {   if(other.tag == "LeftHand")
        {
            
            other.GetComponent<Renderer>().material.color = gloveColor.color;
            Destroy(this.gameObject);
        }
        
    }
}

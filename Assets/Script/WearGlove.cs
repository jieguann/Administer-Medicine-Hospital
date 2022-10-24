using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WearGlove : MonoBehaviour
{
    public Material gloveColor;
    private void OnTriggerEnter(Collider other)
    {

        wearGlove(other.gameObject, "LeftHand", "LeftGlove");
        wearGlove(other.gameObject, "RightHand", "RightGlove");
        
    }

    private void wearGlove(GameObject other, string hand, string glove)
    {
        if (other.tag == hand && this.tag == glove)
        {

            other.GetComponent<Renderer>().material.color = gloveColor.color;
            Destroy(this.gameObject);
        }
    }
}

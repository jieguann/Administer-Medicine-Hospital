using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanceGlove : MonoBehaviour
{   
    [SerializeField] private GameObject leftGlovePrefeb;
    [SerializeField] private GameObject rightGlovePrefeb;

    private void OnTriggerEnter(Collider other)
    {
        instanceGlove(leftGlovePrefeb, other.gameObject, "LeftHand");
        instanceGlove(rightGlovePrefeb, other.gameObject, "RightHand");
    }

    private void instanceGlove(GameObject glove, GameObject hand, string tagName)
    {
        //print("enter");
        if(hand.tag == tagName)
        {
            Instantiate(glove, hand.transform);
        }
        //Instantiate(glove, hand.transform);
    }

}

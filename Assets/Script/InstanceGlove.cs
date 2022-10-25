using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanceGlove : MonoBehaviour
{   
    [SerializeField] private GameObject leftGlovePrefeb;
    [SerializeField] private GameObject rightGlovePrefeb;
    private bool leftFlag = false;
    private bool rightFlag = false;

    private void OnTriggerEnter(Collider other)
    {
        instanceGlove(leftGlovePrefeb, other.gameObject, "RightHand", rightFlag);
        instanceGlove(rightGlovePrefeb, other.gameObject, "LeftHand", leftFlag);
    }

    private void instanceGlove(GameObject glove, GameObject hand, string tagName, bool flag)
    {
        //print("enter");
        if(hand.tag == tagName && GameManager.Instance.orderFlag<2)
        {
            if(flag == false)
            {
               Instantiate(glove, hand.transform);
               if(hand.tag == "RightHand")
                {
                    rightFlag = true;
                }
                else if (hand.tag == "LeftHand")
                {
                    leftFlag = true;
                }
            }
            
        }
        //Instantiate(glove, hand.transform);
    }

}

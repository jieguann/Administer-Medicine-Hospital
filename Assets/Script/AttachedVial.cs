using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachedVial : MonoBehaviour
{
    private IEnumerator assembleCoroutine;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Vial")
        {
            if (GameManager.Instance.orderFlag < 2)
            {
                print("Please find the right order");
                GameManager.Instance.errorTips();
            }

            else if (GameManager.Instance.orderFlag == 2)
            {
                assembleCoroutine = GameManager.Instance.assembleSyringe();
                StartCoroutine(assembleCoroutine);
            }
            }



        else if (other.tag == "Arm")
        {
            print("Arm");
            if (GameManager.Instance.orderFlag < 3)
            {
                print("Please find the right order");
                GameManager.Instance.errorTips();
            }
        }
    }


    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Vial")
        {
            

            if(GameManager.Instance.orderFlag ==2)
            {
                //other.transform.SetParent(this.transform);
                other.transform.position = this.transform.position;
                other.transform.rotation = this.transform.rotation;
            }
            
        }

        if(other.tag == "Arm")
        {
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Vial")
        {
            if (GameManager.Instance.orderFlag == 2)
            {
                //assembleCoroutine = GameManager.Instance.assembleSyringe();
                StopCoroutine(assembleCoroutine);
            }
        }
    }



}

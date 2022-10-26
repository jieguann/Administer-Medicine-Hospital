using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AttachedVial : MonoBehaviour
{
    private IEnumerator assembleCoroutine;
    private IEnumerator injectCoroutine;
    //private float percentageDisplay;

    private void Start()
    {
        //print(this.transform.GetChild(0).GetComponentInChildren<Slider>().value);

        this.transform.GetChild(0).GetComponentInChildren<Slider>().value = 0;
    }

    private void Update()
    {
        this.transform.GetChild(0).GetComponentInChildren<Slider>().value = GameManager.Instance.assembledPercentage;
    }
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
            else if (GameManager.Instance.orderFlag == 3)
            {
                injectCoroutine = GameManager.Instance.injectPatient();
                StartCoroutine(injectCoroutine);
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

        else if (other.tag == "Arm")
        {
            
            if (GameManager.Instance.orderFlag == 3)
            {
                
                StopCoroutine(injectCoroutine);
            }

        }
    }



}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerEventManager : MonoBehaviour
{
    public delegate void OnCollectArea();
    public static event OnCollectArea OnPaperCollect;
    public static printerManager printerManager;
    
    public delegate void OnDeskArea();
    public static event OnDeskArea OnPaperGive;
    public static workerManager workerManager;
    
    public delegate void OnMoneyArea(); 
    public static event OnMoneyArea OnMoneyCollected;   
    
    public delegate void OnBuyArea();
    public static event OnBuyArea OnBuyingDesk;
    public static buyArea areaToBuy;

    bool isCollecting, isGiving;

    void Start()
    {
        StartCoroutine(CollectEnum());
     }

    IEnumerator CollectEnum()
    {
        while(true)
        {
            if(isCollecting == true)
            {
                OnPaperCollect();
            }
            if(isGiving == true)
            {
                OnPaperGive();
            }

            yield return new WaitForSeconds(0.1f);
        } 
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Money"))
        {
            OnMoneyCollected();
            Destroy(other.gameObject);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Buy Area"))
        {
            OnBuyingDesk();
            areaToBuy = other.gameObject.GetComponent<buyArea>();
        }

        if(other.gameObject.CompareTag("CollectArea"))
        {
            isCollecting = true;
            printerManager = other.gameObject.GetComponent<printerManager>();
        }

        if(other.gameObject.CompareTag("WorkArea"))
        {
            isGiving = true;
            workerManager = other.gameObject.GetComponent<workerManager>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("CollectArea"))
        {
            isCollecting = false;
            printerManager = null;
        }

        if(other.gameObject.CompareTag("WorkArea"))
        {
            isGiving = false;
            workerManager = null;
        }

        if(other.gameObject.CompareTag("Buy Area"))
        {
            areaToBuy = null;
        }
    }
}












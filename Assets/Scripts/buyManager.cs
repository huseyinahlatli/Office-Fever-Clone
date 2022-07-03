using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buyManager : MonoBehaviour
{
    public int moneyCount = 0;

    private void OnEnable()
    {
        triggerEventManager.OnMoneyCollected += IncreaseMoney;
        triggerEventManager.OnBuyingDesk += BuyArea;
    }

    private void OnDisable()
    {
        triggerEventManager.OnMoneyCollected -= IncreaseMoney;
        triggerEventManager.OnBuyingDesk -= BuyArea;
    }

    void IncreaseMoney()
    {
        moneyCount += 50;
    }

    void BuyArea()
    {
        if(triggerEventManager.areaToBuy != null)
        {
            if(moneyCount > 1)
            {
                triggerEventManager.areaToBuy.Buy(1);
                moneyCount -= 1;
            }
        }
    }
}

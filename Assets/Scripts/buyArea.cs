using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buyArea : MonoBehaviour
{
    public GameObject deskGameObject, unlockPlane, unlockText; 
    public float cost, currentMoney;

    public void Buy(int goldAmount)
    {
        currentMoney += goldAmount;
        deskGameObject.SetActive(true);
        unlockPlane.SetActive(false);
        unlockText.SetActive(false);
        this.enabled = false;
    }
}

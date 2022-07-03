using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectManager : MonoBehaviour
{
    public List<GameObject> paperList = new List<GameObject>();
    public GameObject paperPrefab;
    public Transform collectPoint;
    private int paperLimit = 10;

    private void OnEnable()
    {
        triggerEventManager.OnPaperCollect += GetPaper;
        triggerEventManager.OnPaperGive += GivePaper;
    }
    
    private void OnDisable()
    {
        triggerEventManager.OnPaperCollect -= GetPaper;
        triggerEventManager.OnPaperGive -= GivePaper;
    }

    void GetPaper()
    {
        if(paperList.Count <= paperLimit)
        {
            GameObject temp = Instantiate(paperPrefab, collectPoint);
            temp.transform.position = new Vector3(collectPoint.position.x, (((float)paperList.Count / 20) + 0.5f), collectPoint.position.z);
            paperList.Add(temp);
            if(triggerEventManager.printerManager != null)
            {
                triggerEventManager.printerManager.RemoveLast();
            }
        }
    }

    public void RemoveLast()
    {
        if(paperList.Count != 0)
        {
            Destroy(paperList[paperList.Count - 1]);
            paperList.RemoveAt(paperList.Count - 1);
        }
    }

    public void GivePaper()
    {
        if(paperList.Count > 0)
        {
            triggerEventManager.workerManager.GetPaper();
            RemoveLast();
        }
    }
}












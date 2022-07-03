using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class workerManager : MonoBehaviour
{
    public List<GameObject> paperList = new List<GameObject>();
    public List<GameObject> moneyList = new List<GameObject>();
    public Transform paperPoint, moneyDropPoint;
    public GameObject paperPrefab, moneyPrefab;

    private void Start()
    {
        StartCoroutine(GenerateMoney());
    }

    IEnumerator GenerateMoney()
    {
        while(true)
        {
            if(paperList.Count > 0)
            {
                CreateMoney();    
                RemoveLast();    
            }
            yield return new WaitForSeconds(0.5f);
        }
    }

    public void CreateMoney()
    {
        GameObject temp = Instantiate(moneyPrefab);
        temp.transform.position = new Vector3(moneyDropPoint.position.x, ((float)moneyList.Count / 10), moneyDropPoint.position.z);
        moneyList.Add(temp);
    }

    public void GetPaper()
    {
        GameObject temp = Instantiate(paperPrefab);
        temp.transform.position = new Vector3(paperPoint.position.x, 0.8f + ((float)paperList.Count / 20), paperPoint.position.z);
        paperList.Add(temp);
    }

    public void RemoveLast()
    {
        if(paperList.Count != 0)
        {
            Destroy(paperList[paperList.Count - 1]);
            paperList.RemoveAt(paperList.Count - 1);
        }
    }
}

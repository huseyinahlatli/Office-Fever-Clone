using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class printerManager : MonoBehaviour
{
    public List<GameObject> paperList = new List<GameObject>(); 
    public GameObject paperPrefab; 
    public Transform exitPoint; 
    private bool isWorking; 
    private int stackCount = 10;

     void Start()
    {
        StartCoroutine(PrintPaper()); 
    }

    public void RemoveLast()
    {
        if(paperList.Count != 0)
        {
            Destroy(paperList[paperList.Count - 1]);
            paperList.RemoveAt(paperList.Count - 1);
        }
    }

    IEnumerator PrintPaper() 
    {
        while(true)
        {
            float paperCount = paperList.Count;
            int rowCount = (int) paperCount / stackCount;
            if(isWorking == true)
            {
                GameObject temp = Instantiate(paperPrefab); 
                temp.transform.position = new Vector3(exitPoint.position.x, (paperCount % stackCount) / 20, exitPoint.position.z  + (float)rowCount / -3);
                paperList.Add(temp);
                if(paperList.Count >= 30){
                    isWorking = false;
                }
            }
            else if(paperList.Count < 30){
               isWorking = true; 
            }
            yield return new WaitForSeconds(0.1f); 
        }
    }
}





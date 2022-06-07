using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
    public GameObject roadprefab;
    public float offset = 0.7f;

    public Vector3 lastPos;

    private int roadCount;

    public void StartBuilding()
    {
        InvokeRepeating("CreateNewRoad", 1f, 0.5f);
    }

    public void CreateNewRoad()
    {

        Vector3 spawnPos = Vector3.zero;

        int chance = Random.Range(1, 100);

        if (chance > 50)
        {
            spawnPos = new Vector3(lastPos.x + offset, lastPos.y, lastPos.z + offset);
        }
        else
        {
            spawnPos = new Vector3(lastPos.x - offset, lastPos.y, lastPos.z + offset);
        }

        GameObject g = Instantiate(roadprefab, spawnPos, Quaternion.Euler(0, 45, 0));

        lastPos = g.transform.position;

        roadCount++;

        if(roadCount % 5 ==0)
        {
            g.transform.GetChild(0).gameObject.SetActive(true);
            roadCount = 0;
        }
        
    }

    
}

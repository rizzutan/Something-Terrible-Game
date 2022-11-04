using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCraig : MonoBehaviour
{
    bool hasSpawnedCraig = false;
    public GameObject bootyCraig;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Craig()
    {
        if (!hasSpawnedCraig)
        {
            bootyCraig.SetActive(true);
            hasSpawnedCraig = true;
        }
    }
}

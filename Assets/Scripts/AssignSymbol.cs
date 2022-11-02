using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AssignSymbol : MonoBehaviour
{
    public GameObject[] symbols = new GameObject[5];
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 0 == 'CircleSymbol'
        // 1 == 'TriangleSymbol'
        // 2 == 'SquareSymbol'
        // 3 == 'HeartSymbol'
        // 4 == 'DiamondSymbol'


    }

    public void InstantiateFloatingSymbol(string symbolNumString, string letter)
    {
        for (int i = 0; i < 5; i++)
        {
            int symbolNum = (int)symbolNumString[i];
        }
    }
}

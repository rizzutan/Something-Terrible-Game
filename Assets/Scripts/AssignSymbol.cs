using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AssignSymbol : MonoBehaviour
{
    public GameObject[] symbols = new GameObject[5];
    public Vector3[] symbolPositions = new Vector3[5];
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // numbers to symbols
        // 1 == 'a key' == TriangleSymbol
        // 2 == 's key' == HeartSymbol
        // 3 == 'd key' == SquareSymbol
        // 4 == 'spacebar/p key' == DiamondSymbol
        // 5 == 'o key' == CircleSymbol


    }

    public void InstantiateFloatingSymbol(string symbolNumString, string letter)
    {
        for (int i = 0; i < 5; i++)
        {
            if (i < symbolNumString.Length)
            {
                int symbolNum = (int)symbolNumString[i];
            }
            GameObject symbol = Instantiate(symbols[i], symbolPositions[i], Quaternion.identity);
            symbol.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = letter[i].ToString();
        }
    }
}

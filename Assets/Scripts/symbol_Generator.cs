using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class symbol_Generator : MonoBehaviour
{
    public string symbolString = "";
    public int turnNum = 0;
    // Start is called before the first frame update
    void Start()
    {
        CreateSymbolString();
    }

    public void CreateSymbolString()
    {
        // 1 == 'w key'
        // 2 == 'a key'
        // 3 == 's key'
        // 4 == 'd key'
        // 5 == 'spacebar'
        int numOfSymbols = 5 + Random.Range(0, Mathf.Min(turnNum/2, 10));
        for (int i = 0; i < numOfSymbols; i++)
        {
            char symbol;
            int symbolNum = (Random.Range(1, 6));

            switch (symbolNum)
            {
                case 1:
                    symbol = 'W';
                    break;
                case 2:
                    symbol = 'A';
                    break;
                case 3:
                    symbol = 'S';
                    break;
                case 4:
                    symbol = 'D';
                    break;
                default:
                    symbol = 'P';
                    break;
            }
            symbolString += symbol;
        }
        Debug.Log("Symbol String: " + symbolString);
    }
}

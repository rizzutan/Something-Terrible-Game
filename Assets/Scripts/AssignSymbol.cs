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

    public void InstantiateFloatingSymbol(string word)
    {
        for (int i = 0; i < 5; i++)
        {
            GameObject symbol = Instantiate(symbols[i], symbolPositions[i] + new Vector3(Random.Range(-0.99f,1), Random.Range(-0.99f, 1), 0), Quaternion.identity);
            symbol.transform.localScale = Vector3.one * 0.4f;
            if (i < word.Length)
            {
                symbol.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = word[i].ToString();
            }
            else 
            {
                string alphabet = "fghjklnpqrstvwxyz";
                string randomLetter = alphabet[Random.Range(0, alphabet.Length-1)].ToString();
                symbol.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = randomLetter;
            }
            
        }
    }
}

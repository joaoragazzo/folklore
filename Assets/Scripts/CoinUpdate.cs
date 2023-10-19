using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinUpdate : MonoBehaviour
{
    private TextMeshProUGUI moneyCounter;
    // Start is called before the first frame update
    void Start()
    {
        moneyCounter = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        moneyCounter.text = "$ " + Player.money;
    }
}

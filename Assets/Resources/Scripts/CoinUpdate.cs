using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinUpdate : MonoBehaviour
{
    private PlayerInteraction playerInteraction = new PlayerInteraction();
    
    private TextMeshProUGUI moneyCounter;
    // Start is called before the first frame update
    void Start()
    {
        playerInteraction.Initialize();
        moneyCounter = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        moneyCounter.text = "$ " + playerInteraction.PlayerStats.Money;
    }
}

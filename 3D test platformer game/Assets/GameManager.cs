using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public int coinValue;
    public Text coinText;

	public void AddCoin(int coinToAdd)
    {
        coinValue += coinToAdd;
        coinText.text = "Coins: " + coinValue;
    }
}

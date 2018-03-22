using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GoldCoin : MonoBehaviour {

    public int value;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            FindObjectOfType<GameManager>().AddCoin(value);

            Destroy(gameObject);
        }
    }
}

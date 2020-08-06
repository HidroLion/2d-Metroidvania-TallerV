using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectablesManager : MonoBehaviour
{
    [SerializeField] private int coins = 0;
    [SerializeField] private Text coinsText;


   private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Collectable"))
        {
            Destroy(collider.gameObject);
            coins += 1;
            //coinsText.text = coins.ToString();
        }
    }
}

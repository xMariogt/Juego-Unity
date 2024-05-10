using System;
using System.Collections;
using System.Collections.Generic;
using Cainos.PixelArtPlatformer_VillageProps;
using UnityEditor.Tilemaps;
using UnityEngine;

public class CollectItem : MonoBehaviour
{
    public GameObject text;
    public GameObject item;
    public PlayerStats playerStats;
    public string itemType;
    
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            
            text.SetActive(true);
            Destroy(text, 1f);

            if (itemType == "key") {
                playerStats.hasKey = true;
            } else if (itemType == "sword") {

                playerStats.hasSword = true;
                Destroy(item, 2f);
            } else if (itemType == "tnt") {
                playerStats.hasTNT = true;
                Debug.Log("TNT");
            }
            Destroy(item);
        }

    }

}

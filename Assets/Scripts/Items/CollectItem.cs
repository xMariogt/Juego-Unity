using UnityEngine;

public class CollectItem : MonoBehaviour
{
    public GameObject text;
    public GameObject item;
    public PlayerStats playerStats;
    public string itemType;

    //Sonido
    public AudioClip recoger_vida;
    public AudioSource audioSource;

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
            } else if (itemType == "life"){
                playerStats.life += 1;
                audioSource.PlayOneShot(recoger_vida);
            }
            Destroy(item);
        }

    }

}

using UnityEngine;

public class CollectItem : MonoBehaviour
{
    public GameObject text;
    public GameObject item;
    public PlayerStats playerStats;
    public string itemType;
    
   

    public MessageController messageController;
    
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            
            text.SetActive(true);

            Destroy(text, 1f);
            if (itemType == "key") {
                playerStats.hasKey = true;
            } else if (itemType == "sword") {
                messageController.ShowMessage();
                playerStats.hasSword = true;
            } else if (itemType == "tnt") {
                playerStats.hasTNT = true;
            }
            
            Destroy(item);
        }

    }

}

using UnityEngine;

public class CollectItem : MonoBehaviour
{
    public GameObject text;
    public GameObject item;
    public PlayerStats playerStats;
    public string itemType;

    //Sonido
    public AudioClip recoger_vida;
    public AudioClip recoger_llave;
    public AudioClip recoger_tnt;
    public AudioClip recoger_tiempo;
    public AudioSource audioSource;
    public MessageController messageController;
    public PlayerRespawn playerRespawn;
    

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            
            text.SetActive(true);

            Destroy(text, 1f);
            if (itemType == "key") {
                playerStats.hasKey = true;
                audioSource.PlayOneShot(recoger_llave);
            } else if (itemType == "sword") {
                messageController.ShowMessage();
                playerStats.hasSword = true;
            } else if (itemType == "tnt") {
                playerStats.hasTNT = true;
                audioSource.PlayOneShot(recoger_tnt);
            } else if (itemType == "life"){
                playerStats.life++;
                playerRespawn.AgregarVidas();
                audioSource.PlayOneShot(recoger_vida);
            } else if (itemType == "time"){
                playerStats.tiempoRestante += 30;
                audioSource.PlayOneShot(recoger_tiempo);
            }
            
            Destroy(item);
        }

    }

}

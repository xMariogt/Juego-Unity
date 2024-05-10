using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAppear : MonoBehaviour
{

    public Animator animator;
    public PlayerStats playerStats;
    public MessageController messageController;
    public void SalirDelCofre()
    {
        animator.SetBool("ChestOpen", true);
        playerStats.hasSword = true;
        messageController.ShowMessage();
        Destroy(gameObject, 1f);
    }

   
}

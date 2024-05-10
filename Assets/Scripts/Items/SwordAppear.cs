using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAppear : MonoBehaviour
{

    public Animator animator;
    public PlayerAttack playerAttack;
    public MessageController messageController;
    public void SalirDelCofre()
    {
        animator.SetBool("ChestOpen", true);
        playerAttack.tieneEspada = true;
        messageController.ShowMessage();
        
    }

   
}

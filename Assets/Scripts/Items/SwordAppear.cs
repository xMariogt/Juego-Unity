using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAppear : MonoBehaviour
{

    public Animator animator;
    
    public void SalirDelCofre()
    {
        animator.SetBool("ChestOpen", true);
        StartCoroutine(Esperar());
    }

    private IEnumerator Esperar()
    {
        yield return new WaitForSeconds(1f);
        this.GetComponent<Collider2D>().enabled = true;    
    }

   
}

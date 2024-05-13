using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Transform attackPoint;
    [SerializeField] private float attackRange;
    [SerializeField] private float damage;

    public PlayerStats playerStats;

    private Animator animator;
    public DetonarTNT detonaTNT;

    //Sonido
    public AudioClip espada;
    private AudioSource audioSource;

    private void Start() {
        animator = GetComponent<Animator>();
        animator.SetBool("TieneEspada", true);
        audioSource = GetComponent<AudioSource>();
    }

    private void OnAttack() {
        if (playerStats.hasSword && animator.GetCurrentAnimatorStateInfo(0).IsName("Attack") == false){
            StartCoroutine(RealizaEspadazo());
            animator.SetTrigger("Attack");
            audioSource.PlayOneShot(espada);
        } else if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack") == true) {
            
        }
        if (playerStats.hasTNT) {
            detonaTNT.Detonar();
        }
    }


    private void Espadazo () {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange);
        foreach (Collider2D enemy in hitEnemies) {
            if (enemy.CompareTag("Enemy")) {
                enemy.GetComponent<Enemy>().TakeDamage(damage);
            }
        }
    }

    private IEnumerator RealizaEspadazo() {
        yield return new WaitForSeconds(0.2f);
        Espadazo();
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}

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

    private void Start() {
        animator = GetComponent<Animator>();
        animator.SetBool("TieneEspada", true);
    }

    private void OnAttack() {
        if (playerStats.hasSword){
            hit();
        }
        if (playerStats.hasTNT) {
            detonaTNT.Detonar();
            Debug.Log("Detonar");
        }
    }


    private void hit () {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange);
        animator.SetTrigger("Attack");
        
        foreach (Collider2D enemy in hitEnemies) {
            if (enemy.CompareTag("Enemy")) {
                enemy.GetComponent<Enemy>().TakeDamage(damage);
            }
        }
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}

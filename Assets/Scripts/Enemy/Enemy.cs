using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float life;
    private Animator animator;

    private void Start() {
        animator = GetComponent<Animator>();
    }



    public void TakeDamage(float damage) {
        life -= damage;
        if (life <= 0) {
            Die();
        }
    }

    private void Die() {
        animator.SetTrigger("Die");
        Destroy(gameObject, 1f);
    }
}

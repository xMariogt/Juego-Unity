using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float life;
    private Animator animator;
    

    //Sonido
    public AudioClip bat_die;
    private AudioSource audioSource;

    private void Start() {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }



    public void TakeDamage(float damage) {
        life -= damage;
        if (life <= 0) {
            Die();
        }
    }

    private void Die() {
        new WaitForSeconds(0.5f);
        audioSource.PlayOneShot(bat_die);
        animator.SetTrigger("Die");
        Destroy(gameObject, 0.8f);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cainos.LucidEditor;

namespace Cainos.PixelArtPlatformer_VillageProps
{
    public class Chest : MonoBehaviour
    {
        public SwordAppear sword;
        public GameObject swordObject;
        public AudioClip openChest;
        private AudioSource audioSource;

        [FoldoutGroup("Reference")]
        public Animator animator;
        public GameObject texto;

        public PlayerStats playerStats;

        [FoldoutGroup("Runtime"), ShowInInspector, DisableInEditMode]
        public bool IsOpened
        {
            get { return isOpened; }
            set
            {
                isOpened = value;
                animator.SetBool("IsOpened", isOpened);
            }
        }
        private bool isOpened;

        private void Start()
        {
            // Asegurémonos de que el GameObject tenga un componente AudioSource
            audioSource = GetComponent<AudioSource>();
            if (audioSource == null)
            {
                audioSource = gameObject.AddComponent<AudioSource>();
            }

            // Configuramos el clip de audio
            audioSource.clip = openChest;
        }

        [FoldoutGroup("Runtime"),Button("Open"), HorizontalGroup("Runtime/Button")]
        public void Open()
        {
            IsOpened = true;
            audioSource.Play();
        }

        [FoldoutGroup("Runtime"), Button("Close"), HorizontalGroup("Runtime/Button")]
        public void Close()
        {
            IsOpened = false;
        }

        //al tocar a un jugador, se abre
        public void OnTriggerEnter2D(Collider2D player)
        {
            if (player.CompareTag("Player") && !IsOpened && playerStats.hasKey)
            {
                swordObject.SetActive(true);
                Open();
                sword.SalirDelCofre();
                
            } else {
                if (!IsOpened && !playerStats.hasKey) {
                    texto.SetActive(true);
                }
            }
        }

        private void OnTriggerExit2D(Collider2D player) {
            
            texto.SetActive(false);
            
        }
    }

    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ColectedCoin : MonoBehaviour
{
    [SerializeField] private string nomeDolevelDeJogo;

   public AudioSource coinFX; 

   void OnTriggerEnter(Collider other){
        CollactableControl.coinCount += 1;
        coinFX.Play();
        this.gameObject.SetActive(false);
        
   }
}

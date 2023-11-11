using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private string nomeDolevelDeJogo;

    [SerializeField] private GameObject painelMenuInicial;

    [SerializeField] private GameObject painelOpcoes;

    public void jogar(){
        SceneManager.LoadScene(nomeDolevelDeJogo);
    }

    public void AbrirOpcoes(){
        painelMenuInicial.SetActive(false);
        painelOpcoes.SetActive(true);
    }

    public void FecharOpcoes(){
        painelOpcoes.SetActive(false);
        painelMenuInicial.SetActive(true);
    }

    public void SairJogo() {
        Debug.Log("Sair do jogo");
        Application.Quit();
    }
}

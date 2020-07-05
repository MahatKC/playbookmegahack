using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class dialogoPeixinhoController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject inputNome;
    public GameObject textCor;
    public GameObject inputCor;
    public GameObject textEnd;

    public GameObject textoAbertura;

    public GameObject dialogoNome;
    public GameObject dialogoCor;
    public GameObject dialogoFim;

    public GameObject objetosGame;

    public GameObject peixinho;
    void Start()
    {
        dialogoNome.SetActive(false);
        dialogoCor.SetActive(false);
        dialogoFim.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void playDialogoNome()
    {
        if (gameState.peixinhoClicavel)
        {
            dialogoNome.SetActive(true);
        }
    }
    public void catchName()
    {
        gameState.nomePlayer = inputNome.GetComponent<Text>().text;
        if (gameState.nomePlayer == null)
            return;
        textCor.GetComponent<Text>().text = "Que legal te conhecer " + char.ToUpper(gameState.nomePlayer[0]) + gameState.nomePlayer.Substring(1) + "! \nQual sua cor preferida?";
        dialogoNome.GetComponent<Animator>().SetBool("disseNome", true);
        dialogoCor.SetActive(true);
        Debug.Log(gameState.nomePlayer);
    }
    public void catchCor()
    {
        gameState.corPreferida = inputCor.GetComponent<Text>().text;
        if (gameState.corPreferida == null)
            return;
        dialogoCor.GetComponent<Animator>().SetBool("disseCor", true);
        textEnd.GetComponent<Text>().text =  char.ToUpper(gameState.corPreferida[0]) + gameState.corPreferida.Substring(1) + " que legal!\nA minha cor preferida é amarelo.\nVamos brincar?";
        dialogoFim.SetActive(true);
    }

    public void nextScene()
    {
        dialogoFim.SetActive(false);
        textoAbertura.SetActive(false);
        foreach (Transform child in objetosGame.GetComponent<Transform>())
        {
            child.GetComponent<objectControllerScen>().vaiDestino = true;
        }
        peixinho.GetComponent<PeixinhoController>().vaiDestino = true;
        peixinho.GetComponent<SpriteRenderer>().flipX = false;

    }

    public void teste()
    {
        Debug.Log("TESTE");
    }

}

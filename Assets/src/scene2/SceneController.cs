using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class SceneController : MonoBehaviour
{
    int sceneState;

    public GameObject inicial;
    public GameObject cronometro;
    public GameObject tentarDeNovo;
    public GameObject conseguiu;
    public GameObject algaVerde;
    public GameObject objetosGame;
    public GameObject destinoPeixinho;
    public GameObject peixinho;

    bool nada = false;
    float angleNada = 20f;
    float nadaTime = 0, updateTime = 0.4f;

    float atTime = 0f;

    public int timeToEnd;

    // Start is called before the first frame update
    void Start()
    {
        cronometro.SetActive(false);
        tentarDeNovo.SetActive(false);
        conseguiu.SetActive(false);
        timeToEnd = 20;
    }

    // Update is called once per frame
    void Update()
    {
        switch(sceneState)
        {
            case 1: // Abertura
                break;
            case 2: // Mini Game
                atTime += Time.deltaTime;
                P2MiniGame();
                break;
            case 3: // Em espera
                break;
            case 4:
                P4TransicaoFinal();
                break;
            case 5:
                atTime += Time.deltaTime;
                if (((int)atTime) >= 3)
                {
                    sceneState = 4;
                    nada = true;
                }
                break;
        }
        if (nada)
        {
            nadaTime += Time.deltaTime;
            peixinho.transform.rotation = Quaternion.Slerp(peixinho.transform.rotation, Quaternion.Euler(0f, 0f, angleNada), Time.deltaTime * 5f);

            if (nadaTime >= updateTime)
            {
                angleNada = -angleNada;
                nadaTime = 0f;
                Debug.Log("moveu");
            }
        }
    }

    public void botaoIniciar()
    {
        inicial.SetActive(false);
        cronometro.SetActive(true);
        gameState.s2Clicavel = true;
        atTime = 0;
        sceneState = 2;
    }


    public void tentar()
    {
        tentarDeNovo.SetActive(false);
        cronometro.SetActive(true);
        atTime = 0;
        sceneState = 2;
        gameState.s2Clicavel = true;
    }

    void P2MiniGame()
    {
        int tempoCronometro = +(timeToEnd - (int)atTime);
        cronometro.GetComponent<Text>().text = "" + tempoCronometro;
        if(tempoCronometro > 5 && tempoCronometro <= 10)
        {
            cronometro.GetComponent<Text>().color = new Color(0.9f, 0.4f, 0f);
        }
        else if(tempoCronometro <= 5)
        {
            cronometro.GetComponent<Text>().color = new Color(255f, 0f, 0f);
        }
        else
        {
            cronometro.GetComponent<Text>().color = new Color(0f, 0f, 0f);
        }
        if (tempoCronometro == 0)
        {
            sceneState = 3;
            cronometro.SetActive(false);
            tentarDeNovo.SetActive(true);
            gameState.s2Clicavel = false;
        }
    }

    void P4TransicaoFinal()
    {
        peixinho.transform.position = Vector3.MoveTowards(peixinho.transform.position, destinoPeixinho.transform.position, 2f * Time.deltaTime);

        if (Vector3.Distance(peixinho.GetComponent<Transform>().position, destinoPeixinho.transform.position) < 0.001f)
        {
            nada = false;
            peixinho.transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0f, 180f, 0f), Time.deltaTime * 500000f);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void clicouPerola()
    {
        if (algaVerde.GetComponent<AnimatorObject>().isUp)
        {
            sceneState = 3;
            cronometro.SetActive(false);
            conseguiu.SetActive(true);
            algaVerde.GetComponent<AnimatorObject>().achou = true;
            gameState.s2Clicavel = false;
        }
    }

    public void botaoContinuar()
    {
        conseguiu.GetComponent<Animator>().SetBool("some", true);
        foreach (Transform child in objetosGame.GetComponent<Transform>())
        {
            child.GetComponent<Animator>().SetBool("ganhou", true);
        }
        sceneState = 5;
    }
}

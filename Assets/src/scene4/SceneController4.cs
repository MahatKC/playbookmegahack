using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController4 : MonoBehaviour
{
    // Start is called before the first frame update
    AudioSource audioSource;
    float atTime = 0f;
    int sceneState = 1, timeToEnd = 15;
    AudioClip recording;

    public GameObject inicial, cronometro, ouvir, botaoGravar, textoGravando, botaoOuvir, gravarDeNovo, vamosLa, peixinho, destino1, destino2, destino3, destino4, origemPeixinho, peixinhoDancar;
    GameObject[] destino;
    int indexDestino = 0;
    float angleNada = 60f, rotationInit = 0f, rotationCount = 0f;
    private float startRecordingTime;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        destino = new GameObject[4] { destino1, destino2, destino3, destino4};
    }

    // Update is called once per frame
    void Update()
    {
        switch (sceneState)
        {
            case 1:
                break;
            case 2: // Gravando Audio
                atTime += Time.deltaTime;
		GameObject.FindGameObjectWithTag("music").GetComponent<amusicanaopara>().StopMusic();
                P1Gravar();
                break;
            case 3: // Estado de Espera
                break;
            case 4: // Tocando Audio
                atTime += Time.deltaTime;
                int timeRem = timeToEnd - (int)atTime;
                Debug.Log(timeRem);
                if (timeRem <= 0)
                {
                    Debug.Log("finalizou");
                    Microphone.End("");
                    sceneState = 3;
                    ouvir.SetActive(false);
                    gravarDeNovo.SetActive(true);
                    botaoOuvir.GetComponent<Button>().interactable = true;
                }
                break;
            case 5: // Dançinha
                atTime += Time.deltaTime;
                rotationInit += Time.deltaTime;
                P5dancinha();
                if(((int)atTime) >= timeToEnd)
                {
                    sceneState = 6;
                }
                break;
            case 6:
                P6voltar();
                break;
            case 7:
                atTime += Time.deltaTime;
                if (((int)atTime) >= 3)
                {
                    sceneState = 5;
                    atTime = 0;
                    peixinhoDancar.SetActive(false);
                    playAudio();
                }
                break;
            case 8:
                break;
        }

    }

    public void buttonDeNovo()
    {
        gravarDeNovo.SetActive(false);
        vamosLa.SetActive(true);
        botaoGravar.SetActive(true);
    }

    public void buttonOuvir()
    {
        botaoOuvir.GetComponent<Button>().interactable = false;
        playAudio();
        atTime = 0;
        sceneState = 4;
    }

    public void buttonGravar()
    {
        cronometro.SetActive(true);
        botaoGravar.GetComponent<Button>().interactable = false;
        textoGravando.GetComponent<Text>().text = "Gravando";
        atTime = 0;
        sceneState = 2;
        gravarAudio();
    }

    public void buttonQueroEssa()
    {
        gravarDeNovo.SetActive(false);
        peixinhoDancar.SetActive(true);
        sceneState = 7;
        atTime = 0;
    }

    void P1Gravar()
    {
        int tempoCronometro = +(timeToEnd - (int)atTime);
        cronometro.GetComponent<Text>().text = "" + tempoCronometro;
        if (tempoCronometro > 5 && tempoCronometro <= 10)
        {
            cronometro.GetComponent<Text>().color = new Color(0.9f, 0.4f, 0f);
        }
        else if (tempoCronometro <= 5)
        {
            cronometro.GetComponent<Text>().color = new Color(255f, 0f, 0f);
        }
        else
        {
            cronometro.GetComponent<Text>().color = new Color(0f, 0f, 0f);
        }
        if (tempoCronometro == 0)
        {
            Microphone.End("");
            sceneState = 3;
            cronometro.SetActive(false);
            inicial.SetActive(false);
            botaoGravar.GetComponent<Button>().interactable = true;
            textoGravando.GetComponent<Text>().text = "Gravar";
            botaoGravar.SetActive(false);
            vamosLa.SetActive(false);

            ouvir.SetActive(true);
        }
    }

    void P5dancinha()
    {
        int intTime = (int)atTime;
        Debug.Log(intTime);
        peixinho.GetComponent<Transform>().position = Vector3.MoveTowards(peixinho.GetComponent<Transform>().position, destino[indexDestino].transform.position, 2f * Time.deltaTime);
        peixinho.GetComponent<Transform>().rotation = Quaternion.Slerp(peixinho.GetComponent<Transform>().rotation, Quaternion.Euler(0f, 180f, angleNada), Time.deltaTime * 5f);

        if (rotationInit >= rotationCount)
        {
            angleNada = -angleNada;
            rotationCount = rotationInit + 0.4f;
            Debug.Log("moveu");
        }
        if (Vector3.Distance(peixinho.GetComponent<Transform>().position, destino[indexDestino].transform.position) < 0.001f)
        {
            indexDestino = ((indexDestino + 1) % 4);
        }
    }

    void P6voltar()
    {
        peixinho.transform.position = Vector3.MoveTowards(peixinho.transform.position, origemPeixinho.transform.position, 2f * Time.deltaTime);
        peixinho.transform.rotation = Quaternion.Slerp(peixinho.transform.rotation, Quaternion.Euler(0f, 180f, 0f), Time.deltaTime * 30f);

        if (Vector3.Distance(peixinho.GetComponent<Transform>().position, origemPeixinho.transform.position) < 0.001f)
        {
            sceneState = 8;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

    }

    void gravarAudio()
    {
        audioSource.clip = Microphone.Start("", true, timeToEnd, 44100);
    }

    void playAudio()
    {
        audioSource.Play();
        
    }
}

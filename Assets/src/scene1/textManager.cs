using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class textManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject text1;
    public GameObject text2;
    public GameObject text3;

    private bool showText1 = false;
    private bool showText2 = false;
    private bool showText3 = false;

    public GameObject dialogoPeixinhoManager;

    float tempoAt = 0;

    void Start()
    {
        text1.SetActive(false);
        text2.SetActive(false);
        text3.SetActive(false);
        gameState.peixinhoClicavel = false;
    }

    // Update is called once per frame
    void Update()
    {
        tempoAt += Time.deltaTime;

        if( (tempoAt >= 2.0f) && !showText1){
            showText1 = true;
            text1.SetActive(true);
        }

        if ((tempoAt >= 5.0f) && !showText2)
        {
            showText2 = true;
            text2.SetActive(true);
        }

        if ((tempoAt >= 8.0f) && !showText3)
        {
            showText3 = true;
            text3.SetActive(true);
            gameState.peixinhoClicavel = true;
        }
    }
}

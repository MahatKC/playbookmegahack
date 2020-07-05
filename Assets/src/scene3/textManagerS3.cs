using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class textManagerS3 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject text1;
    public GameObject text2;
    public GameObject text3;

	public GameObject inho1, inho2, button1, control;

    private bool showText1 = false;
    private bool showText2 = false;
    private bool showText3 = false;

    public float tempoAt = 0f;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        tempoAt += Time.deltaTime;

        if( (tempoAt >= 2.0f) && !showText1){           
            text1.SetActive(true);
		showText1 = true;
        }

        if ((tempoAt >= 5.0f) && !showText2)
        {
            showText2 = true;
            text2.SetActive(true);
        }

        if ((tempoAt >= 9.0f) && !showText3)
        {
            showText3 = true;
            text3.SetActive(true);
		    inho1.SetActive(true);
		    inho2.SetActive(true);
		    button1.SetActive(true);
		    control.GetComponent<scenecontroller3>().click1 = true;
            gameState.peixinhoClicavel = true;
        }
    }
}

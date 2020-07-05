using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class textManagerS5 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject text1;
    public GameObject text2;

	public GameObject vento, button1, text7, text8, button5;
	public AudioSource musicatensa;
	public bool textofinal = false;

    private bool showText1 = false;
    private bool showText2 = false;
	private bool showText7 = false;
    private bool showText8 = false;

    public float tempoAt = 0;

    // Update is called once per frame
    void Update()
    {
        if(!textofinal){
		tempoAt += Time.deltaTime;

		if( (tempoAt >= 2.0f) && !showText1){
		    text1.SetActive(true);
			vento.GetComponent<ventoanimation>().animationstage = 10;
			showText1 = true;
		}

		if ((tempoAt >= 5.0f) && !showText2)
		{        
		    text2.SetActive(true);
			button1.SetActive(true);
			musicatensa.Play();
			showText2 = true;
		}
	}
	else{
		tempoAt += Time.deltaTime;
		if( (tempoAt >= 2.0f) && !showText7){
		    text7.SetActive(true);
			showText7 = true;
		}

		if ((tempoAt >= 5.0f) && !showText8)
		{        
			text8.SetActive(true);
			button5.SetActive(true);
			showText8 = true;
		}	
	}
    }
}

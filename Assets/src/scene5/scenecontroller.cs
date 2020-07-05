using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scenecontroller : MonoBehaviour
{
    	public int pedracounter = 0;
	public GameObject Lanes, peixe, npedra1, npedra2, button1, txt3, button2, button3, button4, txt4, txt6, vento, button5;
	public GameObject[] pedras;
	public static int rng = 0;
	public bool done = false, freeze = false, contagem_comeca_pedras = false;
	public float tempo_comeca_pedras = 0f;
		

	// Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
	if(contagem_comeca_pedras){	
		tempo_comeca_pedras += Time.deltaTime;        
		if (tempo_comeca_pedras > 1.5f)
		{
			comecapedras();
			tempo_comeca_pedras = 0f;	    
			contagem_comeca_pedras = false;
		}
	}
    }

	public void continue_click1(){
		txt3.SetActive(true);		
		button1.SetActive(false);
		contagem_comeca_pedras = true;
	}
	public void sim_click(){
		txt3.SetActive(true);
		txt4.SetActive(false);
		button2.SetActive(false);
		button3.SetActive(false);		
		contagem_comeca_pedras = true;
	}
	public void nao_click(){
		txt6.SetActive(true);
		button4.SetActive(true);
		button2.SetActive(false);
		button3.SetActive(false);
		txt4.SetActive(false);
	}
	public void continue_click2(){	
		button4.SetActive(false);
		vento.GetComponent<ventoanimation>().animationstage = 1;
	}
	public void continue_click3(){	
		button5.SetActive(false);
		SceneManager.LoadScene("cena6", LoadSceneMode.Single);
	}
	
	public void nextstep(){
		if((pedracounter>=0) && (pedracounter <5)){
			addumapedra(peixe.GetComponent<movimentopeixinho>().lane);			
		}
		else if(pedracounter < 10){
			addduaspedra(peixe.GetComponent<movimentopeixinho>().lane);
		}
		else{
			done = true;
		}
	}

	public void addumapedra(int lanepeixe){
		npedra1 = (GameObject)Instantiate(pedras[lanepeixe-1]);
		npedra1.SetActive(true);
		npedra1.GetComponent<pedra1movement>().startmoving();
		pedracounter++;
	}

	public void addduaspedra(int lanepeixe){
		do{
			rng = ((Random.Range(1, 100000)) % 3)+1;
		}while(rng == lanepeixe);
		npedra2 = (GameObject)Instantiate(pedras[rng-1]);
		npedra2.SetActive(true);
		npedra2.GetComponent<pedra1movement>().setsecondstone();
		npedra2.GetComponent<pedra1movement>().startmoving();
		addumapedra(lanepeixe);
	}	

	public void comecapedras(){
		peixe.GetComponent<movimentopeixinho>().speed*=7;
		freeze = false;
		pedracounter = 0;		
		Lanes.SetActive(true);
		nextstep();
	}
}

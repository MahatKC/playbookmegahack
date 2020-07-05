using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class scenecontroller3 : MonoBehaviour
{
    public GameObject circulo, button1, peixe_new, peixao_new;
	public bool allow_drag = false, click1 = false, click2 = false;

// Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
	if (peixe_new.GetComponent<friendout>().done == true){
		SceneManager.LoadScene("cena4", LoadSceneMode.Single);
	}
    }

	public void comecacirculo(){
		if(click1){		
			button1.SetActive(false);		
			circulo.SetActive(true);
			circulo.GetComponent<animacirculo>().animastage = 1;
			click1 = false;
		}
		if(click2){		
			button1.SetActive(false);		
			//muda de cena
			peixe_new.GetComponent<friendout>().move = true;
			peixao_new.GetComponent<friendout>().move = true;
			click2 = false;
		}	
	}
}

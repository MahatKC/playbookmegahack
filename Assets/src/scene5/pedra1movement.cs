using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pedra1movement : MonoBehaviour
{
    
	public float speed = 1f;
	private bool move = false, secondstone = false;
	public GameObject pedra, npedra, control, Lanes, peixinho, txt1, txt2, txt3, txt4, button2, button3, txt5, button4;

// Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
	if((move)&&(!control.GetComponent<scenecontroller>().freeze)){
		transform.Translate(Vector3.right * Time.deltaTime * speed);			//faz a pedra se mover
	}
	if(control.GetComponent<scenecontroller>().freeze){
		Destroy(pedra);	
	}
    }
	
	void OnCollisionEnter(Collision collision)			//faz a pedra parar de se mover
 	{
	 	
		peixinho.GetComponent<movimentopeixinho>().selecionalane(1);			
		control.GetComponent<scenecontroller>().freeze = true;
		txt4.SetActive(true);
		button2.SetActive(true);
		button3.SetActive(true);
		txt1.SetActive(false);
		txt2.SetActive(false);		
		txt3.SetActive(false);
		Lanes.SetActive(false);
		peixinho.GetComponent<movimentopeixinho>().speed/=7;
        }

	void OnTriggerEnter(Collider col){
		if((col.transform.tag == "meio")&&(!secondstone)){
			control.GetComponent<scenecontroller>().nextstep();			
		}
		
	}
	void OnTriggerExit(Collider col){
		if(col.transform.tag == "fim"){		
			Destroy(pedra);
			if (control.GetComponent<scenecontroller>().done){
				peixinho.GetComponent<movimentopeixinho>().speed/=2.65f;
				peixinho.GetComponent<movimentopeixinho>().selecionalane(1);
				peixinho.GetComponent<movimentopeixinho>().tiralane = true;
				txt1.SetActive(false);
				txt2.SetActive(false);		
				txt3.SetActive(false);
				txt5.SetActive(true);
				button4.SetActive(true);		
			}
		}
	}
	public void startmoving(){
		move = true;
	}
	public void setsecondstone(){
		secondstone = true;	
	}
}

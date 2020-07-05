using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animacirculo : MonoBehaviour
{
    public int animastage = 0;
	public float speed = 1f;
	public GameObject cauda, pos_ao, inho1, ao, circulo, hiddenspot, control, peixao, peixao_new, txt1, txt2, txt3, txt4, inho1_tot;
	public AudioSource transforma;

// Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch(animastage){
		case 1: ao_to_middle(); break;
		case 2: hide(); break;
		case 3: circ_to_inho(); break;
		case 4: inho_to_cauda(); break;
		case 5: circ_out(); break;
		default: break;	
	}
    }

	public void ao_to_middle(){
		ao.GetComponent<aocomcirculo>().vai = true;		
		transform.position = Vector3.MoveTowards(transform.position, pos_ao.transform.position, speed*Time.deltaTime);
		if(Vector3.Distance(transform.position, pos_ao.transform.position) < 0.001f){
			animastage = 2;
			ao.GetComponent<aocomcirculo>().vai = false;
		}	
	}
	public void hide(){
		transform.position = hiddenspot.transform.position;
		circulo.GetComponent<Renderer>().enabled = false;
		animastage = 3;
				
	}
	
	
	public void circ_to_inho(){
		transform.position = Vector3.MoveTowards(transform.position, inho1.transform.position, speed*Time.deltaTime);
		if(Vector3.Distance(transform.position, inho1.transform.position) < 0.001f){
			circulo.GetComponent<Renderer>().enabled = true;
			animastage = 4;
		}
	}
	public void inho_to_cauda(){
		transform.position = Vector3.MoveTowards(transform.position, cauda.transform.position, speed*Time.deltaTime);
		if(Vector3.Distance(transform.position, cauda.transform.position) < 0.001f){
			animastage = 5;
		}
	}	
	public void circ_out(){
		Destroy(inho1_tot);
		Destroy(ao);
		Destroy(peixao);
		peixao_new.GetComponent<Renderer>().enabled = true;
		transforma.Play();
		control.GetComponent<scenecontroller3>().allow_drag = true;
		Destroy(txt1);
		Destroy(txt2);
		Destroy(txt3);
		txt4.SetActive(true);	
		animastage = 6;
		Destroy(circulo);
	}
}

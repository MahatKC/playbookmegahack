using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ventoanimation : MonoBehaviour
{
    
	public int animationstage = 0;
	public float speed = 1f, smooth = 5.0f;
	public GameObject inho, vento, esquerda, direita, cauda, placeholderpeixe, ao, peixao, pos_ini_vento, txtManager;
	public AudioSource transformation;

	// Start is called before the first frame update
    void Start()
    {
	
    }

    // Update is called once per frame
    void Update()
    {
        switch(animationstage){
		case 10: a_wild_vento_appears(); break;		
		case 1: vento_to_inho(); break;
		case 2: inho_out(); break;
		case 3: quantum_teleportation(); break;
		case 4: ao_in(); break;
		case 5: vento_out(); break;
		default: break;	
	}
    }
	
	public void a_wild_vento_appears(){
		transform.position = Vector3.MoveTowards(transform.position, pos_ini_vento.transform.position, speed*Time.deltaTime);
		vento.transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0f, 0f, -25.932f), Time.deltaTime * smooth*2);
		if(Vector3.Distance(transform.position, pos_ini_vento.transform.position) < 0.001f){
			animationstage = 11;
		}
	}

	public void vento_to_inho(){
		transform.position = Vector3.MoveTowards(transform.position, inho.transform.position, speed*Time.deltaTime);
		vento.transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0f, 0f, 0f), Time.deltaTime * smooth);
		if(Vector3.Distance(transform.position, inho.transform.position) < 0.001f){
			//vento.transform.rotation.z = -25.339f;
			animationstage = 2;
		}
	}
	public void inho_out(){
		transform.position = Vector3.MoveTowards(transform.position, esquerda.transform.position, speed*Time.deltaTime);
		vento.transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0f, 0f, 25.339f), Time.deltaTime * smooth);
		if(Vector3.Distance(transform.position, esquerda.transform.position) < 0.001f){
			animationstage = 3;
		}	
	}
	public void quantum_teleportation(){
		transform.position = direita.transform.position;
		transform.rotation = Quaternion.Euler(0f, 0f, 16.766f);
		animationstage = 4;
	}
	public void ao_in(){
		transform.position = Vector3.MoveTowards(transform.position, cauda.transform.position, speed*Time.deltaTime);
		vento.transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0f, 0f, 0f), Time.deltaTime * smooth * 0.7f);		
		if(Vector3.Distance(transform.position, cauda.transform.position) < 0.001f){
			animationstage = 5;
			transformation.Play();
			ao.GetComponent<Renderer>().enabled = false;
			placeholderpeixe.GetComponent<Renderer>().enabled = false;
			peixao.GetComponent<Renderer>().enabled = true;
		}
	}	
	public void vento_out(){
		transform.position = Vector3.MoveTowards(transform.position, esquerda.transform.position, speed*Time.deltaTime);
		vento.transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0f, 0f, 25.339f), Time.deltaTime * smooth);		
		if(Vector3.Distance(transform.position, esquerda.transform.position) < 0.001f){
			animationstage = 0;
			txtManager.GetComponent<textManagerS5>().textofinal = true;
			txtManager.GetComponent<textManagerS5>().tempoAt = 0f;
		}
	}
}

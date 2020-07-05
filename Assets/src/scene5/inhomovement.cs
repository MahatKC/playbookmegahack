using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inhomovement : MonoBehaviour
{
	public GameObject vento, esquerda, inho;    
	
		

	// Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(vento.GetComponent<ventoanimation>().animationstage == 2){
		transform.position = Vector3.MoveTowards(transform.position, esquerda.transform.position, vento.GetComponent<ventoanimation>().speed*Time.deltaTime);
		inho.transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0f, 0f, 25.339f), Time.deltaTime * vento.GetComponent<ventoanimation>().smooth);
	}
    }
}

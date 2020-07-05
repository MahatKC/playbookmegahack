using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inhocomcirculo : MonoBehaviour
{
    public GameObject circulo, cauda;

  // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(circulo.GetComponent<animacirculo>().animastage == 4){
		inho_to_cauda();
	}
    }

	public void inho_to_cauda(){
		transform.position = Vector3.MoveTowards(transform.position, cauda.transform.position, circulo.GetComponent<animacirculo>().speed*Time.deltaTime);
	}
}

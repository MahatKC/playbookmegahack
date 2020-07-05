using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aocomcirculo : MonoBehaviour
{
  public GameObject circulo, pos_ao;
	public bool vai = false;

  // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(vai){
		ao_to_middle();
	}
    }

	public void ao_to_middle(){
		transform.position = Vector3.MoveTowards(transform.position, pos_ao.transform.position, circulo.GetComponent<animacirculo>().speed*Time.deltaTime);
	}
}

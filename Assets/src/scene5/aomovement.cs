using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aomovement : MonoBehaviour
{
	public GameObject vento, cauda, ao;    
	
		

	// Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(vento.GetComponent<ventoanimation>().animationstage == 4){
		transform.position = Vector3.MoveTowards(transform.position, cauda.transform.position, vento.GetComponent<ventoanimation>().speed*Time.deltaTime);
		ao.transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0f, 0f, 0f), Time.deltaTime * vento.GetComponent<ventoanimation>().smooth * 0.7f);
	}
    }
}

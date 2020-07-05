using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class friendout : MonoBehaviour
{
    public GameObject path1, path2, peixe, peixinho;
	public float speed = 1f;
	public bool move = false, leave = false, done = false;

	// Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (move){
		peixe.transform.position = Vector3.MoveTowards(peixe.transform.position, path1.transform.position, speed*Time.deltaTime);
		if(Vector3.Distance(peixe.transform.position, path1.transform.position) < 0.001f){
			leave = true;
			move = false;
			peixinho.GetComponent<SpriteRenderer>().flipX = true;
		}
	}
	if (leave){
		peixe.transform.position = Vector3.MoveTowards(peixe.transform.position, path2.transform.position, speed*Time.deltaTime);
		if(Vector3.Distance(peixe.transform.position, path2.transform.position) < 0.001f){
			done = true;			
			leave = false;
		}
		
	}
    }

	
}

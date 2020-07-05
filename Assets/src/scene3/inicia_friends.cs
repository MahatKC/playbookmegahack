using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inicia_friends : MonoBehaviour
{
	public GameObject peixe, e, peixao, ao, pos_ini_ao, pos_ini_e, pos_ini_peixe, pos_ini_peixao;
	public bool move = false;
	public float speed = 1f;    
	
// Start is called before the first frame update
    void Start()
    {
        move = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(move){
		peixe.transform.position = Vector3.MoveTowards(peixe.transform.position, pos_ini_peixe.transform.position, speed*Time.deltaTime);
		e.transform.position = Vector3.MoveTowards(e.transform.position, pos_ini_e.transform.position, speed*Time.deltaTime);
		ao.transform.position = Vector3.MoveTowards(ao.transform.position, pos_ini_ao.transform.position, speed*Time.deltaTime);
		peixao.transform.position = Vector3.MoveTowards(peixao.transform.position, pos_ini_peixao.transform.position, speed*Time.deltaTime);
		if((Vector3.Distance(peixe.transform.position, pos_ini_peixe.transform.position) < 0.001f)&&
		(Vector3.Distance(e.transform.position, pos_ini_e.transform.position) < 0.001f)&&
		(Vector3.Distance(peixao.transform.position, pos_ini_peixao.transform.position) < 0.001f)&&
		(Vector3.Distance(ao.transform.position, pos_ini_ao.transform.position) < 0.001f))	
		{
			move = false;
		}
	}
    }
}

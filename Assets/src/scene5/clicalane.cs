using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clicalane : MonoBehaviour
{
    public int lanenumber;
	public GameObject peixinho, control;
	
// Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	void OnMouseDown(){	
		if(!control.GetComponent<scenecontroller>().freeze){
			peixinho.GetComponent<movimentopeixinho>().selecionalane(lanenumber);
		}
	}
	
}

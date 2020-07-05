using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class perolaController : MonoBehaviour
{
    public GameObject algaverde, perola_pos;
	public bool foi = false;

// Start is called before the first frame update

    public GameObject sceneManager;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
	if(!foi){            
		sceneManager.GetComponent<SceneController>().clicouPerola();
		transform.position = perola_pos.transform.position;
		foi = true;		
	}        
    }
}

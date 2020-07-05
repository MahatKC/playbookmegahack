using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrasta_inho2 : MonoBehaviour
{
    private Vector3 mOffset;
    private float mZCoord;
	public GameObject inho2, control, e, peixe, peixe_new, txt5, button1, cauda_true;
	private bool naoclicou = true, foi = false;
	public float totalblinktime = 0, activetime = 0.5f, inactivetime = 0.5f;
	public AudioSource transforma;

// Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(e.GetComponent<arrasta_e>().e_saiu && naoclicou){
		totalblinktime += Time.deltaTime;
		if(totalblinktime < inactivetime){
			inho2.GetComponent<Renderer>().enabled = false;			
		}
		else if(totalblinktime < (activetime+inactivetime)){
			inho2.GetComponent<Renderer>().enabled = true;
		}
		else{
			totalblinktime = 0;			
		}
	}
	if((Vector3.Distance(transform.position, cauda_true.transform.position) < 0.1f)&&!foi){		
			Destroy(peixe);
			Destroy(e);
			Destroy(inho2);
			transforma.Play();
			txt5.SetActive(true);
			button1.SetActive(true);
			control.GetComponent<scenecontroller3>().click2 = true;
			peixe_new.GetComponent<Renderer>().enabled = true;
			foi = true;
	}
    }

	void OnMouseDown(){
	        mZCoord = Camera.main.WorldToScreenPoint(inho2.transform.position).z;
        	// Store offset = gameobject world pos - mouse world pos
        	mOffset = inho2.transform.position - GetMouseAsWorldPoint();
	}

	private Vector3 GetMouseAsWorldPoint(){
		// Pixel coordinates of mouse (x,y)
		Vector3 mousePoint = Input.mousePosition;

		// z coordinate of game object on screen
		mousePoint.z = mZCoord;

		// Convert it to world points
		return Camera.main.ScreenToWorldPoint(mousePoint);
	}

	void OnMouseDrag(){
		if(control.GetComponent<scenecontroller3>().allow_drag && e.GetComponent<arrasta_e>().e_saiu){	
			transform.position = GetMouseAsWorldPoint() + mOffset;
			naoclicou = false;
			inho2.GetComponent<Renderer>().enabled = true;
		}	
	}

	void OnTriggerEnter(Collider col){
		if(col.transform.tag == "entrou"){		
			foi = true;			
			Destroy(peixe);
			Destroy(e);
			Destroy(inho2);
			transforma.Play();
			txt5.SetActive(true);
			button1.SetActive(true);
			control.GetComponent<scenecontroller3>().click2 = true;
			peixe_new.GetComponent<Renderer>().enabled = true;		
		}			
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrasta_e : MonoBehaviour
{
     private Vector3 mOffset;
    private float mZCoord;
	public GameObject e, control, cauda;
	public bool e_saiu = false, naoclicou = true;
	public float totalblinktime = 0, activetime = 0.1f, inactivetime = 0.1f;

// Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(control.GetComponent<scenecontroller3>().allow_drag && naoclicou){
		totalblinktime += Time.deltaTime;
		if(totalblinktime < activetime){
			e.GetComponent<Renderer>().enabled = true;			
		}
		else if(totalblinktime < (activetime+inactivetime)){
			e.GetComponent<Renderer>().enabled = false;
		}
		else{
			totalblinktime = 0;			
		}		
	}
	if((Vector3.Distance(e.transform.position, cauda.transform.position) > 4f)&&(!e_saiu)){
		e_saiu = true;
	}
    }

	void OnMouseDown(){
	        mZCoord = Camera.main.WorldToScreenPoint(e.transform.position).z;
        	// Store offset = gameobject world pos - mouse world pos
        	mOffset = e.transform.position - GetMouseAsWorldPoint();
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
		if(control.GetComponent<scenecontroller3>().allow_drag){		
			transform.position = GetMouseAsWorldPoint() + mOffset;
			naoclicou = false;
			e.GetComponent<Renderer>().enabled = true;
		}	
	}

	void OnTriggerExit(Collider col){
		if(col.transform.tag == "saiu"){		
			e_saiu = true;
		}			
	}
}

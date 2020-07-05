using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimentopeixinho : MonoBehaviour
{
    public int lane = 1;
	public GameObject peixinho, Lanes;
	public float speed = 1f, tempo = 0f;	
	private float y;
	private bool move = false;
	public bool tiralane = false;

// Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (move == true){		
		transform.position = Vector3.MoveTowards(transform.position, new Vector3(-1.33f, y, -1.0f), speed*Time.deltaTime);
		if(Vector3.Distance(transform.position, new Vector3(-1.33f, y, -1.0f)) < 0.001f){
			move = false;
		}		
	}
	if(tiralane){
		tempo += Time.deltaTime;
		if(tempo > 0.5f){		
			Lanes.SetActive(false);
			tiralane = false;
			tempo = 0f;
		}	
	}
    }

	public void selecionalane(int newlane){
		y = ((float)newlane-1)*(-1.83f)-0.45f;
		lane = newlane;
		move = true;			
	}
}

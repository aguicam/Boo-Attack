using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour {
	bool exit = false;
	[SerializeField] Text text;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(exit&&transform.position.y<=40.0f){
			transform.Translate(2.5f*5.0f*Vector3.up*Time.deltaTime);
		}else if(exit&&transform.position.y>40.0f){
			DestroyShy();
		}
	}

	public void changeStatus(){
		exit=true;
		text.text="Good Luck!";
		text.color=Color.green;
	}


	private void DestroyShy(){
		TimeController player = FindObjectOfType<TimeController>();
		player.restartGame();
		Destroy(gameObject);
	}

}

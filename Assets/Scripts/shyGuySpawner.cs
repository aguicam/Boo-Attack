using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shyGuySpawner : MonoBehaviour {

	float speed=5.0f;
	bool exit = false;
	// Use this for initialization
	[SerializeField] Text text;
	[SerializeField] Text scoreText;
	void Start () {
		transform.Rotate(0.0f,180.0f,0.0f);
		var timeC= FindObjectOfType<TimeController>();
		scoreText.text = "Score: "+ timeC.getScore();

	}
	
	// Update is called once per frame
	void Update () {
		if(!exit&&transform.position.y>2.8f){
			print("Muevo");
			transform.Translate(-speed*Vector3.up*Time.deltaTime);
		}else if(exit&&transform.position.y<=40.0f){
			transform.Translate(2.5f*speed*Vector3.up*Time.deltaTime);
		}else if(exit&&transform.position.y>40.0f){
			DestroyShy();
		}
		
	}
	public void byeShy(){
		exit=true;
		text.text = "Good Luck!";
		text.color= Color.green;
	}
	private void DestroyShy(){
		TimeController player = FindObjectOfType<TimeController>();
		player.restartGame();
		Destroy(gameObject);
	}

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour {

	int currentSpawner = 0 ;
	float currTime = 0.0f;
	int maxDir = 5;
	int minDir = 0;

	int score = 0;

	bool running=false;

	[SerializeField] ObstacleSpawner[] spawners;
	[SerializeField] Transform shyT;
	[SerializeField] shyGuySpawner shyPrefab; //GameObject
    float minSecondsBetweenSpawns = 2f;
    float maxSecondsBetweenSpawns = 3f;
	[SerializeField] ParticleSystem cloud;

	// Use this for initialization
	void Start () {
		StartCoroutine(SpawnObstacles());
	}
	
	// Update is called once per frame
	void Update () {
		currTime += Time.deltaTime;
	}


	IEnumerator SpawnObstacles(){
		while(running){
			
			currentSpawner= Random.Range(minDir,maxDir);
			print(currentSpawner);
			spawners[currentSpawner].SpawnObstacle();
			yield return new WaitForSeconds(Random.Range(minSecondsBetweenSpawns, maxSecondsBetweenSpawns));
			
		}
	
	}


	private void OnTriggerEnter(Collider other)
    {
		running = false;
		currTime = 0.0f;
        StopCoroutine(SpawnObstacles()); // We stop the spawning
		
		GameObject[] boos = GameObject.FindGameObjectsWithTag("Boo");
	// We destroy all current Boos
		foreach (GameObject boo in boos)
        {
            Destroy(boo);
        }
		cloud.Play();
		var newShyGuy = Instantiate(shyPrefab, shyT.position, Quaternion.identity);
    }

	public void restartGame(){
		currTime=0.0f;
		running =true;
		cloud.Stop();
		score = 0;
		new WaitForSeconds(2.0f);
		StartCoroutine(SpawnObstacles());
	}
	public void addScore(){
		score=score+1;
	}
	public int getScore(){
		return score;
	}
}

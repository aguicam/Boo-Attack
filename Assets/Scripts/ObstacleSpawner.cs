using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour {

    [SerializeField] ObstacleController obsPrefab;
    [SerializeField] Transform obsParentTransform;
    [Range(0, 4)] [SerializeField] int direction;
    float rangeRandom = 2.0f;
    Vector3 spawnT;

    public void SpawnObstacle(){
        spawnT = transform.position;
        float angle=0.0f;
            switch(direction){
                case 0:
                    spawnT = spawnT + new Vector3(0.0f,Random.Range(-rangeRandom, rangeRandom), Random.Range(-rangeRandom, rangeRandom));
                    angle=90.0f;
                    break;
                case 1:
                    spawnT = spawnT + new Vector3( Random.Range(-rangeRandom, rangeRandom), Random.Range(-rangeRandom, rangeRandom), 0.0f);
                    angle=180.0f;
                    break;
                case 2:
                    spawnT = spawnT + new Vector3(0.0f, Random.Range(-rangeRandom, rangeRandom), Random.Range(-rangeRandom, rangeRandom));
                    angle=-90.0f;
                    break;
                case 3:
                    spawnT = spawnT + new Vector3(Random.Range(-rangeRandom, rangeRandom), Random.Range(-rangeRandom, rangeRandom), Random.Range(-rangeRandom, rangeRandom));
                    angle=-135.0f;
                    break;
                case 4:
                    spawnT = spawnT + new Vector3(Random.Range(-rangeRandom, rangeRandom), Random.Range(-rangeRandom, rangeRandom), Random.Range(-rangeRandom, rangeRandom));
                    angle=135.0f;
                    break;

            }
            var newObstacle = Instantiate(obsPrefab, spawnT, Quaternion.identity);
            newObstacle.setDirection(direction);
            newObstacle.transform.Rotate(0.0f,angle,0.0f);
            newObstacle.transform.parent = obsParentTransform;
            
    }

}

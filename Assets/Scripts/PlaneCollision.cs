using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneCollision : MonoBehaviour {

    [SerializeField] AudioClip collisionClip;
    private void OnTriggerEnter(Collider other)
    {
        AudioSource.PlayClipAtPoint(collisionClip, transform.position);
    }

}

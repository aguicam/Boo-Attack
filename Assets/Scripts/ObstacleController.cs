using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour {
    float speed = 4.0f;
    private Renderer myRenderer;

    public Material inactiveMaterial;
    public Material gazedAtMaterial;
    [SerializeField] ParticleSystem explosionPS;
    [Range(0,2)] [SerializeField] int direction; // left = 0 // front = 1 // right = 2 // front-right = 3 // front-left = 4

    void Start()
    {
        myRenderer = GetComponent<Renderer>();
        SetGazedAt(false);
    }


    void Update()
    {

            switch (direction)
            {
                case 0:
                    if (transform.position.x <0) {transform.Translate(speed *Vector3.forward* Time.deltaTime); } else { Destroy(gameObject); }
                    break;
                case 1:
                    if (transform.position.z >0) { transform.Translate(speed * Vector3.forward * Time.deltaTime); } else { Destroy(gameObject); }
                    break;
                case 2:
                    if (transform.position.x >0){ transform.Translate(speed * Vector3.forward * Time.deltaTime); } else { Destroy(gameObject); }
                    break;
                case 3:
                    if (transform.position.z >0) {
                        transform.Translate(speed*Vector3.forward * Time.deltaTime);
                     } else { Destroy(gameObject); }
                    break;
                case 4:
                    if (transform.position.z >0) {
                        transform.Translate(speed* Vector3.forward * Time.deltaTime);
                     } else { Destroy(gameObject); }
                    break;    
            }

        
    }


    public void SetGazedAt(bool gazedAt)
    {
        if (inactiveMaterial != null && gazedAtMaterial != null)
        {
            myRenderer.material = gazedAt ? gazedAtMaterial : inactiveMaterial;
            return;
        }
    }

    public void Clicked()
    {
        
        if (transform.position.magnitude < 15)
        {
            var timeCont = FindObjectOfType<TimeController>();
            timeCont.addScore();
            var vfx = Instantiate(explosionPS, transform.position, Quaternion.identity);
            Destroy(gameObject);
            vfx.Play();
            Destroy(vfx.gameObject, vfx.main.duration);
            
        }
        
    }

    public void setDirection(int dir)
    {
        direction = dir;
    }


}

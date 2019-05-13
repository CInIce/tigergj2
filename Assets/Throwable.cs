using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throwable : MonoBehaviour
{
    public bool active;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.transform.tag == "Enemy" && active){
            other.gameObject.GetComponent<LivingComponent>().Damage(1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(active == true && gameObject.GetComponent<Rigidbody2D>().velocity == Vector2.zero){
            active = false;
        }
    }
}

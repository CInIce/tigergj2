using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throwable : MonoBehaviour
{
    public ThrowableObject throwableObject;
    public bool active;
    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer renderer = gameObject.GetComponent<SpriteRenderer>();
        if(renderer){
            renderer.sprite = throwableObject.sprite;
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.transform.tag == "Enemy" && active){
            other.gameObject.GetComponent<LivingComponent>().Damage(1);
        }

        if(DestroyOnImpact() && active && other.transform.tag != "Char"){
            Destroy(gameObject);
        }
    }

    private void OnCollisionStay2D(Collision2D other) {
        if(other.transform.tag == "Enemy" && active){
            other.gameObject.GetComponent<LivingComponent>().Damage(1);
        }

        if(DestroyOnImpact() && active && other.transform.tag != "Char"){
            Destroy(gameObject);
        }
    }

    public bool DestroyOnImpact(){
        if(!throwableObject.isImortal){
            return true;
        }
        return false;
    }

    // Update is called once per frame
    void Update()
    {
        if(active == true && gameObject.GetComponent<Rigidbody2D>().velocity == Vector2.zero){
            active = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharMovement : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D _rigidbody;
    [SerializeField]float _speed;
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D other) {
        
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag=="Portal"){
            print("collided");
            RoomManager.instance.winCondition = true;
        }
    }

    private void OnTriggerStay2D(Collider2D other) {
        if(other.tag=="Portal"){
            print("collided");
            RoomManager.instance.winCondition = true;
        }
    }

    // Update is called once per frame
    void Update()
    {

    

        Vector2 input;
        input.x = Input.GetAxis("Horizontal");
        input.y = Input.GetAxis("Vertical");
        
        // Vector3 moveDirection = gameObject.transform.position - _origPos; 
    //  if (moveDirection != Vector3.zero) 
    //  {
        if(input.x != 0 || input.y != 0){
         float angle = Mathf.Atan2(input.y, input.x) * Mathf.Rad2Deg;
         transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
         }
    //  }

        _rigidbody.velocity = input * _speed * Time.deltaTime;
        
        // if (input.x != 0)
        // {
        //     _rigidbody.velocity = new Vector2(input.x, 0) * _speed * Time.deltaTime;
        // }
        
        // else if (input.y != 0)
        // {
        //     _rigidbody.velocity = new Vector2(0, input.y) * _speed * Time.deltaTime;
        // }
        
        
        

    }
}

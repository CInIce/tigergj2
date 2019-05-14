using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _KOTime;
    [SerializeField] private float _KOVelocityMult;

    private CharMovement _movement;
    private Rigidbody2D _rigidbody;

    private bool _knockedOut = false;

    private void Start()
    {
        _movement = GetComponent<CharMovement>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (_knockedOut)
        {
            StartCoroutine(GetBackUp());
            _movement.enabled = false;
        }
        else
        {
            _movement.enabled = true;
        }
    }

    private IEnumerator GetBackUp ()
    {
        yield return new WaitForSeconds(_KOTime);
        _knockedOut = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Enemy")
        {
            _rigidbody.velocity = -_rigidbody.velocity * _KOVelocityMult;
            _knockedOut = true;
        }
    }
}

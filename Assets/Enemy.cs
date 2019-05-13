using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform _goal;
    [SerializeField] private Vector2 _avoidenceOffset;
    [SerializeField] private float _speed;

    private Vector2 _target;

    private void Start()
    {
        _target = GetTarget(_goal.position);
    }

    private void Update()
    {
        if (Vector2.Distance(transform.position, _target) < 0.1)
        {
            _target = GetTarget(_goal.position);
        }
        else
        {
            MoveTowardsPoint(_target);
        }
    }

    private void MoveTowardsPoint (Vector2 point)
    {
        transform.position = Vector2.MoveTowards(transform.position, point, _speed);
    }

    private Vector2 GetTarget (Vector2 goal)
    {
        RaycastHit2D[] obsticals =  Physics2D.LinecastAll(transform.position, goal);

        if (obsticals.Length >= 2)
        {
            Transform obstical = null;
            Collider2D obstical_coll = null;

            //find out if any are obsitcals, store the first one that is
            foreach (RaycastHit2D hit in obsticals)
            {
                if (hit.transform.tag == "block")
                {
                    obstical = hit.transform;
                    obstical_coll = hit.collider;
                    break;
                }
            }

            //if there werent any that were obsticals, return goal
            if (obstical == null)
            {
                return goal;
            }

            //calculate target
            Vector2 half_obstical = obstical_coll.bounds.size / 2;

            Vector2 half_agent = obstical_coll.bounds.size / 2;

            Vector2 offest = half_obstical + half_agent + _avoidenceOffset;

            Vector2 target =(Vector2) obstical.transform.position + offest;

            return GetTarget(target);

        }else
        {
            return goal;
        }

        return new Vector2();
    }
}

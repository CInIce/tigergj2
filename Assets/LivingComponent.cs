using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivingComponent : MonoBehaviour
{

    [SerializeField] private GameObject _drop = null;

    [SerializeField] private int currentHealth = 3;
    [SerializeField] private int maxHealth = 3;
    // Start is called before the first frame update
    public Animator _animator;



    public void ReplenishHealth(int value){
        currentHealth += value;

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    public virtual void Damage(int value){
        // if(!_animator.GetCurrentAnimatorStateInfo(0).IsName("damage")){
        // _animator.SetTrigger("damage");
        currentHealth = currentHealth - value;

        if(currentHealth < 0){
            if(gameObject.tag == "Enemy"){
                // PlayerPrefs.SetInt("enemyskilled", PlayerPrefs.GetInt("enemyskilled") + 1);
                // GameManager.instance.scoreSystem.kills++;
            }
            
            Die();
        }
        // UpdateUI();
        // }
    }

    public virtual void UpdateUI(){

    }

    public void Die(){

        if (gameObject.tag == "Player")
        {
            
        }

        if (_drop != null)
        {

        }
        
        Destroy(gameObject);
    }
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
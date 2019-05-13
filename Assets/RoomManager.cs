using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static RoomManager instance = null; 
    public bool winCondition = false;

    private void Awake() {
        if (instance == null)
                
                //if not, set instance to this
                instance = this;
            
            //If instance already exists and it's not this:
            else if (instance != this)
                Destroy(gameObject);


                DontDestroyOnLoad(gameObject);   
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(winCondition){
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
            winCondition = false;
        }
    }
}

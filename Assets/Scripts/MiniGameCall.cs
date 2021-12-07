using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameCall : MonoBehaviour
{
    public int miniGameId;
    public bool tutorial;
    
    public bool jogar = false;
    public bool jogando = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (jogar && !jogando) 
        {
            if (Input.GetKeyDown(KeyCode.E)) 
            {
                jogando = true;
                MiniGameController.instance.miniGameId = miniGameId;
                MiniGameController.instance.createMiniGame();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            jogar = true;
        }
        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            jogar = false;
            if (tutorial) 
            {
                jogando = false;
            }
        }
    }

}

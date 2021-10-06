using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameController : MonoBehaviour
{
    public static MiniGameController instance;
    public GameObject[] miniGames;
    public GameObject game;
    public GameObject buttomFinal;
    // Start is called before the first frame update

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        game = Instantiate(miniGames[0], new Vector3(0, 0, 0), Quaternion.identity);
    }



    // Update is called once per frame
    void Update()
    {
        
    }

    public void destroyMiniGame() 
    {
        Destroy(game);
        NPC_Movement.instance.canMove = true;
        Player_Movement.instance.canMove = true;
    }
}

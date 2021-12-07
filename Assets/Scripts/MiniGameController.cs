using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniGameController : MonoBehaviour
{
    public static MiniGameController instance;
    public GameObject[] miniGames;
    public Button buttomFinal;
    public int miniGameId;

    private GameObject game;
    // Start is called before the first frame update

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        //buttomFinal.onClick.AddListener(delegate() { LevelControllerSP.instance.RestartScene(); });
    }



    // Update is called once per frame
    void Update()
    {
        
    }
    public void createMiniGame() 
    {
        NPC_Movement.instance.canMove = false;
        Player_Movement.instance.canMove = false;
        game = Instantiate(miniGames[miniGameId], new Vector3(0, 0, 0), Quaternion.identity);
    }

    public void destroyMiniGame(bool tutorial, bool vitoria) 
    {
        if (tutorial)
        {
            if (vitoria)
            {
                Destroy(game);
                NPC_Movement.instance.canMove = true;
                Player_Movement.instance.canMove = true;
            }
            else
            {
                Destroy(game);
                createMiniGame();
            }
        }
        else 
        {
            Destroy(game);
            NPC_Movement.instance.canMove = true;
            Player_Movement.instance.canMove = true;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    public int playerIndex;
    public Animator anim;

    private int keyIndex = 8;
    public bool canPlay;

    private float timer;
    private float nextkeyTime;

    private int numSeq = 1;
    private int sequencia = 2;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    IEnumerator Start()
    {
        while (LevelController.instance.canPlay[playerIndex] == false)
        {
            yield return null;
        }

        canPlay = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        timer += Time.deltaTime;

        if (playerIndex == 1 && LevelController.instance.canPlay[playerIndex] == true) 
        {
            if (Time.time > nextkeyTime) 
            {
                nextkeyTime = Time.time + Random.Range(0.25f , 0.5f);
                keyPress();
            }
            return; 
        }
        if (numSeq == 1 && LevelController.instance.canPlay[playerIndex] == true)
        {
            if (Input.GetKeyDown(LevelController.instance.gameKeys[keyIndex].key))
            {
                keyPress();
            }
            else if (Input.anyKeyDown)
            {
                timer += 0.1f;
            }
        } 
        else if (numSeq == 2 && LevelController.instance.canPlay[playerIndex] == true) 
        {
            if (Input.GetKeyDown(LevelController.instance.gameKeys2[keyIndex].key))
            {
                keyPress();
            }
            else if (Input.anyKeyDown)
            {
                timer += 0.1f;
            }
        }
        else if (numSeq == 3 && LevelController.instance.canPlay[playerIndex] == true)
        {
            if (Input.GetKeyDown(LevelController.instance.gameKeys3[keyIndex].key))
            {
                keyPress();
            }
            else if (Input.anyKeyDown)
            {
                timer += 0.1f;
            }
        }
    }

    void keyPress() 
    {
        LevelController.instance.NextKey(playerIndex, keyIndex);
        keyIndex--;

        if (keyIndex < 0 && sequencia == 0)
        {
            LevelController.instance.canPlay[playerIndex] = false;
            LevelController.instance.UpdatePlayerTime(timer, playerIndex);
        }
        else if (keyIndex < 0) 
        {
            LevelController.instance.canPlay[playerIndex] = false;
            numSeq++;
            sequencia--;
            keyIndex = 8;
            LevelController.instance.RestartSequencia(numSeq, playerIndex);
        }
    }

    public void SetAnimation(string triggerAnimation) 
    {
        anim.SetTrigger(triggerAnimation);
    }

    
}

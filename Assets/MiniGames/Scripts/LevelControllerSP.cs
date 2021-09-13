using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


[Serializable]
public class KeysSP
{
    public Sprite keySprite;
    public KeyCode key;
}

public class LevelControllerSP : MonoBehaviour
{
    public static LevelControllerSP instance;
    public KeysSP[] keysSP;

    public List<KeysSP> gameKeysSP;
    public List<KeysSP> gameKeysSP2;
    public List<KeysSP> gameKeysSP3;
    public Image[] player1Images;
    
    public Text messageText;
    public Text playerTimeText;
    public float playerTime;

    public PlayerControllerSP playerSP;

    public bool canPlay = false;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartingKeys(1));
    }

    // Update is called once per frame

    IEnumerator StartingKeys(int id)
    {
        canPlay = false;
        if (id == 1) 
        {
            for (int i = 0; i < player1Images.Length; i++)
            {

                gameKeysSP.Add(keysSP[UnityEngine.Random.Range(0, keysSP.Length)]);
                gameKeysSP2.Add(keysSP[UnityEngine.Random.Range(0, keysSP.Length)]);
                gameKeysSP3.Add(keysSP[UnityEngine.Random.Range(0, keysSP.Length)]);
            }
        }
        yield return new WaitForSeconds(0.25f);

        for (int i = 0; i < player1Images.Length; i++)
        {

            if (id == 1)
            {
                player1Images[i].sprite = gameKeysSP[i].keySprite;
                player1Images[i].preserveAspect = true;
                player1Images[i].enabled = true;

                yield return new WaitForSeconds(0.25f);
            }
            else if (id == 2)
            {
                player1Images[i].sprite = gameKeysSP2[i].keySprite;
                player1Images[i].preserveAspect = true;
                player1Images[i].enabled = true;

                yield return new WaitForSeconds(0.25f);
            }
            else if (id == 3) 
            {
                player1Images[i].sprite = gameKeysSP3[i].keySprite;
                player1Images[i].preserveAspect = true;
                player1Images[i].enabled = true;

                yield return new WaitForSeconds(0.25f);
            }
            
        }
        
        
        canPlay = true;
        messageText.text = "Go";
        StartCoroutine(Fading(messageText));
    }

    IEnumerator Fading(Text text)
    {
        Color newColor = text.color;
        while (newColor.a > 0)
        {
            newColor.a -= Time.deltaTime;
            text.color = newColor;
            yield return null;
        }
    }

    public void NextKey(int playerIndex, int keyIndex)
    {
        
        if (playerIndex == 0)
        {
            player1Images[keyIndex].enabled = false;
        }
        
    }
    public void RestartSequencia(int id) 
    {
        StartCoroutine(StartingKeys(id));
    }

    public void UpdatePlayerTime(float time)
    {
        playerTime = time;

        if (playerTime > 0)
        {
            playerTimeText.text = playerTime.ToString("0.00") + "s";
        }
    }
    public void RestartScene()
    {
        SceneManager.LoadScene(0);
    }
}

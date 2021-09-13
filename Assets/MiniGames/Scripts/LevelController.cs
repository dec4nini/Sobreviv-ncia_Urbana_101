using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[Serializable]
public class Keys 
{
    public Sprite keySprite;
    public KeyCode key;
}


public class LevelController : MonoBehaviour
{

    public static LevelController instance;
    public Keys[] keys;

    public List<Keys> gameKeys;
    public List<Keys> gameKeys2;
    public List<Keys> gameKeys3;

    public Image[] player1Images;
    public Image[] player2Images;

    public Text messageText;
    public Text[] playersTimeText;
    public float[] playersTime;

    public PlayerController[] players;

    public RectTransform[] cursor;

    public bool[] canPlay;

    public GameObject restartButton;
    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
        StartCoroutine(StartingKeys(1, 0));
        StartCoroutine(StartingKeys(1, 1));
        
    }

    // Update is called once per frame

    IEnumerator StartingKeys(int seq, int player) 
    {
        canPlay[player] = false;
        //PlayerController.instance.playBool(false, player);
        if (seq == 1) 
        {
            for (int i = 0; i < player1Images.Length; i++)
            {
                gameKeys.Add(keys[UnityEngine.Random.Range(0, keys.Length)]);
                gameKeys2.Add(keys[UnityEngine.Random.Range(0, keys.Length)]);
                gameKeys3.Add(keys[UnityEngine.Random.Range(0, keys.Length)]);
            }
        }
        yield return new WaitForSeconds(0.25f);
        for (int i = 0; i < player1Images.Length; i++)
        {
            if (player == 0)
            {
                if (seq == 1)
                {

                    cursor[0].anchoredPosition = new Vector2(cursor[0].anchoredPosition.x, cursor[0].anchoredPosition.y + 45);
                    
                    player1Images[i].sprite = gameKeys[i].keySprite;
                    player1Images[i].preserveAspect = true;
                    player1Images[i].enabled = true;

                    yield return new WaitForSeconds(0.25f);
                }
                else if (seq == 2)
                {
                    cursor[0].anchoredPosition = new Vector2(cursor[0].anchoredPosition.x, cursor[0].anchoredPosition.y + 45);

                    player1Images[i].sprite = gameKeys2[i].keySprite;
                    player1Images[i].preserveAspect = true;
                    player1Images[i].enabled = true;

                    yield return new WaitForSeconds(0.25f);
                }
                else if (seq == 3)
                {
                    cursor[0].anchoredPosition = new Vector2(cursor[0].anchoredPosition.x, cursor[0].anchoredPosition.y + 45);

                    player1Images[i].sprite = gameKeys3[i].keySprite;
                    player1Images[i].preserveAspect = true;
                    player1Images[i].enabled = true;

                    yield return new WaitForSeconds(0.25f);
                }
            }
            else 
            {
                if (seq == 1)
                {
                    cursor[1].anchoredPosition = new Vector2(cursor[1].anchoredPosition.x, cursor[1].anchoredPosition.y + 45);

                    player2Images[i].sprite = gameKeys[i].keySprite;
                    player2Images[i].preserveAspect = true;
                    player2Images[i].enabled = true;

                    yield return new WaitForSeconds(0.25f);
                }
                else if (seq == 2)
                {
                    cursor[1].anchoredPosition = new Vector2(cursor[1].anchoredPosition.x, cursor[1].anchoredPosition.y + 45);

                    player2Images[i].sprite = gameKeys2[i].keySprite;
                    player2Images[i].preserveAspect = true;
                    player2Images[i].enabled = true;

                    yield return new WaitForSeconds(0.25f);
                }
                else if (seq == 3)
                {
                    cursor[1].anchoredPosition = new Vector2(cursor[1].anchoredPosition.x, cursor[1].anchoredPosition.y + 45);

                    player2Images[i].sprite = gameKeys3[i].keySprite;
                    player2Images[i].preserveAspect = true;
                    player2Images[i].enabled = true;

                    yield return new WaitForSeconds(0.25f);
                }
            }

        }

        
        messageText.text = "Go";
        StartCoroutine(Fading(messageText));
        canPlay[player] = true;
        //PlayerController.instance.playBool(true, player);
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
        cursor[playerIndex].anchoredPosition = new Vector2(cursor[playerIndex].anchoredPosition.x, cursor[playerIndex].anchoredPosition.y - 45);
        if (playerIndex == 0)
        {
            player1Images[keyIndex].enabled = false;
        }
        else 
        {
            player2Images[keyIndex].enabled = false;
        }
    }

    public void RestartSequencia(int seq, int player)
    {
        StartCoroutine(StartingKeys(seq, player));
    }

    public void UpdatePlayerTime(float time, int player) 
    {
        playersTime[player] = time;

        if (playersTime[0] > 0 && playersTime[1] > 0) 
        {
            
            string[] triggersAnims = new string[2];
            if (playersTime[0] > playersTime[1])
            {
                triggersAnims[0] = "Dead";
                triggersAnims[1] = "Shoot";
            }
            else 
            {
                triggersAnims[1] = "Dead";
                triggersAnims[0] = "Shoot";
            }

            for (int i = 0; i < playersTime.Length; i++)
            {
                players[i].SetAnimation(triggersAnims[i]);
                playersTimeText[i].text = playersTime[i].ToString("0.00") + "s";
            }

            restartButton.SetActive(true);
        }
    }
    public void RestartScene() 
    {
        SceneManager.LoadScene(0);
    }
}

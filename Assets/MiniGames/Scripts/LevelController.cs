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

    public Image[] player1Images;
    public Image[] player2Images;

    public Text messageText;
    public Text[] playersTimeText;
    public float[] playersTime;

    public PlayerController[] players;

    public RectTransform[] cursor;

    public bool canPlay = false;

    public GameObject restartButton;
    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartingKeys());
    }

    // Update is called once per frame

    IEnumerator StartingKeys() 
    {
        for (int i = 0; i < player1Images.Length; i++)
        {
            for (int y = 0; y < cursor.Length; y++)
            {
                cursor[y].anchoredPosition = new Vector2(cursor[y].anchoredPosition.x, cursor[y].anchoredPosition.y + 45);
            }

            gameKeys.Add(keys[UnityEngine.Random.Range(0, keys.Length)]);
            player1Images[i].sprite = gameKeys[i].keySprite;
            player1Images[i].preserveAspect = true;
            player1Images[i].enabled = true;

            player2Images[i].sprite = gameKeys[i].keySprite;
            player2Images[i].preserveAspect = true;
            player2Images[i].enabled = true;
            yield return new WaitForSeconds(0.25f);
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

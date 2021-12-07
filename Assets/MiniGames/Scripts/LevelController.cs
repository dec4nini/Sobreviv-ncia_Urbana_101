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
    public Sprite keySpriteFoco;
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

    public RectTransform messageErrorPosition;
    public Text messageError;
    public GameObject messageErrorGB;
    public Text messageFinalGame;
    public GameObject messageFinalGameGB;

    public Text messageText;
    public Text[] playersTimeText;
    public float[] playersTime;

    public PlayerController[] players;

    public bool[] canPlay;
    public bool finalGame = false;
    public bool error = false;
    public bool vitoria = false;

    public Color newColor;
    public Color newColor2;

    public GameObject restartButton;
    public Text restartButtonText;
    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        NPC_Movement.instance.canMove = false;
        Player_Movement.instance.canMove = false;
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
                    if (i == 0)
                    {
                        messageErrorPosition.anchoredPosition = new Vector2(messageErrorPosition.anchoredPosition.x, messageErrorPosition.anchoredPosition.y + 45);

                        player1Images[i].sprite = gameKeys[i].keySpriteFoco;
                        player1Images[i].preserveAspect = true;
                        player1Images[i].enabled = true;
                    }
                    else 
                    {
                        messageErrorPosition.anchoredPosition = new Vector2(messageErrorPosition.anchoredPosition.x, messageErrorPosition.anchoredPosition.y + 45);
                        player1Images[i].sprite = gameKeys[i].keySpriteFoco;
                        player1Images[i - 1].sprite = gameKeys[i - 1].keySprite;
                        player1Images[i].preserveAspect = true;
                        player1Images[i].enabled = true;
                    }
                    
                    yield return new WaitForSeconds(0.25f);
                }
                else if (seq == 2)
                {
                    if (i == 0)
                    {
                        messageErrorPosition.anchoredPosition = new Vector2(messageErrorPosition.anchoredPosition.x, messageErrorPosition.anchoredPosition.y + 45);

                        player1Images[i].sprite = gameKeys2[i].keySpriteFoco;
                        player1Images[i].preserveAspect = true;
                        player1Images[i].enabled = true;
                    }
                    else
                    {
                        messageErrorPosition.anchoredPosition = new Vector2(messageErrorPosition.anchoredPosition.x, messageErrorPosition.anchoredPosition.y + 45);
                        player1Images[i].sprite = gameKeys2[i].keySpriteFoco;
                        player1Images[i - 1].sprite = gameKeys2[i - 1].keySprite;
                        player1Images[i].preserveAspect = true;
                        player1Images[i].enabled = true;
                    }

                    yield return new WaitForSeconds(0.25f);
                }
                else if (seq == 3)
                {
                    if (i == 0)
                    {
                        messageErrorPosition.anchoredPosition = new Vector2(messageErrorPosition.anchoredPosition.x, messageErrorPosition.anchoredPosition.y + 45);

                        player1Images[i].sprite = gameKeys3[i].keySpriteFoco;
                        player1Images[i].preserveAspect = true;
                        player1Images[i].enabled = true;
                    }
                    else
                    {
                        messageErrorPosition.anchoredPosition = new Vector2(messageErrorPosition.anchoredPosition.x, messageErrorPosition.anchoredPosition.y + 45);
                        player1Images[i].sprite = gameKeys3[i].keySpriteFoco;
                        player1Images[i - 1].sprite = gameKeys3[i - 1].keySprite;
                        player1Images[i].preserveAspect = true;
                        player1Images[i].enabled = true;
                    }

                    yield return new WaitForSeconds(0.25f);
                }
            }
            else 
            {
                if (seq == 1)
                {
                    if (i == 0)
                    {
                        player2Images[i].sprite = gameKeys[i].keySpriteFoco;
                        player2Images[i].preserveAspect = true;
                        player2Images[i].enabled = true;
                    }
                    else
                    {
                        player2Images[i].sprite = gameKeys[i].keySpriteFoco;
                        player2Images[i - 1].sprite = gameKeys[i - 1].keySprite;
                        player2Images[i].preserveAspect = true;
                        player2Images[i].enabled = true;
                    }

                    yield return new WaitForSeconds(0.25f);
                }
                else if (seq == 2)
                {
                    if (i == 0)
                    {
                        player2Images[i].sprite = gameKeys2[i].keySpriteFoco;
                        player2Images[i].preserveAspect = true;
                        player2Images[i].enabled = true;
                    }
                    else
                    {
                        player2Images[i].sprite = gameKeys2[i].keySpriteFoco;
                        player2Images[i - 1].sprite = gameKeys2[i - 1].keySprite;
                        player2Images[i].preserveAspect = true;
                        player2Images[i].enabled = true;
                    }

                    yield return new WaitForSeconds(0.25f);
                }
                else if (seq == 3)
                {
                    if (i == 0)
                    {
                        player2Images[i].sprite = gameKeys3[i].keySpriteFoco;
                        player2Images[i].preserveAspect = true;
                        player2Images[i].enabled = true;
                    }
                    else
                    {
                        player2Images[i].sprite = gameKeys3[i].keySpriteFoco;
                        player2Images[i - 1].sprite = gameKeys3[i - 1].keySprite;
                        player2Images[i].preserveAspect = true;
                        player2Images[i].enabled = true;
                    }

                    yield return new WaitForSeconds(0.25f);
                }
            }

        }

        
        messageText.text = "Go";
        StartCoroutine(Fading(messageText));
        canPlay[player] = true;
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

    public void NextKey(int playerIndex, int keyIndex, int sequencia) 
    {
        int keyIndexFoco;
        if (keyIndex == 0)
        {
            keyIndexFoco = keyIndex;
        }
        else
        {
            keyIndexFoco = keyIndex - 1;
        }
        if (playerIndex == 0)
        {
            messageErrorPosition.anchoredPosition = new Vector2(messageErrorPosition.anchoredPosition.x, messageErrorPosition.anchoredPosition.y - 45);
            player1Images[keyIndex].enabled = false;
            if (sequencia == 1)
            {
                player1Images[keyIndexFoco].sprite = gameKeys[keyIndexFoco].keySpriteFoco;
            }
            else if (sequencia == 2)
            {
                player1Images[keyIndexFoco].sprite = gameKeys2[keyIndexFoco].keySpriteFoco;
            }
            else if (sequencia == 3)
            {
                player1Images[keyIndexFoco].sprite = gameKeys3[keyIndexFoco].keySpriteFoco;
            }
        }
        else 
        {
            player2Images[keyIndex].enabled = false;
            if (sequencia == 1)
            {
                player2Images[keyIndexFoco].sprite = gameKeys[keyIndexFoco].keySpriteFoco;
            }
            else if (sequencia == 2)
            {
                player2Images[keyIndexFoco].sprite = gameKeys2[keyIndexFoco].keySpriteFoco;
            }
            else if (sequencia == 3)
            {
                player2Images[keyIndexFoco].sprite = gameKeys3[keyIndexFoco].keySpriteFoco;
            }
        }
    }

    public void Error()
    {
        newColor.a -= Time.deltaTime;
        messageError.color = newColor;
        MensagemError();
    }

    public void MensagemError()
    {

        if (newColor.a > 0)
        {
            messageErrorGB.SetActive(true);
            canPlay[0] = false;
            error = true;
            Invoke("Error", 0.02f);
        }
        else
        {
            messageErrorGB.SetActive(false);
            messageError.color = newColor2;
            canPlay[0] = true;
            error = false;
            return;
        }

    }

    public void ChamarMsgError()
    {
        newColor = newColor2;
        MensagemError();
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
                messageFinalGameGB.SetActive(true);
                messageFinalGame.text = "Não foi dessa vez";
                vitoria = true;
            }
            else 
            {
                triggersAnims[1] = "Dead";
                triggersAnims[0] = "Shoot";
                messageFinalGameGB.SetActive(true);
                messageFinalGame.text = "Parabens, Tarefa Concluida";
                vitoria = false;
            }

            for (int i = 0; i < playersTime.Length; i++)
            {
                players[i].SetAnimation(triggersAnims[i]);
                playersTimeText[i].text = playersTime[i].ToString("0.00") + "s";
            }
            restartButtonText.text = "Fechar";
            restartButton.SetActive(true);
        }
    }
    public void RestartScene() 
    {
        MiniGameController.instance.destroyMiniGame(false, vitoria);
    }
}

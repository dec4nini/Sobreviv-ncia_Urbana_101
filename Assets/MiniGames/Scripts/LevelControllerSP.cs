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
    public Sprite keySpriteFoco;
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
    public Text messageFinalGame;
    public GameObject messageFinalGameGB;

    public RectTransform messageErrorPosition;
    public Text messageError;
    public GameObject messageErrorGB;

    public Text playerTimeText;
    public Text limiteTimeText;
    public float playerTime;
    private float timer = 0;
    public float limiteTime;

    public PlayerControllerSP playerSP;

    public bool canPlay = false;
    public bool error = false;
    public bool finalGame = false;

    public Color newColor;
    public Color newColor2;

    private IEnumerator coroutineRef;

    public int positionX;
    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        newColor = messageError.color;
        newColor2 = messageError.color;
        StartCoroutine(StartingKeys(1));
        messageFinalGameGB.SetActive(false);
        limiteTimeText.text = "Tempo Limite: " + limiteTime.ToString();
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
                if (i == 0)
                {
                    messageErrorPosition.anchoredPosition = new Vector2(messageErrorPosition.anchoredPosition.x - positionX, messageErrorPosition.anchoredPosition.y);
                    player1Images[i].sprite = gameKeysSP[i].keySpriteFoco;
                    player1Images[i].preserveAspect = true;
                    player1Images[i].enabled = true;
                }
                else
                {
                    messageErrorPosition.anchoredPosition = new Vector2(messageErrorPosition.anchoredPosition.x - positionX, messageErrorPosition.anchoredPosition.y);
                    player1Images[i].sprite = gameKeysSP[i].keySpriteFoco;
                    player1Images[i - 1].sprite = gameKeysSP[i - 1].keySprite;
                    player1Images[i].preserveAspect = true;
                    player1Images[i].enabled = true;
                }

                yield return new WaitForSeconds(0.25f);
            }
            else if (id == 2)
            {
                if (i == 0)
                {
                    messageErrorPosition.anchoredPosition = new Vector2(messageErrorPosition.anchoredPosition.x - positionX, messageErrorPosition.anchoredPosition.y);
                    player1Images[i].sprite = gameKeysSP2[i].keySpriteFoco;
                    player1Images[i].preserveAspect = true;
                    player1Images[i].enabled = true;
                }
                else
                {
                    messageErrorPosition.anchoredPosition = new Vector2(messageErrorPosition.anchoredPosition.x - positionX, messageErrorPosition.anchoredPosition.y);
                    player1Images[i].sprite = gameKeysSP2[i].keySpriteFoco;
                    player1Images[i - 1].sprite = gameKeysSP2[i - 1].keySprite;
                    player1Images[i].preserveAspect = true;
                    player1Images[i].enabled = true;
                }
                yield return new WaitForSeconds(0.25f);
            }
            else if (id == 3)
            {
                if (i == 0)
                {
                    messageErrorPosition.anchoredPosition = new Vector2(messageErrorPosition.anchoredPosition.x - positionX, messageErrorPosition.anchoredPosition.y);
                    player1Images[i].sprite = gameKeysSP3[i].keySpriteFoco;
                    player1Images[i].preserveAspect = true;
                    player1Images[i].enabled = true;
                }
                else
                {
                    messageErrorPosition.anchoredPosition = new Vector2(messageErrorPosition.anchoredPosition.x - positionX, messageErrorPosition.anchoredPosition.y);
                    player1Images[i].sprite = gameKeysSP3[i].keySpriteFoco;
                    player1Images[i - 1].sprite = gameKeysSP3[i - 1].keySprite;
                    player1Images[i].preserveAspect = true;
                    player1Images[i].enabled = true;
                }

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

    
    public void Error() 
    {
        newColor.a -= Time.deltaTime;
        messageError.color = newColor;
        MensagemError();           
    }

    public void NextKey(int playerIndex, int keyIndex, int sequencia)
    {
        messageErrorPosition.anchoredPosition = new Vector2(messageErrorPosition.anchoredPosition.x + positionX, messageErrorPosition.anchoredPosition.y);
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
            player1Images[keyIndex].enabled = false;
            if (sequencia == 1)
            {
                player1Images[keyIndexFoco].sprite = gameKeysSP[keyIndexFoco].keySpriteFoco;
            }
            else if (sequencia == 2) 
            {
                player1Images[keyIndexFoco].sprite = gameKeysSP2[keyIndexFoco].keySpriteFoco;
            }
            else if (sequencia == 3)
            {
                player1Images[keyIndexFoco].sprite = gameKeysSP3[keyIndexFoco].keySpriteFoco;
            }
        }
        
    }
    public void MensagemError() 
    {
        
        if (newColor.a > 0)
        {
            messageErrorGB.SetActive(true);
            canPlay = false;
            error = true;
            Invoke("Error", 0.02f);
        }
        else 
        {
            messageErrorGB.SetActive(false);
            messageError.color = newColor2;
            canPlay = true;
            error = false;
            return;
        }

    }

    public void ChamarMsgError() 
    {
        newColor = newColor2;
        MensagemError();
    }

    public void RestartSequencia(int id) 
    {
        StartCoroutine(StartingKeys(id));
    }

    public void UpdatePlayerTime(float time)
    {
        playerTime = time;

        playerTimeText.text = playerTime.ToString("0.00") + "s";
        
        if (playerTime < limiteTime)
        {
            if (finalGame)
            {
                messageFinalGameGB.SetActive(true);
                messageFinalGame.text = "Parabens, Tarefa Concluida com sucesso";
            }
            else 
            {
                playerTimeText.color = Color.green;
            }
                
        }
        else
        {
            if (finalGame)
            {
                messageFinalGameGB.SetActive(true);
                messageFinalGame.text = "Não foi dessa vez, tente de novo";
            }
            else 
            {
                playerTimeText.color = Color.red;
            }
        }
        
        
        
    }
    public void RestartScene()
    {
        SceneManager.LoadScene(0);
    }
}

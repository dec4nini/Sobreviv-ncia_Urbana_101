using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DificuldadeController : MonoBehaviour
{
    public GameObject[] levelsController;
    public GameObject[] canvasGame;
    public GameObject[] Players;

    public int dificuldade;
    // Start is called before the first frame update
    void Start()
    {
        levelsController[dificuldade].SetActive(true);
        canvasGame[dificuldade].SetActive(true);
        Players[dificuldade].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

    }
}

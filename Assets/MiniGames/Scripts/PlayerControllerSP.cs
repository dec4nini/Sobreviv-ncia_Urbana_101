using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerSP : MonoBehaviour
{
    public Animator anim;
    public int id = 1;
    public int keyIndex;
    public int keyIndexMax;
    private bool canPlay = false;
    public int sequenciaNumero;
    private float timer;
    private float nextkeyTime;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        while (LevelControllerSP.instance.canPlay == false)
        {
            yield return null;
        }

        canPlay = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (canPlay == false)
        {
            return;
        }

        timer += Time.deltaTime;

        if (id == 1)
        {
            if (Input.GetKeyDown(LevelControllerSP.instance.gameKeysSP[keyIndex].key))
            {
                keyPress();
            }
            else if (Input.anyKeyDown)
            {
                timer += 0.1f;
            }
        }
        else if (id == 2)
        {
            if (Input.GetKeyDown(LevelControllerSP.instance.gameKeysSP2[keyIndex].key))
            {
                keyPress();
            }
            else if (Input.anyKeyDown)
            {
                timer += 0.1f;
            }
        } else if(id == 3)
        {
            if (Input.GetKeyDown(LevelControllerSP.instance.gameKeysSP3[keyIndex].key))
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
        LevelControllerSP.instance.NextKey(0, keyIndex);
        keyIndex--;

        if (keyIndex < 0 && sequenciaNumero == 0)
        {
            canPlay = false;
            LevelControllerSP.instance.UpdatePlayerTime(timer);
        }
        else if (keyIndex < 0)
        {
            id++;
            sequenciaNumero--;
            keyIndex = keyIndexMax;
            
            LevelControllerSP.instance.RestartSequencia(id);
        }
    }

    public void SetAnimation(string triggerAnimation)
    {
        anim.SetTrigger(triggerAnimation);

    }

}

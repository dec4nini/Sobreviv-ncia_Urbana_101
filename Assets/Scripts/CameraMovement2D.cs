using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement2D : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public float timeoffset;
    public Vector2 positOffset;
    private Vector3 velicity;
    public float leftlimit;
    public float rigthlimit;
    public float bottomlimit;
    public float toplimit;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //posição inicial da câmera
        Vector3 startPos = transform.position;

        //Posição atual do jogador
        Vector3 endPos = player.transform.position;
        endPos.x += positOffset.x;
        endPos.y += positOffset.y;
        endPos.z = -10;

        //transform.position = Vector3.Lerp(startPos, endPos, timeoffset * Time.deltaTime);

        //smooth damp:
        transform.position = Vector3.SmoothDamp(startPos, endPos, ref velicity, timeoffset);

        transform.position = new Vector3
        (
            Mathf.Clamp(transform.position.x, leftlimit, rigthlimit),
            Mathf.Clamp(transform.position.y, bottomlimit, toplimit),
            transform.position.z
        );

    }

    public void OnDrawGizmos()
    {
        //"desenha" linhas ao redor da câmera
        Gizmos.color = Color.red;
        Gizmos.DrawLine(new Vector2(leftlimit, toplimit), new Vector2(rigthlimit, toplimit));
        Gizmos.DrawLine(new Vector2(rigthlimit, toplimit), new Vector2(rigthlimit, bottomlimit));
        Gizmos.DrawLine(new Vector2(rigthlimit, bottomlimit), new Vector2(leftlimit, bottomlimit));
        Gizmos.DrawLine(new Vector2(leftlimit, bottomlimit), new Vector2(leftlimit, toplimit));
    }





}

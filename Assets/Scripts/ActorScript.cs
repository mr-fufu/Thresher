using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorScript : MonoBehaviour
{
    public Sprite facingNE;
    public Sprite facingSE;
    public Sprite facingSW;
    public Sprite facingNW;

    [System.NonSerialized]
    public bool facingRight;
    [System.NonSerialized]
    public bool facingUp;

    private Sprite setSprite;

    public int stat_Health;
    public int stat_Attack;
    public int stat_Speed;
    public int population;

    void Start()
    {

    }

    void Update()
    {
        if (facingRight)
        {
            if (facingUp)
            {
                setSprite = facingNE;
            }
            else
            {
                setSprite = facingSE;
            }
        }
        else
        {
            if (facingUp)
            {
                setSprite = facingNW;
            }
            else
            {
                setSprite = facingSW;
            }
        }

        GetComponent<SpriteRenderer>().sprite = setSprite;
    }
}

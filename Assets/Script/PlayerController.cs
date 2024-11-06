using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public SpriteRenderer playerSpriteRenderer;

    public void ChangePlayerMood(Sprite moodSprite)
    {
        playerSpriteRenderer.sprite = moodSprite;
    }
}



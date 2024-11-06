using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public Sprite moodSprite;
    public PlayerController playerController;

    // Dipanggil ketika tombol ditekan
    public void OnClick()
    {
        playerController.ChangePlayerMood(moodSprite);
    }
}




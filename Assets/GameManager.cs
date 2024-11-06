using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private SpriteRenderer spriteRendererPlayer;
    [SerializeField] private Sprite[] ekspresiPlayer;
    [SerializeField] private GameObject penonton;
    private SpriteRenderer spriteRendererPenonton;
    [SerializeField] private Sprite[] ekspresiPenonton;
    [SerializeField] private GameObject show;
    [SerializeField] private GameObject showBG;
    private SpriteRenderer spriteRendererShow;
    private SpriteRenderer spriteRendererShowBG;
    [SerializeField] private Sprite[] ekspresiShow1;
    [SerializeField] private Sprite[] ekspresiShow2;
    [SerializeField] private Sprite[] ekspresiShow3;
    [SerializeField] private Sprite[] ekspresiShow4;
    private Sprite disturb;
    private int penontonChance;
    private int showChance;

    [SerializeField] private int win = 0;
    private bool answered = false;
    private bool pressAble = true;

    void Awake()
    {
        Invoke("Penonton", 1f);
        spriteRendererPlayer = player.GetComponent<SpriteRenderer>();
        spriteRendererPenonton = penonton.GetComponent<SpriteRenderer>();
        spriteRendererShow = show.GetComponent<SpriteRenderer>();
        spriteRendererShowBG = showBG.GetComponent<SpriteRenderer>();
        Debug.Log(showChance);

        StartCoroutine("StoryLine");
        DontDestroyOnLoad(this.gameObject);
    } 

    void Start()
    {
        
    }

    void Update()
    {
       
    }

    private void Show()
    {
        showChance = Random.Range(1, 5);
        switch (showChance)
        {
            case 1:
                spriteRendererShowBG.sprite = ekspresiShow1[0];
                spriteRendererShow.sprite = ekspresiShow1[1];
                disturb = ekspresiShow1[2];
                break;
            case 2:
                spriteRendererShowBG.sprite = ekspresiShow2[0];
                spriteRendererShow.sprite = ekspresiShow2[1];
                disturb = ekspresiShow2[2];
                break;
            case 3:
                spriteRendererShowBG.sprite = ekspresiShow3[0];
                spriteRendererShow.sprite = ekspresiShow3[1];
                disturb = ekspresiShow3[2];
                break;
            case 4:
                spriteRendererShowBG.sprite = ekspresiShow4[0];
                spriteRendererShow.sprite = ekspresiShow4[1];
                disturb = ekspresiShow4[2];
                break;
        }
    }

    public void Datar()
    {
        if (pressAble)
        {
            answered = true;
            spriteRendererPlayer.sprite = ekspresiPlayer[0];
            if (penontonChance != 1)
            {
                spriteRendererPenonton.sprite = ekspresiPenonton[4];
                spriteRendererShow.sprite = disturb;
            }
            else
            {
                win++;
            }
        }
    }

    public void Senang()
    {
        if (pressAble)
        {
            answered = true;
            spriteRendererPlayer.sprite = ekspresiPlayer[1];
            if (penontonChance != 2)
            {
                spriteRendererPenonton.sprite = ekspresiPenonton[4];
                spriteRendererShow.sprite = disturb;
            }
            else
            {
                win++;
            }
        }
    }

    public void Sedih()
    {
        if (pressAble)
        {
            answered = true;
            spriteRendererPlayer.sprite = ekspresiPlayer[2];
            if (penontonChance != 3)
            {
                spriteRendererPenonton.sprite = ekspresiPenonton[4];
                spriteRendererShow.sprite = disturb;
            }
            else
            {
                win++;
            }
        }
    }

    public void Marah()
    {
        if (pressAble)
        {
            answered = true;
            spriteRendererPlayer.sprite = ekspresiPlayer[3];
            if (penontonChance != 4)
            {
                spriteRendererPenonton.sprite = ekspresiPenonton[4];
                spriteRendererShow.sprite = disturb;
            }
            else
            {
                win++;
            }
        }
    }

    private void Penonton()
    {
        penontonChance = Random.Range(1,5);
        switch (penontonChance) 
        {
            case 1:
                spriteRendererPenonton.sprite = ekspresiPenonton[0];
                break;
            case 2:
                spriteRendererPenonton.sprite = ekspresiPenonton[1];
                break;
            case 3:
                spriteRendererPenonton.sprite = ekspresiPenonton[2];
                break;
            case 4:
                spriteRendererPenonton.sprite = ekspresiPenonton[3];
                break;
        }

    }

    public IEnumerator StoryLine()
    {
        while (win<4)
        {
            pressAble = true;
            answered = false;
            Show();
            spriteRendererPlayer.sprite = ekspresiPlayer[0];
            spriteRendererPenonton.sprite = ekspresiPenonton[0];


            yield return new WaitForSeconds(1);
            Penonton();

            while (!answered)
            {
                yield return null;
            }
            pressAble = false;

            yield return new WaitForSeconds(5);

            yield return null;
        }

        if (win>=4)
        {
            SceneManager.LoadScene("Win");
        }
    }

    


}

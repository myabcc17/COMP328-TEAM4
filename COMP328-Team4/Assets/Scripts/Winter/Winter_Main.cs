using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Winter_Main : MonoBehaviour
{
    public Image Timer_bar;
    public Image Fish;
    public float var;
    public Sprite[] ArrowImages = new Sprite[4];
    public GameObject[] Arrows = new GameObject[4];
    public Text[] ArrowText = new Text[4];
    public Text[] ArrowSequence = new Text[4];
    public int count = 0;
    public AudioSource BGM;
    public AudioSource clearsound;
    public AudioSource XSound;
    public Text CountText;
    public int buttonCount = 0;
    public GameObject resultPanel;
    public Text FinalScore;
    // Use this for initialization
    void Start()
    {
        Fish.fillAmount = 0;
        CountText.text = count.ToString();
        BGM.Play();
        RandomArrows();
        resultPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Timer_bar.fillAmount -= Time.deltaTime / 60;
        var = Time.time;
        if (Timer_bar.fillAmount <= 0f)
        {
            FinalScore.text = "붕어빵 수익 : " + count * 500;
            resultPanel.SetActive(true);
        }
    }

    public void RandomArrows()
    {
        float rand;
        int n;
        int[] check = new int[4];

        
        for(int i=0; i<4; i++)
        {
            rand = Random.value;
            n = ((int)(rand * 10) % 4);
            
            Arrows[i].GetComponent<Image>().sprite = ArrowImages[n];
            ArrowSequence[i].text = n + "";
        }
        ArrowSetActive();
    }

    public void ButtonCheck(Text text)
    {
        if (text.text == ArrowSequence[buttonCount].text)
            Correct(buttonCount++);
        else
        {
            InCorrect();
            buttonCount = 0;
        }
        if (buttonCount == 4)
            buttonCount = 0;
    }

    public void Correct(int n)
    {
        if (n == 3)
        {
            Arrows[n].SetActive(false);
            Increment_fish();
            AddFish();
            RandomArrows();
            clearsound.Play();
        }
        else
        {
            Increment_fish();
            Arrows[n].SetActive(false);
        }
    }

    public void InCorrect()
    {
        XSound.Play();
        ArrowSetDeactivate();
        Fish.fillAmount = 0;
        RandomArrows();
    }

    void ArrowSetActive()
    {
        for (int i = 0; i < 4; i++)
            Arrows[i].SetActive(true);
    }

    void ArrowSetDeactivate()
    {
        for (int i = 0; i < 4; i++)
            Arrows[i].SetActive(false);
    }

    public void Increment_fish()
    {
        Fish.fillAmount += (float)0.25;
    }

    void AddFish()
    {
        Text text = GameObject.Find("PlusText").GetComponent<Text>();
        text.color = Color.black;
        StartCoroutine(FadeOut());
        Fish.fillAmount = 0;
        count++;
        CountText.text = count.ToString();
        //text.color = new Color(50, 50, 50, 0);
    }

    IEnumerator FadeOut()
    {
        float fadeOutTime = 1f;
        Text text = GameObject.Find("PlusText").GetComponent<Text>();
        Color originalColor = text.color;
        for(float i = 0.1f ; i <= fadeOutTime; i += Time.deltaTime)
        {
            text.color = Color.Lerp(originalColor, Color.clear, Mathf.Min(1, i/fadeOutTime));
            yield return null;
        }
    }
    
}

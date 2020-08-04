using UnityEngine.UI;
using System;
using UnityEngine;

public class CS_Score : MonoBehaviour
{

    public GameObject scoreTracker;
    public float scoreIncrement = 0.1f;
    private float plus100 = 0;

    public Vector3 minScale ;
    public Vector3 maxScale;

    public Vector3 minMove;
    public Vector3 maxMove;

    public float lerpSpeed = 10f;

    public Text scoreText;

    float scoreNumber;
    

    // Start is called before the first frame update
    void Awake()
    {
        scoreText = GameObject.Find("Text Score Change").GetComponent<Text>();
        scoreTracker = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        scoreText.font;
        scoreText.color = red; 
        scoreText.fontSize;
        */

        /*
        scoreText.transform.rotation = Quaternion.Euler(0f, 0f, 12 * Mathf.Sin(Time.time * lerpSpeed));
        scoreText.transform.localScale = Vector3.Lerp(minScale, maxScale, Time.deltaTime * lerpSpeed);
        scoreText.transform.position = Vector3.Lerp(minMove, maxMove, Time.deltaTime * lerpSpeed);
        */

        //Mathf.SmoothStep(0, 4, Mathf.PingPong(Time.time * 5, 1));

        scoreTracker.transform.Translate(0, 0 + scoreIncrement, 0);

        
        scoreNumber = (int)scoreTracker.transform.position.y + plus100; 

        scoreText.text = scoreNumber.ToString();

        if (scoreTracker.transform.position.y >= 100f)
        {
            plus100 = plus100 + 100f;

            scoreTracker.transform.Translate(0, -100, 0);
        }

        switch (scoreNumber) //changes font colour based on score
        {
            case 0: scoreText.color = Color.black; break;

            case 50: scoreText.color = Color.black; break;

            case 100: scoreText.color = Color.red; break;

            case 250: scoreText.color = Color.magenta; break;

            case 500: scoreText.color = Color.yellow; break;

            case 1000: scoreText.color = Color.cyan; break;

            case 1200: scoreText.color = Color.blue; break;

            case 1400: scoreText.color = Color.green; break;

            case 1600: scoreText.color = Color.blue; break;

            case 1700: scoreText.color = Color.red; break;

            case 1800: scoreText.color = Color.blue; break;

            case 1900: scoreText.color = Color.red; break;

            case 2000: scoreText.color = Color.black; break;

        }


        


    }
    
}

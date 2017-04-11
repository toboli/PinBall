using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{

    public GameObject scoreText; //Text用変数
    private int score = 0; //スコア計算用変数

    // Use this for initialization
    void Start()
    {
        //score = 0;
        this.scoreText = GameObject.Find("ScoreCount");
        SetScore();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "SmallStarTag"){
            score += 10;
           
        }
        else if(collision.gameObject.tag == "LargeStarTag"){
            score += 20;
            
        }
        else if(collision.gameObject.tag == "SmallCloudTag")
        {
            score += 5;
            
        }
        else if(collision.gameObject.tag == "LargeCloudTag")
        {
            score += 30;
            
        }
        SetScore();

        
            Debug.Log(collision.gameObject.name);

        

    }

    void SetScore(){
        this.scoreText.GetComponent<Text>().text = "SCORE:" + score;

    }

}
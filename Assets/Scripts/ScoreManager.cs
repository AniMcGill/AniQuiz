using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ScoreManager : MonoBehaviour {

    int score1;
    int score2;
    int score3;
    int score4;
    private Text rankings;


    // Use this for initialization
    void Start () {
        rankings = this.GetComponent<Text>();
        score1 = GameControl.control.GetScore(1);
        score2 = GameControl.control.GetScore(2);
        score3 = GameControl.control.GetScore(3);
        score4 = GameControl.control.GetScore(4);
        GameControl.control.LoadButtonState();
        UpdateScore();
    }

    public void AddScore(int n)
    {
        switch (n)
        {
            case 1:
                score1++;
                break;
            case 2:
                score2++;
                break;
            case 3:
                score3++;
                break;
            case 4:
                score4++;
                break;
            default:
                break;
        }
        UpdateScore();
    }

    public void SubScore(int n)
    {
        switch (n)
        {
            case 1:
                score1--;
                break;
            case 2:
                score2--;
                break;
            case 3:
                score3--;
                break;
            case 4:
                score4--;
                break;
            default:
                break;
        }
        UpdateScore();
    }

    void UpdateScore()
    {
        rankings.text = "Player 1: " + score1 +'\n' 
            + "Player 2: " + score2 +'\n' 
            + "Player 3: " + score3 + '\n' 
            + "Player 4: " + score4;
        GameControl.control.SaveScore(score1, score2, score3, score4);
    }
}

using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using System.IO;
using System.Text.RegularExpressions;

public class QuestionManager : MonoBehaviour {

    public enum SeekDirection { Forward, Backward }

    public Text currentQuestion;
    public Text currentAnswer;
    private TextAsset input;

    [SerializeField]
    [HideInInspector]
    private int currentIndex = 0;

    List<string> questions = new List<string>();
    List<string> answers = new List<string>();

    // Use this for initialization
    void Start () {
        //LoadText("VoiceActors");
    }

    public void LoadText(string group)
    {
        currentIndex = 0;
        currentQuestion.text = System.String.Empty;
        currentAnswer.text = "Correct Answers:";
        input = (TextAsset) Resources.Load("Questions/" + group, typeof(TextAsset));
        parseTextAsset(input);
        currentQuestion.text = questions[currentIndex];
        currentAnswer.text += System.Environment.NewLine + (currentIndex + 1) + "." + answers[currentIndex];
    }

    public void Seek(bool dir)
    {
        SeekDirection d = SeekDirection.Forward;
        if (dir == true)
        { d = SeekDirection.Forward; }
        else if (dir == false) { d = SeekDirection.Backward; }

        if (d == SeekDirection.Forward)
        {
            currentIndex = currentIndex + 1;
            if (currentIndex == questions.Count)
            {
                currentIndex = 0;
            }
            currentQuestion.text = questions[currentIndex];
            if (!currentAnswer.text.Contains(answers[currentIndex]))
            {
                currentAnswer.text += System.Environment.NewLine + (currentIndex + 1) + "." + answers[currentIndex];
            }
        }
        else
        {
            currentIndex--;
            if (currentIndex < 0)
            {
                currentIndex = questions.Count - 1;
            }
            currentQuestion.text = questions[currentIndex];
            if (!currentAnswer.text.Contains(answers[currentIndex]))
            {
                currentAnswer.text += System.Environment.NewLine + (currentIndex + 1) + "." + answers[currentIndex];
            }
        }
    }

    private void parseTextAsset(TextAsset ft)
    {
        questions.Clear();
        answers.Clear();
        string fs = ft.text;
        string[] fLines = Regex.Split(fs, "\n");
        
        for (int i = 0; i < fLines.Length; i++)
        {
            string valueLine = fLines[i];
            string[] values = Regex.Split(valueLine, "\t");
            questions.Add(values[0]);
            answers.Add(values[1]);
        }
    }

    public void ReturnToMain()
    {
        GameControl.control.LoadScene("menu");
    }
}

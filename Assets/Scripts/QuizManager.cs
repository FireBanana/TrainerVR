using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

public class QuizManager : MonoBehaviour
{
    public TextMeshPro Title, Question;
    public SpriteRenderer QuestionIcon;

    public List<GameObject> ChoiceObjects;
    int correctAnswers;

    int questionPointer = 0;

    private void Start()
    {
        QuizLibrary.Initialize();
    }

    public void AnswerCallback(int id)
    {
        if (questionPointer != 0)
        {
            if (id == QuizLibrary.QuestionList[questionPointer - 1].CorrectChoice)
            {
                correctAnswers++;
            }
        }

        if(questionPointer >= QuizLibrary.QuestionList.Count)
        {
            //END Quiz
            return;
        }

        var currentQuestion = QuizLibrary.QuestionList[questionPointer];

        if (currentQuestion.HasImage)
        {
            QuestionIcon.gameObject.SetActive(true);
            QuestionIcon.sprite = currentQuestion.Image;
        }
        else
            QuestionIcon.gameObject.SetActive(false);

        var builder = new StringBuilder();
        builder.Append(currentQuestion.QuestionText).Append("\n\n");

        for (int i = 0; i < ChoiceObjects.Count; i++)
        {
            if(i + 1 > currentQuestion.Choices.Length)
            {
                ChoiceObjects[i].SetActive(false);
            }
            else
            {
                ChoiceObjects[i].SetActive(true);
                builder.Append(i + 1).Append(") ").Append(currentQuestion.Choices[i]).Append("\n");
            }
        }

        Question.text = builder.ToString();

        questionPointer++;
    }
}

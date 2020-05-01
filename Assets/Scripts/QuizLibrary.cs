using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class QuizLibrary
{
    static int id = 0;

    public struct Question
    {
        public int Id;
        public string QuestionText;
        public string[] Choices;
        public int CorrectChoice;
        public bool HasImage;
        public Sprite Image;
    }

    public static List<Question> QuestionList = new List<Question>();

    public static void Initialize()
    {
        SetQuestion("How many tires are there on a car?", new string[] {"3", "4", "5", "6"}, 1);
        SetQuestion("Which side of the road do you drive on in Pakistan?", new string[] {"Left", "Right"}, 0);
        SetQuestion("What does this sign mean?", new string[] { "Go", "High Five", "Stop" }, 2, "stop");
    }

    static void SetQuestion(string questionText, string[] choices, int correctChoice)
    {
        var question = new Question()
        {
            QuestionText = questionText,
            Choices = choices,
            CorrectChoice = correctChoice
        };

        question.Id = id;
        id++;

        QuestionList.Add(question);
    }

    static void SetQuestion(string questionText, string[] choices, int correctChoice, string imgLocation)
    {
        var img = Resources.Load<Sprite>(imgLocation);

        var question = new Question()
        {
            QuestionText = questionText,
            Choices = choices,
            CorrectChoice = correctChoice,
            HasImage = true,
            Image = img
        };

        question.Id = id;
        id++;

        QuestionList.Add(question);
    }

}

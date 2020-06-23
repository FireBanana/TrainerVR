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
        SetQuestion("The triangle in this picture stands for?", new string[] { "Warning sign", "Prohibitive sign", "Indicative sign", "Directional sign" }, 0, "warning");
        SetQuestion("The sign in this picture stands for?", new string[] { "Bridge widens", "Bridge widens on both sides", "Narrow bridge", "Hump bridge" }, 2, "bridge");
        SetQuestion("The sign in this picture means?", new string[] { "Right turn is allowed", "Changing to the right lane is prohibited", "Right U turn is prohibited", "Right turn is prohibited" }, 3, "rightturn");
        SetQuestion("The sign in this picture stands for?", new string[] { "No road borrowing", "No overtaking", "Overtaking ban is lifted", "Overtaking allowed" }, 1, "overtake");
        SetQuestion("The numbered sign in this picture shows?", new string[] { "Weight is limited", "Road number is 40", "Speed limit is 40km/h", "You can drive above 40km/h" }, 2, "speed");
        SetQuestion("The sign in this picture shows?", new string[] { "Car park", "Service area", "Push forward", "Dead end ahead" }, 0, "parking");
        SetQuestion("What should always be kept clean on your vehicle?", new string[] { "Lights", "Reflectors", "Tires", "Screens" }, 3);
        SetQuestion("What is the speed limit on the motorway?", new string[] { "100 km/h", "80km/h", "70km/h", "120 km/h" }, 3);
        SetQuestion("What is the speed limit near a mosque or school?", new string[] { "80 km/h", "50km/h", "40km/h", "60 km/h" }, 2);
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

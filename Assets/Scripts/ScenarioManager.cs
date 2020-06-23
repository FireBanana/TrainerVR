using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScenarioManager : MonoBehaviour
{
    public static int BaseTime;
    int remainingTime;
    public GameObject TimerHUD;
    public GameObject TimerText;

    public enum Scenario
    {
        Cones,
        UTurn,
        Parking,
        ChangeTire,
        EngineWater,
        Complete,
        FreeRoam
    }

    public static Scenario CurrentScenario;
    public static bool EnableTimer;
    public GameObject ConeContainer;
    public GameObject CompleteContainer;

    bool isTimerRunning;

    private void Start()
    {
        remainingTime = BaseTime;
        SetScenario();

        if (EnableTimer)
        {
            TimerHUD.SetActive(true);
            var timerText = TimerText.GetComponent<TextMeshProUGUI>();
            timerText.text = remainingTime.ToString();
            StartCoroutine(CountDown());
        }
    }

    IEnumerator CountDown()
    {
        isTimerRunning = true;
        var timerText = TimerText.GetComponent<TextMeshProUGUI>();

        while (isTimerRunning)
        {
            yield return new WaitForSeconds(1);
            remainingTime--;
            timerText.text = remainingTime.ToString();

            if (remainingTime <= 0)
            {
                SetEnding();
            }
        }
    }

    public void SetEnding()
    {
        isTimerRunning = false;

        if (CurrentScenario == Scenario.Cones)
        {
            var result = ConeContainer.GetComponent<Cones>().Evaluate();

            var conesMoved = result[0];
            var totalHits = result[1];
            var collectibles = result[2];

            //Add average results?

            int score = 0;

            if (conesMoved > 5 && conesMoved <= 8)
                score++;
            else if (conesMoved > 2 && conesMoved <= 5)
                score += 2;
            else
                score += 4;

            if (collectibles == 1)
                score += 3;
            else if (collectibles == 2)
                score += 6;

            SupplementScreenManager.ShowEnding((BaseTime - remainingTime).ToString() + " seconds", $"{score}/10", "Menu", $"Cones Moved: {conesMoved}/12\nBags Collected: {collectibles}/2\nTotal Hits: {totalHits}");
        }
        else if (CurrentScenario == Scenario.ChangeTire)
        {

        }
        else if (CurrentScenario == Scenario.EngineWater)
        {

        }
        else if (CurrentScenario == Scenario.FreeRoam)
        {

        }
        else if (CurrentScenario == Scenario.Parking)
        {

        }
        else if (CurrentScenario == Scenario.Complete)
        {
            int elapsedTime = BaseTime - remainingTime;
            int score = (int)Mathf.Lerp(0, 10, 1 - elapsedTime / 50);

            SupplementScreenManager.ShowEnding((BaseTime - remainingTime).ToString() + " seconds", $"{score}/10", "Menu", "");
        }
        else if (CurrentScenario == Scenario.UTurn)
        {

        }
    }

    void SetScenario()
    {
        if (CurrentScenario == Scenario.Cones)
        {
            ConeContainer.SetActive(true);
        }
        else if (CurrentScenario == Scenario.ChangeTire)
        {
            //wheel made
        }
        else if (CurrentScenario == Scenario.EngineWater)
        {

        }
        else if (CurrentScenario == Scenario.FreeRoam)
        {

        }
        else if (CurrentScenario == Scenario.Parking)
        {

        }
        else if (CurrentScenario == Scenario.Complete)
        {
            CompleteContainer.SetActive(true);
        }
        else if (CurrentScenario == Scenario.UTurn)
        {

        }
    }
}

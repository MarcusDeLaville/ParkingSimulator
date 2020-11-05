using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Statistic : MonoBehaviour
{
    private int _answersCount;
    private int _correctAnswerCount;
    private int _wrongAnswerCount;

    [SerializeField] private DrawStatistic _drawStatistic;

    private void Awake()
    {
        _answersCount = PlayerPrefs.GetInt("AnswersCount");
        _correctAnswerCount = PlayerPrefs.GetInt("CorrectAnswerCount");
        _wrongAnswerCount = PlayerPrefs.GetInt("WrongAnswerCount");

        _drawStatistic.Draw(_wrongAnswerCount, _correctAnswerCount, _answersCount);
    }

    private void AddAnswerCount()
    {
        _answersCount++;
        _drawStatistic.Draw(_wrongAnswerCount, _correctAnswerCount, _answersCount);
    }

    public void AddCorrectAnswer()
    {
        _correctAnswerCount++;
        AddAnswerCount();
    }

    public void AddWrongAnswer()
    {
        _wrongAnswerCount++;
        AddAnswerCount();
    }

    private void SaveStatistic()
    {
        PlayerPrefs.SetInt("AnswersCount", _answersCount);
        PlayerPrefs.SetInt("CorrectAnswerCount", _correctAnswerCount);
        PlayerPrefs.SetInt("WrongAnswerCount", _wrongAnswerCount);
    }

    private void OnApplicationPause(bool pause)
    {
        SaveStatistic();
    }

    private void OnApplicationQuit()
    {
        SaveStatistic();
    }
}

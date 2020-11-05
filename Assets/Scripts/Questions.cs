using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Questions : MonoBehaviour
{
    [SerializeField] private List<Question> _questions;

    [SerializeField] private SuccessIndication _successIndication;
    [SerializeField] private LevelLoader _levelLoader;
    [SerializeField] private Text _hintText;

    [SerializeField] private int _currentQuestion = 0;

    private void Start()
    {
        PickCurrentQuestion();
    }

    public void PickCurrentQuestion()
    {
        _successIndication.HideIndication();
        _hintText.text = _questions[_currentQuestion].HintText;
        _levelLoader.LoadLevel(_questions[_currentQuestion].LevelPrefab);
    }

    public void PickNextQuestion()
    {
        if (_currentQuestion == _questions.Count - 1)
        {
            _currentQuestion = 0;
        }
        else
        {
            _currentQuestion++;   
        }

        PickCurrentQuestion();
    }

    [Serializable]
    public struct Question
    {
        public string HintText;
        public Level LevelPrefab;
    }
}

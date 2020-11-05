using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrawStatistic : MonoBehaviour
{
    [SerializeField] private Text _statisticText;
    [SerializeField] private Text _fullStatisticText;

    public void Draw(int wrong, int correct, int answersCount)
    {
        _statisticText.text = $"<color=green>{correct}</color>/<color=red>{wrong}</color>";
        _fullStatisticText.text = $"Всего решено: {answersCount}\nВерно выполнено: <color=green>{correct}</color>\nДопущено ошибок: <color=red>{wrong}</color>";
    }
}

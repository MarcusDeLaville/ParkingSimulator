using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum IndicationType
{
    Success,
    Failure
}

public class SuccessIndication : MonoBehaviour
{
    [SerializeField] private Sprite _successSprite;
    [SerializeField] private Sprite _failureSprite;
    [SerializeField] private Image _indicatorImage;

    public void ShowIndication(IndicationType indicationType)
    {
        if (indicationType == IndicationType.Failure)
        {
            _indicatorImage.sprite = _failureSprite;           
        }
        else
        {
            _indicatorImage.sprite = _successSprite;
        }

        _indicatorImage.fillAmount = 1;
    }

    public void HideIndication()
    {
        _indicatorImage.fillAmount = 0;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private Transform _parrent;
    [SerializeField] private Image _roadImage;
    [SerializeField] private SuccessIndication _successIndication;

    private Level _currentLevel;

    public UnityEvent CorrectEventBase;
    public UnityEvent AlmostCorrectEventBase;
    public UnityEvent Restart;

    public void LoadLevel(Level level)
    {
        if (_currentLevel != null)
        {
            Destroy(_currentLevel.gameObject);
        }

        _currentLevel = Instantiate(level, Vector3.zero, Quaternion.identity, _parrent);

        _currentLevel.SetSuccessIndication(_successIndication);
        _roadImage.sprite = _currentLevel.RoadSprite;

        _currentLevel.AlmostCorrectEvent = AlmostCorrectEventBase;
        _currentLevel.CorrectEvent = CorrectEventBase;
        _currentLevel.RestartLevel = Restart;
    }
}

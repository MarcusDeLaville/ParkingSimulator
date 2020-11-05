using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Level : MonoBehaviour
{
    [SerializeField] private GameObject _levelSigns;
    [SerializeField] private Sprite _roadSprite;
    private SuccessIndication _successIndication;

    public GameObject LevelSigns => _levelSigns;
    public Sprite RoadSprite => _roadSprite;

    public UnityEvent CorrectEvent;
    public UnityEvent AlmostCorrectEvent;

    public UnityEvent StartEvent;
    public UnityEvent RestartLevel;

    private void Start()
    {
        StartEvent.Invoke();
    }

    public void AnswerConsequences(PathTypes pathTypes, VehicleMovement pathMoving)
    {
        _levelSigns.SetActive(false);
        StartCoroutine(Consequences(pathTypes, pathMoving));
    }

    public void SetSuccessIndication(SuccessIndication successIndication)
    {
        _successIndication = successIndication;
    }

    private IEnumerator Consequences(PathTypes pathTypes, VehicleMovement pathMoving)
    {
        if (pathTypes == PathTypes.NotCorrect)
        {
            _successIndication.ShowIndication(IndicationType.Failure);
            yield return new WaitForSeconds(0.5f);

            if (pathMoving != null)
            {
                pathMoving.PlayPath(0);
            }

            yield return new WaitForSeconds(2f);      
            RestartLevel.Invoke();
        }
        else if (pathTypes == PathTypes.Correct)
        {
            _successIndication.ShowIndication(IndicationType.Success);
            yield return new WaitForSeconds(4f);
            CorrectEvent.Invoke();
        }
        else
        {
            _successIndication.ShowIndication(IndicationType.Failure);
            yield return new WaitForSeconds(1f);
            AlmostCorrectEvent.Invoke();
        }
    }
}

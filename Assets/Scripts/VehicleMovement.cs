using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public enum PathTypes
{
    None,
    Correct,
    AlmostCorrect,
    NotCorrect
}

public class VehicleMovement : MonoBehaviour
{
    [SerializeField] private List<Path> _movingPaths;
    [SerializeField] private float _speed = 5;

    [SerializeField] private float _distanceTravelled;
    [SerializeField] private PathCreator _currentWay;
    [SerializeField] private Level _currentLevel;

    private EndOfPathInstruction _endOfPathInstruction = EndOfPathInstruction.Stop;
    private bool _isMoving = false;

    public void PlayPath(int index)
    {
        _currentWay = _movingPaths[index].PathWay;
        _currentWay.pathUpdated += OnPathChanged;
        _isMoving = true;

        if (_movingPaths[index].PathType != PathTypes.None)
        {
            _currentLevel.AnswerConsequences(_movingPaths[index].PathType, _movingPaths[index].ConsequencesWay);
        }
    }

    private void Update()
    {
        if (_isMoving == true)
        {
            _distanceTravelled += _speed * Time.deltaTime;
            transform.position = _currentWay.path.GetPointAtDistance(_distanceTravelled, _endOfPathInstruction);
            transform.rotation = _currentWay.path.GetRotationAtDistance(_distanceTravelled, _endOfPathInstruction);
        }
    }

    private void OnPathChanged()
    {
        _distanceTravelled = _currentWay.path.GetClosestDistanceAlongPath(transform.position);
    }

    [Serializable]
    public struct Path
    {
        public PathTypes PathType;
        public PathCreator PathWay;
        public VehicleMovement ConsequencesWay;
    }
}

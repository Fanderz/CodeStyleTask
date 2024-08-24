using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private Transform _point;
    [SerializeField] private float _speed;

    private Transform[] _childPoints;
    private int _pointIndex = 0;

    private void Start()
    {
        _childPoints = new Transform[_point.childCount];

        for (int i = 0; i < _point.childCount; i++)
            _childPoints[i] = _point.GetChild(i);
    }

    private void Update()
    {
        Transform target = _childPoints[_pointIndex];

        if (transform.position == target.position)
            target = GetNexPoint();

        transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);
    }

    private Transform GetNexPoint()
    {
        if (_pointIndex == _childPoints.Length)
            _pointIndex = 0;

        return _childPoints[_pointIndex++];
    }
}
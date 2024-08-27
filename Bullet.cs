using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Rigidbody _rigidbody;
    private Vector3 _direction;

    private void Start()
    {
        TryGetComponent(out _rigidbody);
    }

    private void OnEnable()
    {
        if (_rigidbody != null)
        {
            _rigidbody.transform.up = _direction;
            _rigidbody.velocity = _direction * _speed;
        }
    }

    internal void SetDirection(Vector3 direction) =>
        _direction = direction;
}
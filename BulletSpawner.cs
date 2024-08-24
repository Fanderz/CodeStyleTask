using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class BulletsSpawner : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _shootDelay;
    [SerializeField] private GameObject _prefab;
    [SerializeField] private Transform _target;

    private bool _isRunning;
    private Coroutine _coroutine;

    private void OnEnable()
    {
        _isRunning = true;
        _coroutine = StartCoroutine(Spawning());
    }

    private void OnDisable()
    {
        _isRunning = false;
        StopCoroutine(_coroutine);
    }

    private IEnumerator Spawning()
    {
        var wait = new WaitForSeconds(_shootDelay);

        while (_isRunning)
        {
            Vector3 direction = (_target.position - transform.position).normalized;
            GameObject newBullet = Instantiate(_prefab, transform.position + direction, Quaternion.identity);

            newBullet.TryGetComponent(out Rigidbody bulletRigidbody);

            if (bulletRigidbody != null)
            {
                bulletRigidbody.transform.up = direction;
                bulletRigidbody.velocity = direction * _speed;
            }

            yield return wait;
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private Pipe _prefab;
    [SerializeField] private float _delay;
    [SerializeField] private PipeSpawnpoint[] _spawnpoints;

    private WaitForSeconds _spawnDelay;

    private ObjectPool<Pipe> _pool;

    private List<Pipe> _activeObjects;

    private void Start()
    {
        _pool = new ObjectPool<Pipe>(
            createFunc: () => InstantiatePipe(),
            actionOnGet: (Pipe pipe) => pipe.gameObject.SetActive(true),
            actionOnRelease: (Pipe pipe) => pipe.gameObject.SetActive(false),
            actionOnDestroy: (Pipe pipe) => Destroy(pipe)
            );

        _activeObjects = new List<Pipe>();
        _spawnDelay = new WaitForSeconds(_delay);

        StartCoroutine(SpawnPipes());
    }

    private Pipe InstantiatePipe()
    {
        Pipe pipe = Instantiate(_prefab);

        pipe.OutOfBounds += ReleasePipe;

        return pipe;
    }

    private void GetPipe()
    {
        Pipe pipe = _pool.Get();

        pipe.transform.position = _spawnpoints[Random.Range(0, _spawnpoints.Length)].transform.position;

        _activeObjects.Add(pipe);
    }

    private void ReleasePipe(Pipe pipe)
    {
        if (_activeObjects.Contains(pipe) == false)
            return;

        _pool.Release(pipe);
        _activeObjects.Remove(pipe);
    }

    private IEnumerator SpawnPipes()
    {
        while (enabled)
        {
            GetPipe();

            yield return _spawnDelay;
        }
    }

    public void RemoveAllPipes()
    {
        foreach (Pipe pipe in _activeObjects)
        {
            _pool.Release(pipe);
        }
    }
}

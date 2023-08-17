using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandBlock : MonoBehaviour
{
    [SerializeField] private Transform _spawnPos;
    [SerializeField] private GameObject _spawnObject;
    private GameObject _object;

    public void ReceivedSignal()
    {
        if (!_object) _object = Instantiate(_spawnObject, _spawnPos.position, Quaternion.identity);
    }
    public void CancelSignal()
    {
        Destroy(_object);
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class MoveBackground : MonoBehaviour
{
    [SerializeField] private float boxSize;
    [SerializeField] private int quatity;

    private void OnTriggerEnter2D(Collider2D _other)
    {
        if (_other.CompareTag("Background")) {
            Vector3 _newPosition = _other.transform.position;
            _newPosition.x += boxSize * quatity;
            _other.transform.position = _newPosition;
        }
    }
}

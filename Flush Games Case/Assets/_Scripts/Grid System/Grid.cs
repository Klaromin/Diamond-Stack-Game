using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    [SerializeField] private Transform gridDebugObjectPrefab;
    [SerializeField] private int _height;
    [SerializeField] private int _width;
    [SerializeField] private float cellSize;
    private GridSystem _gridSystem;
    
    void Start()
    {
        _gridSystem = new GridSystem(_width, _height, cellSize);
        _gridSystem.CreateDebugObjects(gridDebugObjectPrefab, this.transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

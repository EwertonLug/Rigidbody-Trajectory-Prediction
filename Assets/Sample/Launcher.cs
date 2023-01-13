using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    [SerializeField] [Range(0, 50)] private float _speed;
    [SerializeField] [Range(0, 5)] private float _simulationSeconds = 2f;
    [SerializeField] private Rigidbody _projectile;
    [SerializeField] private LineRenderer _lineRenderer;
    [SerializeField] private Vector3 offset = Vector3.zero;

    private List<Vector3> _positions = new List<Vector3>();

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            TrajetoryPrediction prediction = new TrajetoryPrediction();
            _positions = prediction.Simulate(transform.forward * _speed, _projectile.mass, transform.position + offset, _simulationSeconds, Time.deltaTime);
            _lineRenderer.positionCount = _positions.Count;
            _lineRenderer.SetPositions(_positions.ToArray());
            Fire();
        }
    }


    public void Fire()
    {
        var body = Instantiate(
            _projectile,
            transform.TransformPoint(offset),
            transform.rotation);

        var projectile = body.GetComponent<Projectile>();
        projectile.Setup(transform.forward * _speed);
    }

    private void OnDrawGizmos()
    {
        foreach (var position in _positions)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(position, .1f);
        }
    }
}

using System.Collections.Generic;
using UnityEngine;

public class TrajetoryPrediction
{
    public List<Vector3> Simulate(Vector3 direction, float  mass, Vector3 startPosition, float simulationTicks, float deltaTime)
    {
        var positions = new List<Vector3>();

        var velocity = direction /
            mass;
        var position = startPosition;
        var physicsStep = deltaTime;

        for (var i = 0f; i <= simulationTicks; i += physicsStep)
        {
            positions.Add(position);
            position += velocity * physicsStep;
            velocity += Physics.gravity * physicsStep;

        }

        return positions;
    }

}

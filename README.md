# Rigidbody-Trajectory-Prediction
Simulate the trajectory of a rigid body in n seconds
## How to use
Create an instance of the class:

TrajetoryPrediction prediction = new TrajetoryPrediction();

Run the Simulate method by passing the required parameters:
Ex:
var positions = prediction.Simulate(transform.forward *_speed, _projectile.mass, transform.position + offset, _simulationSeconds, Time.deltaTime);

## Parameters

- direction - Direction the object will be thrown
- mass
- simulationTime - maximum time ahead to simulate
- offsetPosition - Detachment of positions, if necessary - 
  Pass a Vector.Zero if you want the exact simulation
- deltaTime

## Limintation
Does not predict interference from collisions in the scene that change the direction of the object

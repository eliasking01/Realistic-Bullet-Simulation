using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileEquation : MonoBehaviour
{
    public static Vector3 Equation(float time, float shootAngleYaw, float shootAnglePitch, float muzzleVelocity, float gravityForce, float airDensity, float mass, float diameter, float windSpeed, float windAngle, bool useGravity, bool useWind)
    {
        // initial variables
        Vector3 gravityVector = new Vector3(0, 0, 0);
        Vector3 windVector = new Vector3(0, 0, 0);

        // calculates the cross-sectional area of the bullet
        float crossSectionalArea = Mathf.PI * Mathf.Pow(diameter / 2, 2);

        // calculates the innitial x, y, and z velocities of the projectile
        float initialVelocityX = muzzleVelocity * Mathf.Cos(-shootAngleYaw * Mathf.Deg2Rad) * Mathf.Cos(shootAnglePitch * Mathf.Deg2Rad);
        float initialVelocityY = muzzleVelocity * Mathf.Sin(shootAnglePitch * Mathf.Deg2Rad);
        float initialVelocityZ = muzzleVelocity * Mathf.Sin(-shootAngleYaw * Mathf.Deg2Rad) * Mathf.Cos(shootAnglePitch * Mathf.Deg2Rad);

        Vector3 initialVelocityVector = new Vector3(initialVelocityX, initialVelocityY, initialVelocityZ);

        if (useGravity)
        {
            // makes the gravity acceleration compatable with the kinematic equation
            float gravity = -(0.5f * gravityForce * Mathf.Pow(time, 2));
            gravityVector = new Vector3(0, gravity, 0);
        }

        if (useWind)
        {
            // calculates the air pressure
            float pressure = (airDensity / 2) * Mathf.Pow(windSpeed, 2);

            // calculates the wind acceleration
            float windX = ((crossSectionalArea * pressure * 0.47f /* <-- drag coefficient of a sphere */) / mass) * Mathf.Cos(windAngle * Mathf.Deg2Rad);
            float windZ = ((crossSectionalArea * pressure * 0.47f /* <-- drag coefficient of a sphere */) / mass) * Mathf.Sin(windAngle * Mathf.Deg2Rad);

            // makes the acceleration compatable with the kinematic equation
            windX = 0.5f * windX * Mathf.Pow(time, 2);
            windZ = 0.5f * windZ * Mathf.Pow(time, 2);

            windVector = new Vector3(windX, 0, windZ);
        }

        Vector3 coordinates = (initialVelocityVector * time) + windVector + gravityVector;
        return coordinates;
    }
}

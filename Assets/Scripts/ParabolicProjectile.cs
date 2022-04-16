using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParabolicProjectile : MonoBehaviour
{
    [Header ("Settings")]
    public bool useGravity;
    public bool useWind;

    [Header ("Bullet Settings")]
    [Tooltip ("m/s")] public float muzzleVelocity;
    [Tooltip ("grain")] public float mass;
    [Tooltip ("mm")] public float diameter;

    [Header ("Environmental Settings")]
    [Tooltip ("m/s^2")] public float gravityForce;
    [Tooltip ("m/s")] public float windSpeed;
    [Tooltip ("degrees")] [Range (0, 360)] public float windAngle;
    [Tooltip ("kg/m^3")] public float airDensity;

    float timeSinceShot;

    float shootAngleYaw = 0;
    float shootAnglePitch = 0;

    Vector3 initialFirePointPos;

    void Awake()
    {
        initialFirePointPos = transform.position;
        shootAngleYaw = Mathf.Repeat(transform.rotation.eulerAngles.y + 180, 360) - 180;
        shootAnglePitch = Mathf.Repeat(transform.rotation.eulerAngles.z + 180, 360) - 180;
    }

    void Update()
    {
        timeSinceShot += Time.deltaTime;
        transform.position = initialFirePointPos + ProjectileEquation.Equation(timeSinceShot, shootAngleYaw, shootAnglePitch, muzzleVelocity, gravityForce, airDensity, mass / 15432, diameter / 1000, windSpeed, windAngle, useGravity, useWind);
    }
}

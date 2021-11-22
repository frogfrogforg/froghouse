using System.Collections;
using System.Collections.Generic;
using UnityAtoms.BaseAtoms;
using UnityEngine;

public class CannonSpawner : MonoBehaviour
{
    public Rigidbody cannonBallPrefab;

    // Start is called before the first frame update

    public void ShootVelocityImpulse(Vector3 force)
        => ShootBase(force, ForceMode.Impulse);

    public void ShootVelocityChange(Vector3 force)
        => ShootBase(force, ForceMode.VelocityChange);

    public void ShootAcceleration(Vector3 force)
        => ShootBase(force, ForceMode.Force);

    public void ShootForce(Vector3 force)
        => ShootBase(force, ForceMode.Force);

    public void ShootForwardVelocityChange(FloatConstant velocity)
        => ShootForwardVelocityChange(velocity.Value);

    public void ShootForwardVelocityChange(FloatVariable velocity)
        => ShootForwardVelocityChange(velocity.Value);

    public void ShootForwardVelocityChange(float velocity)
        => ShootForwaredBase(velocity, ForceMode.VelocityChange);

    void ShootForwaredBase(float value, ForceMode forceMode)
    => ShootBase(transform.forward * value, forceMode);

    void ShootBase(Vector3 force, ForceMode forceMode)
    {
        var cannonBall = Instantiate(
            cannonBallPrefab,
            transform.position,
            Quaternion.identity);

        cannonBall.AddForce(force, forceMode);
    }
}

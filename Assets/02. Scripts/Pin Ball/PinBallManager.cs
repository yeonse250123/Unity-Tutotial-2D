using UnityEngine;

public class PinBallManager : MonoBehaviour
{
    public Rigidbody2D leftBarRb;
    public Rigidbody2D rightBarRb;

    public int totalScore = 0;

    public float pinTorqueForce;

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
            leftBarRb.AddTorque(pinTorqueForce);
        else
            leftBarRb.AddTorque(-pinTorqueForce);

        if (Input.GetKey(KeyCode.RightArrow))
            rightBarRb.AddTorque(-pinTorqueForce);
        else
            rightBarRb.AddTorque(pinTorqueForce);
    }
}

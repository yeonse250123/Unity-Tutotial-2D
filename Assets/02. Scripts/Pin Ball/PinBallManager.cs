using UnityEngine;

public class PinBallManager : MonoBehaviour
{
    public Rigidbody2D leftBarRb;
    public Rigidbody2D rightBarRb;

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
            leftBarRb.AddTorque(300f);
        else
            leftBarRb.AddTorque(-250f);

        if (Input.GetKey(KeyCode.RightArrow))
            rightBarRb.AddTorque(-300f);
        else
            rightBarRb.AddTorque(250f);
    }
}

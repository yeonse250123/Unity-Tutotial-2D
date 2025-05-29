using UnityEngine;

public class Pinball : MonoBehaviour
{
    public PinBallManager pinBallManager;

    public Transform pinballPos;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        int score = 0;
        switch (collision.gameObject.tag)
        {
            case "Score10":
                score = 10;
                break;
            case "Score30":
                score = 30;
                break;
            case "Score50":
                score = 50;
                break;
        }

        pinBallManager.totalScore += score;
        Debug.Log($"{score}Á¡ È¹µæ <ÇöÀç Á¡¼ö {pinBallManager.totalScore}>");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("GameOver"))
        {
            Debug.Log($"°ÔÀÓ ¿À¹ö <ÃÑÁ¡ : {pinBallManager.totalScore}>");

            pinBallManager.totalScore = 0;

            transform.position = pinballPos.position;
        }
    }
}

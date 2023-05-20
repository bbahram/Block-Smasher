using UnityEngine;

public class PaddleMove : MonoBehaviour
{
    [SerializeField] float screenUnit = 16f;
    [SerializeField] float minX = 1f, maxX = 15f;
    // cash refrenses
    GameSession gameSissy;
    Ball ball;
    // Start is called before the first frame update
    void Start()
    {
        gameSissy = FindObjectOfType<GameSession>();
        ball = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 paddleMovement = new Vector2(transform.position.x, transform.position.y);
        paddleMovement.x = Mathf.Clamp(GetXPos(), minX, maxX);
        transform.position = paddleMovement;
    }
    private float GetXPos()
    {
        if(gameSissy.IsAutoPlayEnabled())
        {
            return ball.transform.position.x;
        }
        else
            return Input.mousePosition.x / Screen.width * screenUnit;
    }
}

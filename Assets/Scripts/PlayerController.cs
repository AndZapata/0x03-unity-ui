using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed = 1000f;
    public Rigidbody rb;
    private int score = 0;
    public int health = 5;

    public void Update()
    {
        if (health == 0)
            {
                Debug.Log("Game Over!");
                Destroy(this.gameObject);
                SceneManager.LoadScene(0);
            }
    }
    public void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
            rb.AddForce(0, 0, speed * Time.deltaTime);
        if (Input.GetKey(KeyCode.A))
            rb.AddForce((-1 * speed) * Time.deltaTime, 0, 0);
        if (Input.GetKey(KeyCode.S))
            rb.AddForce(0, 0, (-1 * speed) * Time.deltaTime);
        if (Input.GetKey(KeyCode.D))
            rb.AddForce(speed * Time.deltaTime, 0, 0);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Pickup")
        {
            score = score + 1;
            Debug.Log("Score: " + score);
            Destroy(other.gameObject);
        }
        if (other.tag == "Trap")
        {
            health = health - 1;
            Debug.Log("Health: " + health);
        }
        if (other.tag == "Goal")
            Debug.Log("You win!");
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

	public float speed = 4f;
	public Rigidbody2D rb;
    public Joystick joystick;

    private float movement = 0f;
    

	// Update is called once per frame
	void Update () {
		movement = joystick.Horizontal * speed;
    }

    void FixedUpdate ()
	{
		rb.MovePosition(rb.position + new Vector2 (movement * Time.fixedDeltaTime, 0f));
    }

    void OnTriggerEnter2D (Collider2D col)
	{
		if (col.gameObject.tag == "Ball")
		{
			Debug.Log("GAME OVER!");
            if(LevelManager.LV != null)
            {
                LifeManager.LM.lifeCount--;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }

		}
	}

}

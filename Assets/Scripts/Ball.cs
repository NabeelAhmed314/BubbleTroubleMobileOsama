using System.Collections;
using Photon.Pun;
using UnityEngine;

public class Ball : MonoBehaviour {

	public Vector2 startForce;
	public GameObject nextBall;
	public Rigidbody2D rb;
    public GameObject startText;
    public bool noPause;
	// Use this for initialization
	void Start () {
        if(startText == null)
        {
            rb.constraints = RigidbodyConstraints2D.None;
            rb.AddForce(startForce, ForceMode2D.Impulse);
        }
        else
        {
            if (noPause == false)
            {
                rb.constraints = RigidbodyConstraints2D.FreezeAll;
                StartCoroutine(GameStart(3));
            }
            else
            {
                rb.constraints = RigidbodyConstraints2D.None;
                rb.AddForce(startForce, ForceMode2D.Impulse);
            }
        }
    }

    IEnumerator GameStart(float time)
    {
        yield return new WaitForSeconds(time);
        startText.SetActive(false);
        rb.constraints = RigidbodyConstraints2D.None;
        rb.AddForce(startForce, ForceMode2D.Impulse);
    }
    public void Split ()
	{
		if (nextBall != null)
		{
			GameObject ball1 = PhotonNetwork.Instantiate(nextBall.name, rb.position + Vector2.right / 4f, Quaternion.identity);
			GameObject ball2 = PhotonNetwork.Instantiate(nextBall.name, rb.position + Vector2.left / 4f, Quaternion.identity);

            ball1.GetComponent<Ball>().noPause = true;
            ball2.GetComponent<Ball>().noPause = true;

            ball1.GetComponent<Ball>().startForce = new Vector2(2f, 5f);
			ball2.GetComponent<Ball>().startForce = new Vector2(-2f, 5f);
		}
        Destroy(gameObject);
	}

}

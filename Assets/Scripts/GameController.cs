using UnityEngine;
using System.Collections;
using UnityEngine.UI;//for referring to text items

public class GameController : MonoBehaviour {

    public Camera cam;
    public GameObject ball;
    public Text timerText;
    public GameObject gameOverText;
    public GameObject restartButton;

    private float maxWidth;
    public float timeLeft;

    // Use this for initialization
    void Start()
    {
        if (cam == null)
        { cam = Camera.main; } //if no particular camera avilable,use the default mian camera
        Vector3 upperCorner = new Vector3(Screen.width, Screen.height, 0.0f);//Boundaries of screen
        Vector3 targetWidth = cam.ScreenToWorldPoint(upperCorner);
        float ballWidth = ball.GetComponent<Renderer>().bounds.extents.x;//extents is half of the total width
        maxWidth = targetWidth.x - ballWidth;
        StartCoroutine(Spawn());
        UpdateText();
    }

    void FixedUpdate()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0) { timeLeft = 0; }
        UpdateText();
       
    }
        IEnumerator Spawn()
    {
        yield return new WaitForSeconds(2.0f);
        while(timeLeft>0)
        
        {
            
                Vector3 spawnPosition = new Vector3(Random.Range(-maxWidth, maxWidth), transform.position.y, 0.0f);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(ball, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(Random.Range(1.0f, 2.0f));
            
        }
        yield return new WaitForSeconds(2.0f);
        gameOverText.SetActive(true);
        yield return new WaitForSeconds(2.0f);
        restartButton.SetActive(true);

    }
    void UpdateText()
    { timerText.text = "Time Left:" + Mathf.RoundToInt(timeLeft); }
    }


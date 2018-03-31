using UnityEngine;


public class PlayerController : MonoBehaviour {

    public float speed;
    private Rigidbody rb;

    Vector3 movement;

    public GameController gameController;

    void Update() //most game code will go here
    {
  
    }


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }

    }

    void FixedUpdate()// called before physics calcs
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Pick Up"))
        {
            Destroy(other.gameObject);
            gameController.AddScore(1);
    
        }
    }

}

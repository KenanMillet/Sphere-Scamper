using UnityEngine;
using UnityEngine.AI;

public class VillainController : MonoBehaviour {

    public Transform target;
    private NavMeshAgent agent;
    private Rigidbody rb;

    public GameController gameController;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();

        agent.updatePosition = false;
        agent.updateRotation = false;


        agent.destination = target.position;
        
    }

    // Update is called once per frame


    void FixedUpdate()
    {
        
        rb.AddForce(agent.desiredVelocity);

        //https://answers.unity.com/questions/889836/using-unity-navigation-in-a-fixed-timestep.html
    }

    void Update()
    {
        agent.nextPosition = rb.position;
        agent.destination = target.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.SetActive(false);
            gameController.Lose();
        }
    }

}

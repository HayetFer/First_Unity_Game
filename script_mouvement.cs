using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
public class script_mouvement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float movementSpeed = 6f;
    [SerializeField] float jumpForce = 5f;
    [SerializeField] GameObject[] floors;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask ground;
    [SerializeField] AudioSource jumpSound;
    int currentIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        rb.velocity = new Vector3(horizontalInput * movementSpeed, rb.velocity.y, verticalInput * movementSpeed);
        
        if (Input.GetButtonDown("Jump")&& isGrounded())
        {
            Jump();
        }
    }

    void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
    }

    bool isGrounded()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 3f, ground)) {
            return true;
        }
        return false;
    }

   bool isOnFloor(GameObject floor)
{
    RaycastHit hit;
    if (Physics.Raycast(transform.position, Vector3.down, out hit, 3f, ground))
    {
        if (hit.collider.gameObject == floor)
        {
            return true;
        }
    }
    return false;
}



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("EnemyHead"))
        {
            Destroy(collision.transform.parent.gameObject);
            Jump();
            Jump();
        
        StartCoroutine(WaitAndCheckFloor());
    }
}

IEnumerator WaitAndCheckFloor()
{
    yield return new WaitForSeconds(5);
    if (isOnFloor(floors[currentIndex]))
    {
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<script_mouvement>().enabled = true;
        Invoke(nameof(reloadLevel), 1.3f);
    }
    else
    {
        currentIndex++;
    }
}
void reloadLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    
}

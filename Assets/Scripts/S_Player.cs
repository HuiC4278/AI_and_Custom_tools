using UnityEngine;

public class S_Player : MonoBehaviour
{
    private float moveHorizontel;
    private float moveVertontel;
    public float speed = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontel = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        //Moves player by vertical input
        transform.Translate(Vector3.forward * Time.deltaTime * speed * moveVertical);
        //Moves player by horizontal input
        transform.Translate(Vector3.right * Time.deltaTime * speed * moveHorizontel);
    }
}

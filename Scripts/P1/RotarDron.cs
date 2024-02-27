using UnityEngine;

public class RotarDron : MonoBehaviour
{
    public float rotationSpeed = 5f; // Velocidad de rotación en grados por segundo

    private Rigidbody rb;
    private GameManager gm ;

    private int player = 1; 
    public GameObject myself;
    public int bola; 
    private Vector3 rotationAxis;

    private void Awake() {
        gm = FindAnyObjectByType<GameManager>();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (gm.getPlayer()==player && gm.getBola()==bola) {
        
            if (Input.GetKey(KeyCode.J)){   
                //eje Z
                rotationAxis = Vector3.forward; 
                //rotationAxis = Vector3.right; 
            }else if(Input.GetKey(KeyCode.L)){   
                //eje Z
                rotationAxis = Vector3.back;
                //rotationAxis = Vector3.left;
            }            
            Quaternion targetRotation = Quaternion.Euler(rotationAxis * rotationSpeed * Time.deltaTime);
            rb.MoveRotation(rb.rotation * targetRotation);
        }
    }
}

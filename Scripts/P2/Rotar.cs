using UnityEngine;

public class Rotar : MonoBehaviour
{
    public float rotationSpeed = 15f; // Velocidad de rotación en grados por segundo

    private Rigidbody rb;
    private GameManager gm ;

    private int player = 2; 
    public GameObject myself;
    public int bola; 
    private Vector3 rotationAxis;

    private void Awake() {
        gm = FindAnyObjectByType<GameManager>();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (gm.getPlayer()==player && gm.getBola()==bola && myself.tag == "obj_rota") {
        
            if (Input.GetKey(KeyCode.J)){   
                //eje Y
                rotationAxis = Vector3.up;             
            }else if(Input.GetKey(KeyCode.L)){   
                //eje Y
                rotationAxis = Vector3.down;
            }else if(Input.GetKey(KeyCode.I)){   
                //eje X
                rotationAxis = Vector3.right; 
            }else if(Input.GetKey(KeyCode.K)){   
                //eje X
                rotationAxis = Vector3.left; 
            }

            Quaternion targetRotation = Quaternion.Euler(rotationAxis * rotationSpeed * Time.deltaTime);
            rb.MoveRotation(rb.rotation * targetRotation);
        }
    }
}

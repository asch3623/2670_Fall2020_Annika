using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CharacterMovement : MonoBehaviour
{
  private Rigidbody rb;
  public float moveSpeed = 10f;
  public bool isDarting;
  private int seconds = 3, coolDownSeconds = 10;
  public BoolData coolDown;

  private void Start()
  {
    rb = GetComponent<Rigidbody>();
    coolDown.value = false;
  }

  private void FixedUpdate()
  
  {
    rb.transform.rotation = Quaternion.Euler(0,0,0);
    
    float moveH = Input.GetAxis("Horizontal");
    float moveV = Input.GetAxis("Vertical");
    Vector3 movement = new Vector3(moveH, 0f, moveV)* Time.fixedDeltaTime * moveSpeed;
    rb.MovePosition(transform.position + movement);
    
   

  }

  private void Update()
  {
     if (Input.GetKeyUp(KeyCode.LeftShift) && isDarting == false && coolDown.value == false)
        {
          isDarting = true;
          moveSpeed = 50f;
          StartCoroutine(Dart());
        }
    
        if (coolDown.value == true)
        {
          StartCoroutine(reloadDart());
        }
  }

  IEnumerator Dart()
  {
    yield return new WaitForSeconds(seconds);
    moveSpeed = 20f;
    isDarting = false;
    coolDown.value = true;
  }
  IEnumerator reloadDart()
  {
    yield return new WaitForSeconds(coolDownSeconds);
    coolDown.value = false;
  }
}

using UnityEngine;


[RequireComponent(typeof(CharacterController))]

public class CharacterWithStates : MonoBehaviour
{​​

private CharacterController controller;
public CharacterStateMachineData characterStates;
private Vector3 movement;
public float moveSpeed = 3f;
public float gravity = -9.81f;
private void Start()
{​​
    controller = GetComponent<CharacterController>();
}​​

private void Update()
{ var newInput = Input.GetAxis("Vertical");
    switch (characterStates.value)
    {
        case CharacterStateMachineData.characterStates.StandardWalk:
            movement.Set(newInput,gravity,0);
            break;
        case CharacterStateMachineData.characterStates.WallCrawl:
            movement.Set(0,newInput,0);
            break;
        case CharacterStateMachineData.characterStates.KnockBack:
            print("knock back");
            break;
    }

    var newMovement = movement * (moveSpeed * Time.deltaTime);
    controller.Move(newMovement);
}​​

}​​

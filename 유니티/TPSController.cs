using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPSController : MonoBehaviour
{
    [SerializeField] Transform character;
    [SerializeField] Transform cameraArm;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip Walk_01;
    [SerializeField] AudioClip Walk_02;

    float cameraHorizontalSpeed = 3f;
    float moveSpeed = 0f;
    float walkSpeed = 3f;
    float runSpeed = 5f;

    Animator animator;
    void Start()
    {
        animator = character.GetComponent<Animator>();
        moveSpeed = walkSpeed;
    }
    void Update()
    {
        Move();
        LookAround();
    }

    private void Move()
    {
        Vector2 moveFront = new Vector2(0, Input.GetAxis("Vertical"));
        Vector2 moveRight = new Vector2(Input.GetAxis("Horizontal"), 0);
        // Horizontal 또는 Vertical 이 눌렸는지 확인한다.
        // Horizontal 또는 Vertical 이 눌리면 0 ~ 1 까지의 값이 나온다.
        bool isRun =  moveFront.magnitude != 0 && Input.GetKey(KeyCode.LeftShift);
        bool isMove = moveFront.magnitude != 0;
        // magnitude 를 사용해 moveFront 의 길이를 반환한다. 아무것도 누르지않은 상태에서는 Input.GetAxis("Vertical") 이 0을 반환하기때문에 길이는 0 * 0 + 0 * 0  = 0 이라 false 값이 isMove 에 들어가게된다.
        bool isMoveRight = moveFront.magnitude == 0 && moveRight.magnitude != 0;

            animator.SetBool("Walk", isMove);
            animator.SetBool("WalkRight", isMoveRight);
        if (isRun)
        {
            animator.SetBool("Run", isRun);
            moveSpeed = runSpeed;
        }
        else
        {
            animator.SetBool("Run", isRun);
            moveSpeed = walkSpeed;
        }
        if(isMove || isMoveRight)
        {
            Vector3 lookForward = new Vector3(cameraArm.forward.x, 0f, cameraArm.forward.z).normalized;
            Vector3 lookRight = new Vector3(cameraArm.right.x, 0f, cameraArm.right.z).normalized;
            Vector3 moveDir = lookForward * moveFront.y + lookRight * moveRight.x;

            character.forward = lookForward;
            transform.position += moveDir * Time.deltaTime * moveSpeed;
        }
    }

    private void LookAround()
    {
        // 이전 위치에 비해 얼마나 움직였는지 알아낸후 카메라 각도에 더해준다.
        // 프로그래밍에서는 이전값과 현재값의 차이를 Delta 라고 표현한다.

        Vector2 mouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y")); 
        // 마우스가 움직인 수치는 Input.GetAxis 함수에서 매개변수로 Mouse X 와 Mouse Y 를 넣어서 가져올수있다.
        Vector3 camAngle = cameraArm.rotation.eulerAngles; 
        // eulerAngles 로 변환시키는 이유는 Quaternion 값을 Vector3 로 변환하기 위해서.
        float x = camAngle.x - mouseDelta.y; 
        // 위, 아래 카메라 이동 범위를 제한하기 위해서.

        if (x < 180f)
            x = Mathf.Clamp(x, -1f, 27f);
        else
            x = Mathf.Clamp(x, 316f, 361f);

        cameraArm.rotation = Quaternion.Euler(x, camAngle.y + mouseDelta.x * cameraHorizontalSpeed, camAngle.z); 
        // 마우스가 움직인 수치와 카메라의 각도를 더한 후 다시 Vector3 값을 Quaternion 으로 변환해 rotation 에 넣어준다.

    }
}
// 카메라 기준 
// ----------------------------------------------------------------------------------------------------------------------------------------------
// 캐릭터 기준
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPSController : MonoBehaviour
{
    [SerializeField] Transform character;
    [SerializeField] Transform cameraArm;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip Walk_01;
    [SerializeField] AudioClip Walk_02;

    float cameraHorizontalSpeed = 3f;
    float moveSpeed = 0f;
    float walkSpeed = 3f;
    float runSpeed = 5f;

    Animator animator;
    void Start()
    {
        animator = character.GetComponent<Animator>();
        moveSpeed = walkSpeed;
    }
    void Update()
    {
        Move();
        LookAround();
        Debug.Log(cameraArm.rotation);
    }

    private void Move()
    {
        Vector2 moveFront = new Vector2(0, Input.GetAxis("Vertical"));
        Vector2 moveRight = new Vector2(Input.GetAxis("Horizontal"), 0);
        // Horizontal 또는 Vertical 이 눌렸는지 확인한다.
        // Horizontal 또는 Vertical 이 눌리면 0 ~ 1 까지의 값이 나온다.
        bool isRun =  moveFront.magnitude != 0 && Input.GetKey(KeyCode.LeftShift);
        bool isMove = moveFront.magnitude != 0;
        bool isMoveRight = moveFront.magnitude == 0 && moveRight.magnitude != 0;
        // magnitude 를 사용해 moveFront 의 길이를 반환한다. 아무것도 누르지않은 상태에서는 Input.GetAxis("Vertical") 이 0을 반환하기때문에 길이는 0 * 0 + 0 * 0  = 0 이라 false 값이 isMove 에 들어가게된다.

        animator.SetBool("Walk", isMove);
        animator.SetBool("WalkRight", isMoveRight);

        if(!isMove && !isMoveRight)
            character.forward = new Vector3(cameraArm.forward.x, 0f, cameraArm.forward.z).normalized;
        if (isRun)
        {
            animator.SetBool("Run", isRun);
            moveSpeed = runSpeed;
        }
        else
        {
            animator.SetBool("Run", isRun);
            moveSpeed = walkSpeed;
        }
        if(isMove && !isMoveRight)
        {
            Vector3 lookForward = new Vector3(cameraArm.forward.x, 0f, cameraArm.forward.z).normalized;
            Vector3 lookRight = new Vector3(cameraArm.right.x, 0f, cameraArm.right.z).normalized;
            Vector3 moveDir = lookForward * moveFront.y + lookRight * moveRight.x;

            character.forward = moveDir;
            transform.position += moveDir * Time.deltaTime * moveSpeed;
        }
        if(isMoveRight && !isMove)
        {
            Vector3 lookForward = new Vector3(cameraArm.forward.x, 0f, cameraArm.forward.z).normalized;
            Vector3 lookRight = new Vector3(cameraArm.right.x, 0f, cameraArm.right.z).normalized;
            Vector3 moveDir = lookForward * moveFront.y + lookRight * moveRight.x;

            character.forward = lookForward;
            transform.position += moveDir * Time.deltaTime * moveSpeed;
        }
    }

    private void LookAround()
    {
        // 이전 위치에 비해 얼마나 움직였는지 알아낸후 카메라 각도에 더해준다.
        // 프로그래밍에서는 이전값과 현재값의 차이를 Delta 라고 표현한다.
        

        Vector2 mouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y")); 
        // 마우스가 움직인 수치는 Input.GetAxis 함수에서 매개변수로 Mouse X 와 Mouse Y 를 넣어서 가져올수있다.
        Vector3 camAngle = cameraArm.rotation.eulerAngles; 
        // eulerAngles 로 변환시키는 이유는 Quaternion 값을 Vector3 로 변환하기 위해서.
        float x = camAngle.x - mouseDelta.y; 
        // 위, 아래 카메라 이동 범위를 제한하기 위해서.

        if (x < 180f)
            x = Mathf.Clamp(x, -1f, 27f);
        else
            x = Mathf.Clamp(x, 316f, 361f);

            cameraArm.rotation = Quaternion.Euler(x, camAngle.y + mouseDelta.x * cameraHorizontalSpeed, camAngle.z);

        // 마우스가 움직인 수치와 카메라의 각도를 더한 후 다시 Vector3 값을 Quaternion 으로 변환해 rotation 에 넣어준다.

    }
}


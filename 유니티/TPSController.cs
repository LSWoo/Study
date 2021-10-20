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
    bool isWalk = false;
    bool isRun = false;

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
        Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        bool isRun = Input.GetKey(KeyCode.LeftShift);
        bool isMove = moveInput.magnitude != 0;
        animator.SetBool("Walk", isMove);
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
        if(isMove)
        {
            Vector3 lookForward = new Vector3(cameraArm.forward.x, 0f, cameraArm.forward.z).normalized;
            Vector3 lookRight = new Vector3(cameraArm.right.x, 0f, cameraArm.right.z).normalized;
            Vector3 moveDir = lookForward * moveInput.y + lookRight * moveInput.x;

            character.forward = lookForward;
            transform.position += moveDir * Time.deltaTime * moveSpeed;

        }
        Debug.Log($"cameraArm.forward.x : {cameraArm.forward.x}");



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

        cameraArm.rotation = Quaternion.Euler(x, camAngle.y + mouseDelta.x * 3, camAngle.z); 
        // 마우스가 움직인 수치와 카메라의 각도를 더한 후 다시 Vector3 값을 Quaternion 으로 변환해 rotation 에 넣어준다.

    }
}

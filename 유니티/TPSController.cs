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
        // ���� ��ġ�� ���� �󸶳� ���������� �˾Ƴ����Ѵ�.
        // ���α׷��ֿ����� �������� ���簪�� ���̸� Delta ��� ǥ���Ѵ�.

        Vector2 mouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y")); 
        // ���콺�� ������ ��ġ�� Input.GetAxis �Լ����� �Ű������� Mouse X �� Mouse Y �� �־ �����ü��ִ�.
        Vector3 camAngle = cameraArm.rotation.eulerAngles; 
        // eulerAngles �� ��ȯ��Ű�� ������ Quaternion ���� Vector3 �� ��ȯ�ϱ� ���ؼ�.
        float x = camAngle.x - mouseDelta.y; 
        // ��, �Ʒ� ī�޶� �̵� ������ �����ϱ� ���ؼ�.

        if (x < 180f)
            x = Mathf.Clamp(x, -1f, 27f);
        else
            x = Mathf.Clamp(x, 316f, 361f);

        cameraArm.rotation = Quaternion.Euler(x, camAngle.y + mouseDelta.x * 3, camAngle.z); 
        // ���콺�� ������ ��ġ�� ī�޶��� ������ ���� �� �ٽ� Vector3 ���� Quaternion ���� ��ȯ�� rotation �� �־��ش�.

    }
}

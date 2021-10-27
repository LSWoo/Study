using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip Walk_01;
    public AudioClip Walk_02;
    Animator animator;
    public float moveSpeed;
    enum moveType
    {
        Walk = 3,
        Run = 5,
        Drive = 2
    }

    void Start()
    {
        animator = this.gameObject.GetComponent<Animator>();
        Managers.Input.KeyAction -= KeyActionCheck; // 혹시라도 다른곳에서 이미 호출을 해서 두번 호출되는 경우를 방지하기위해서.
        Managers.Input.KeyAction += KeyActionCheck;
        Managers.Input.Keyfalse -= AnyKeyFalse;
        Managers.Input.Keyfalse += AnyKeyFalse;
    }

    public void KeyActionCheck()
    {
        bool isWalk = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D);
        bool isRun = Input.GetKey(KeyCode.LeftShift) && isWalk;
        animator.SetBool("Walk", isWalk);
        animator.SetBool("Run", isRun);
        if (!isRun)
            moveSpeed = (float)moveType.Walk;
        else
            moveSpeed = (float)moveType.Run;

        if (Input.GetKey(KeyCode.W))
        {
            this.gameObject.transform.position += Vector3.forward * moveSpeed * Time.deltaTime;
            this.gameObject.transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.forward), 0.2f);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            this.gameObject.transform.position += Vector3.back * moveSpeed * Time.deltaTime;
            this.gameObject.transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.back), 0.2f);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            this.gameObject.transform.position += Vector3.left * moveSpeed * Time.deltaTime;
            this.gameObject.transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(Vector3.left), 0.2f);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            this.gameObject.transform.position += Vector3.right * moveSpeed * Time.deltaTime;
            this.gameObject.transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.right), 0.2f);
        }
    }
    void AnyKeyFalse()
    {
        animator.SetBool("Walk", false);
    }
    public void WalkSound1()
    {
        audioSource.clip = Walk_01;
        audioSource.Play();
    }
    public void WalkSound2()
    {
        audioSource.clip = Walk_02;
        audioSource.Play();
    }
}

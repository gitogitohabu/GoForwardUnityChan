using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{

    // �L���[�u�̈ړ����x
    private float speed = -12;

    // ���ňʒu
    private float deadLine = -10;

    // ���ʉ�������
    private AudioSource blockSound;

    // Start is called before the first frame update
    void Start()
    {
        // AudioSource���擾
        this.blockSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // �L���[�u���ړ�������
        transform.Translate(this.speed * Time.deltaTime, 0, 0);

        // ��ʊO�ɏo����j������
        if (transform.position.x < this.deadLine)
        {
            Destroy(gameObject);
        }
    }

    // �L���[�u���ڐG�����Ƃ��ɌĂ΂��
    void OnCollisionEnter2D(Collision2D collision)
    {
        // �L���[�u���n�ʂɐڐG����Ƃ��ƃL���[�u���m���ςݏd�Ȃ�Ƃ��Ɍ��ʉ�������
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Cube")
        {
            this.blockSound.Play();
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{

    // キューブの移動速度
    private float speed = -12;

    // 消滅位置
    private float deadLine = -10;

    // 効果音をつける
    private AudioSource blockSound;

    // Start is called before the first frame update
    void Start()
    {
        // AudioSourceを取得
        this.blockSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // キューブを移動させる
        transform.Translate(this.speed * Time.deltaTime, 0, 0);

        // 画面外に出たら破棄する
        if (transform.position.x < this.deadLine)
        {
            Destroy(gameObject);
        }
    }

    // キューブが接触したときに呼ばれる
    void OnCollisionEnter2D(Collision2D collision)
    {
        // キューブが地面に接触するときとキューブ同士が積み重なるときに効果音をつける
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Cube")
        {
            this.blockSound.Play();
        }
    }
}
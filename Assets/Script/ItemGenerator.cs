using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    // Prefab格納変数
    public GameObject carPrefab;    // carPrefab
    public GameObject coinPrefab;   // coinPrefab
    public GameObject conePrefab;   // conePrefab

    // スタート地点
    private int startPos = 80;

    // ゴール地点
    private float goalPos = 360f;

    // アイテムを出すx方向の範囲
    private float posRange = 3.4f;

    // 前回アイテム生成時のunityちゃんのZ軸座標
    private float unityPrePos = 25f;

    // アイテム生成を実行する距離間隔
    private float posGeneRange = 15f;

    // アイテム生成位置のunitychanのZ軸座標オフセット値
    private float posGeneOffsetZ = 55f;

    // unityちゃんの情報
    private GameObject unitychan;
    
    // Start is called before the first frame update
    void Start()
    {
        this.unitychan = GameObject.Find("unitychan");
    }

    // Update is called once per frame
    void Update()
    {
        // 以下の条件成立時に次のアイテム生成を実施
        if(this.unityPrePos + posGeneRange <= unitychan.transform.position.z // 前回アイテム生成位置から15m進んでいる
            && unitychan.transform.position.z + posGeneOffsetZ <= goalPos)             // 次のアイテム生成位置がゴール位置前
        {
            // 前回のアイテム生成位置を更新
            unityPrePos += posGeneRange;

            // どのアイテムを出すのかをランダムに設定
            int num = Random.Range(1, 11);
            if (num <= 2)
            {
                // コーンをx軸方向に一直線に生成
                for (float j = -1; j <= 1; j += 0.4f)
                {
                    GameObject cone = Instantiate(conePrefab);
                    cone.transform.position = new Vector3(4 * j, cone.transform.position.y, unitychan.transform.position.z + posGeneOffsetZ);
                }
            }
            else
            {
                // レーンごとにアイテムを生成
                for (int j = -1; j <= 1; j++)
                {
                    // アイテムの種類を決める
                    int item = Random.Range(1, 11);
                    // アイテムを置くZ座標のオフセットをランダムに設定
                    int offsetZ = Random.Range(-5, 6);
                    // 60%コイン配置:30%クルマ配置:10%何もなし
                    if (1 <= item && item <= 6)
                    {
                        // コインを生成
                        GameObject coin = Instantiate(coinPrefab);
                        coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, unitychan.transform.position.z + posGeneOffsetZ + offsetZ);
                    }
                    else if (7 <= item && item <= 9)
                    {
                        // クルマを生成
                        GameObject car = Instantiate(carPrefab);
                        car.transform.position = new Vector3(posRange * j, car.transform.position.y, unitychan.transform.position.z + posGeneOffsetZ + offsetZ);
                    }
                }
            }
        }
    }
}

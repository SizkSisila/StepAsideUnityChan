using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    // unityちゃんの情報
    private GameObject unitychan;

    // Start is called before the first frame update
    void Start()
    {
        unitychan = GameObject.Find("unitychan");
    }

    // Update is called once per frame
    void Update()
    {
        // unityちゃんが通り過ぎて画面外に出たオブジェクトを破棄する
        if (this.gameObject.transform.position.z < unitychan.transform.position.z - 10f)
        {
            Destroy(gameObject);
        }
    }
}

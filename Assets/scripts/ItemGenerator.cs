using UnityEngine;
using System.Collections;

public class ItemGenerator : MonoBehaviour
{
    //carPrefabを入れる
    public GameObject carPrefab;
    //coinPrefabを入れる
    public GameObject coinPrefab;
    //cornPrefabを入れる
    public GameObject conePrefab;

    //unitychanのgameobjectを入れる
    private GameObject unitychan;

    //スタート地点
    private int startPos = 80;
    //ゴール地点
    private int goalPos = 360;
    //アイテムを出すx方向の範囲
    private float posRange = 3.4f;

    //プレイヤーが越えたときアイテムを出す線
    private float itemGenLine = 0;

    //アイテムを出すz軸の座標
    private float itemGenPos;

    //itemGenLineとitemGenPosのz軸方向の間隔
    private int itemGenRange = 15;

    // Use this for initialization
    void Start()
    {
        //unitychanのgameobjectを取得
        this.unitychan = GameObject.Find("unitychan");

        //スタート地点からアイテムを出すためにitemGenPosにstartPosを入れる
        this.itemGenPos = this.startPos;
    }

    // Update is called once per frame
    void Update()
    {
        //unitychanがitemGenLineを越えた、かつ、次のitemGenPosがgoalPosを越えていないとき
        if (this.unitychan.transform.position.z >= itemGenLine && this.itemGenPos + this.itemGenRange <= this.goalPos)
        {
            int num = Random.Range(1, 11);
            if (num <= 2)
            {
                //コーンをx軸方向に一直線に生成
                for (float j = -1; j <= 1; j += 0.4f)
                {
                    GameObject cone = Instantiate(conePrefab);
                    cone.transform.position = new Vector3(4 * j, cone.transform.position.y, this.itemGenPos);
                }
            }
            else
            {

                //レーンごとにアイテムを生成
                for (int j = -1; j <= 1; j++)
                {
                    //アイテムの種類を決める
                    int item = Random.Range(1, 11);
                    //アイテムを置くZ座標のオフセットをランダムに設定
                    int offsetZ = Random.Range(-5, 6);
                    //60%コイン配置:30%車配置:10%何もなし
                    if (1 <= item && item <= 6)
                    {
                        //コインを生成
                        GameObject coin = Instantiate(coinPrefab);
                        coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, this.itemGenPos + offsetZ);
                    }
                    else if (7 <= item && item <= 9)
                    {
                        //車を生成
                        GameObject car = Instantiate(carPrefab);
                        car.transform.position = new Vector3(posRange * j, car.transform.position.y, this.itemGenPos + offsetZ);
                    }
                }
            }
            //アイテムを生成する線を前に出す
            this.itemGenPos += this.itemGenRange;
            //プレイヤーが越えたときアイテムを出す線を前に出す
            this.itemGenLine += this.itemGenRange;
        }
    }
}

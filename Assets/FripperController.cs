using UnityEngine;
using System.Collections;

public class FripperController : MonoBehaviour
{
    //HingiJointコンポーネントを入れる
    private HingeJoint myHingeJoint;

    //初期の傾き
    private float defaultAngle = 20;
    //弾いた時の傾き
    private float flickAngle = -20;

    // Use this for initialization
    void Start()
    {
        //HinjiJointコンポーネント取得
        this.myHingeJoint = GetComponent<HingeJoint>();

        //フリッパーの傾きを設定
        SetAngle(this.defaultAngle);
    }

    // Update is called once per frame
    void Update()
    {

        //左矢印キーを押した時左フリッパーを動かす
        if (Input.GetKeyDown(KeyCode.LeftArrow) && tag == "LeftFripperTag")
        {
            SetAngle(this.flickAngle);
        }
        //右矢印キーを押した時右フリッパーを動かす
        if (Input.GetKeyDown(KeyCode.RightArrow) && tag == "RightFripperTag")
        {
            SetAngle(this.flickAngle);
        }

        //矢印キー離された時フリッパーを元に戻す
        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            SetAngle(this.defaultAngle);
        }


        for (int i = 0; i < Input.touchCount; i++)
        {
            Touch touch = Input.touches[i];//タッチの情報を取得する

            Vector2 touchPos = touch.position;//タッチ位置を取得する

            TouchPhase touchPhase = touch.phase;//タッチの状態を取得

            //if(画面がタッチされ＆タッチされた場所が画面の左側＆タグがleftfripperなら){左フリッパーがうごく}
            if (touchPhase == TouchPhase.Began && touchPos.x < Screen.width / 2 && tag == "leftFripperTag")
            {
                SetAngle(this.flickAngle);
            }

            //if(画面がタッチされ＆タッチされた場所が画面の右側＆タグがrightfripperなら){右フリッパーがうごく}
            if (touchPhase == TouchPhase.Began && touchPos.x > Screen.width / 2 && tag == "RightFripperTag")
            {
                SetAngle(this.flickAngle);
            }

            if (touchPhase == TouchPhase.Began && touchPos.x < Screen.width / 2 && tag == "leftFripperTag"&& touchPhase == TouchPhase.Began && touchPos.x > Screen.width / 2 && tag == "RightFripperTag")
            {
                SetAngle(this.flickAngle);
            }

            if (touchPhase == TouchPhase.Ended)
            {
                SetAngle(this.flickAngle);
            }


        }










    }

    //フリッパーの傾きを設定
    public void SetAngle(float angle)
    {
        JointSpring jointSpr = this.myHingeJoint.spring;
        jointSpr.targetPosition = angle;
        this.myHingeJoint.spring = jointSpr;
    }
}
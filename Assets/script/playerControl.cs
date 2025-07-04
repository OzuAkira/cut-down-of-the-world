using UnityEngine;
using UnityEngine.InputSystem;

public class playerControl : MonoBehaviour
{
    // パラメータ
    public Transform neck;                  // プレイヤーの首のTransformを指定
    public Camera cam;
    public float ms;
    public float sensitivity = 2.0f;     // マウス感度（視点の移動の速さを調整）
    public float minVertical = -90.0f;   // 視点の最小角度（縦の回転制限）
    public float maxVertical = 90.0f;    // 視点の最大角度（縦の回転制限）

    // 演算用変数
    private float rotationX = 0f;       // 縦方向の回転角度（首の回転）

    private Vector3 _velocity;
    private Vector3 cam_forward;
    private Vector3 cam_right;

    // ゲーム開始時に呼ばれる
    void Start()
    {
        // カーソルを非表示＆ロック
        Cursor.lockState = CursorLockMode.Locked;   // カーソルを画面中央に固定
        Cursor.visible = false;                     // カーソルを非表示にする
    }

    // 毎フレーム実行される
    void Update()
    {
        // マウス入力の取得
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;  // 横のマウス移動量を取得し、感度で調整
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;  // 縦のマウス移動量を取得し、感度で調整

        // Player（体）の回転（左右）
        transform.Rotate(0, mouseX, 0);   // プレイヤー（体）の左右の回転をマウスX方向の入力に合わせて行う

        // Neck（首）の回転（上下）
        rotationX -= mouseY; // マウスY方向の入力によって縦方向の回転を更新
        rotationX = Mathf.Clamp(rotationX, minVertical, maxVertical);   // 回転角度を指定された範囲に制限
        neck.localRotation = Quaternion.Euler(rotationX, 0, 0);         // 首の回転を設定。縦方向のみ回転させる


        cam_forward = new Vector3(cam.transform.forward.x, 0, cam.transform.forward.z).normalized;
        cam_right = new Vector3(cam.transform.right.x, 0, cam.transform.right.z).normalized;

        gameObject.transform.localPosition += (cam_right * _velocity.x + cam_forward * _velocity.z) * ms;
        if (Input.GetKey(KeyCode.E))
            gameObject.transform.position += new Vector3(0, 0.1f, 0);
        else if (Input.GetKey(KeyCode.X))
            gameObject.transform.position += new Vector3(0,-0.1f,0);

    }
    void OnMove(InputValue value)
    {
        var axis = value.Get<Vector2>();
        _velocity = new Vector3(axis.x,0,axis.y);
    }
}
//参考にしたサイト References
// https://qiita.com/I_am_bakeneko/items/47e3ef487b58cb898bf9
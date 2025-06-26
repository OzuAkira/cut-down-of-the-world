using UnityEngine;
using UnityEngine.InputSystem;

public class playerControl : MonoBehaviour
{
    // �p�����[�^
    public Transform neck;                  // �v���C���[�̎��Transform���w��
    public Camera cam;
    public float ms;
    public float sensitivity = 2.0f;     // �}�E�X���x�i���_�̈ړ��̑����𒲐��j
    public float minVertical = -90.0f;   // ���_�̍ŏ��p�x�i�c�̉�]�����j
    public float maxVertical = 90.0f;    // ���_�̍ő�p�x�i�c�̉�]�����j

    // ���Z�p�ϐ�
    private float rotationX = 0f;       // �c�����̉�]�p�x�i��̉�]�j

    private Vector3 _velocity;
    private Vector3 cam_forward;
    private Vector3 cam_right;

    // �Q�[���J�n���ɌĂ΂��
    void Start()
    {
        // �J�[�\�����\�������b�N
        Cursor.lockState = CursorLockMode.Locked;   // �J�[�\������ʒ����ɌŒ�
        Cursor.visible = false;                     // �J�[�\�����\���ɂ���
    }

    // ���t���[�����s�����
    void Update()
    {
        // �}�E�X���͂̎擾
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;  // ���̃}�E�X�ړ��ʂ��擾���A���x�Œ���
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;  // �c�̃}�E�X�ړ��ʂ��擾���A���x�Œ���

        // Player�i�́j�̉�]�i���E�j
        transform.Rotate(0, mouseX, 0);   // �v���C���[�i�́j�̍��E�̉�]���}�E�XX�����̓��͂ɍ��킹�čs��

        // Neck�i��j�̉�]�i�㉺�j
        rotationX -= mouseY; // �}�E�XY�����̓��͂ɂ���ďc�����̉�]���X�V
        rotationX = Mathf.Clamp(rotationX, minVertical, maxVertical);   // ��]�p�x���w�肳�ꂽ�͈͂ɐ���
        neck.localRotation = Quaternion.Euler(rotationX, 0, 0);         // ��̉�]��ݒ�B�c�����̂݉�]������


        cam_forward = new Vector3(cam.transform.forward.x, cam.transform.forward.y, cam.transform.forward.z).normalized;
        cam_right = new Vector3(cam.transform.right.x, cam.transform.right.y, cam.transform.right.z).normalized;

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

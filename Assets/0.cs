using UnityEngine;

public class AircraftController : MonoBehaviour
{
    [Header("移動速度設定")]
    public float moveSpeed = 15f;

    [Header("音效元件與音檔")]
    public AudioSource flyingAudioSource;
    public AudioSource effectAudioSource;

    public AudioClip flySound;
    public AudioClip hitSound;
    public AudioClip passSound;     // 1. 新增：通過音效變數

    private bool isDead = false;

    void Start()
    {
        if (flyingAudioSource != null && flySound != null)
        {
            flyingAudioSource.clip = flySound;
            flyingAudioSource.loop = true;
            flyingAudioSource.Play();
        }
    }

    void Update()
    {
        if (isDead) return;

        // 直接用按鍵判斷上下左右 (支援 W/A/S/D 與方向鍵)
        float moveX = 0f;
        float moveY = 0f;

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) moveX = 1f;
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) moveX = -1f;
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) moveY = 1f;
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) moveY = -1f;

        // 計算移動向量並讓飛機移動
        Vector3 moveDir = new Vector3(moveX, moveY, 1f).normalized;
        transform.Translate(moveDir * moveSpeed * Time.deltaTime, Space.Self);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isDead) return;

        // 撞到大樓
        if (other.CompareTag("Obstacle"))
        {
            Debug.Log("撞到大樓！");
            isDead = true;

            if (flyingAudioSource != null)
            {
                flyingAudioSource.Stop();
            }

            if (effectAudioSource != null && hitSound != null)
            {
                effectAudioSource.PlayOneShot(hitSound);
            }
        }
        // 2. 新增：順利通過安全區
        else if (other.CompareTag("PassCheck"))
        {
            Debug.Log("順利通過障礙物！");

            if (effectAudioSource != null && passSound != null)
            {
                effectAudioSource.PlayOneShot(passSound);
            }

            // 通过后可以把這個感應物件關閉或銷毀，避免重複觸發
            Destroy(other.gameObject);
        }
    }
}
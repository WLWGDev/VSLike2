using UnityEngine;

public class NoteManager : MonoBehaviour
{
    public int bpm = 0;
    double currentTime = 0d;

    [SerializeField] Transform tfNoteAppear = null;
    [SerializeField] GameObject goNote = null;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if(currentTime >= 60d / bpm)
        {
            // 위치 지정 없이 원본 프리팹 상태로 생성
            GameObject t_note = Instantiate(goNote);
            // 부모 종속 및 Scale(1,1,1) 등 로컬 속성 유지
            t_note.transform.SetParent(this.transform, false);
            // 부모가 설정된 상태에서 월드 위치를 목표 위치에 동기화 (내부적으로 올바른 localPosition 자동 계산)
            t_note.transform.position = tfNoteAppear.position;

            currentTime -= 60d / bpm;
        }
    }
}

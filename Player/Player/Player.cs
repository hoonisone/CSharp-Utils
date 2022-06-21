

using Hoonisone.ValueContainer.Container;

namespace Hoonisone.Player
{
    public delegate void OnPlay(); // Plyyer가 동작 시작
    public delegate void OnPouse(); // player가 일시정지 됨
    public delegate void OnInit(); // progress가 0으로 초기화됨
    public delegate void OnFinish(); // progress가 length만큼 진행되어 플레이 종료됨
    public delegate void OnJump(float totalProgress); // progress가 점프 된 경우(ex 오디오 플레이에서 커서를 드레그 한 경우) 알림
    public delegate void OnProgress(float totalProgress, float deltaProgress); // 진행되는 동안 실시간으로 전체 진행도와 변화량 제공

    public class Player
    {
        public OnPlay onPlay;
        public OnPouse onPouse;
        public OnInit onInit;
        public OnFinish onFinish;
        public OnProgress onProgress;

        
        private bool isPlaying; // 현재 플레이어가 진행중인가?
        private float progress; // 진행률
        public MinVC<float> speed = new MinVC<float>(0, 1, true); // 초당 progress을 증가량
        // 음수가 들어올 경우 자동으로 0 세팅
        public float length; // 프로그램 사이즈 



        public void Play()
        {

        }
        public void Pause()
        {

        }
        public void Init()
        {

        }
        public void SetSpeed()
        {

        }



    }
}
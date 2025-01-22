using UnityEngine;

// GameScneTrigger : 게임씬에서 첫 초기화시에 동적생성하기 위해 만든 트리거 입니다. 
public class GameSceneTrigger : MonoBehaviour
{

    private void Awake()
    {
        Player playerPrefeb = Resources.Load<Player>("Prefebs/Player/Player") ;

        if (playerPrefeb != null)
        {
            //플레이어 오브젝트를 하이어라키에 생성 후 게임매니저에 초기화
            GameManager.Instance.Player = Instantiate(playerPrefeb);
        }
        else
        {
            Debug.Log($"{gameObject.name}의 {playerPrefeb.name}이 null 입니다.");
        }

    }
}

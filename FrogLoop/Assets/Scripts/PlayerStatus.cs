using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//カエルの状態をもつクラス
public class PlayerStatus : MonoBehaviour {
    public enum Status
    {
        ALPHA,
        BETA,
        GAMMA
    }
    public Status status { get; set; }
    PlayerAlpha alpha;
    PlayerBeta beta;
    PlayerGamma gamma;

    void Start () {
        status = Status.BETA;
        alpha = GetComponent<PlayerAlpha>();
        beta = GetComponent<PlayerBeta>();
        gamma = GetComponent<PlayerGamma>();
    }

    public void Changed(Status _status)
    {
        bool flag = GetPlayerFromStatus(status).InWaterFlag;
        alpha.InWaterFlag = beta.InWaterFlag = gamma.InWaterFlag = flag;

        GetPlayerFromStatus(status).enabled = false;
        status = _status;
        GetPlayerFromStatus(status).enabled = true;
    }

    IPlayerMove GetPlayerFromStatus(Status _status)
    {
        switch (_status)
        {
            case Status.ALPHA:
                return alpha;
            case Status.BETA:
                return beta;
            case Status.GAMMA:
                return gamma;
        }
        return null;
    }
}

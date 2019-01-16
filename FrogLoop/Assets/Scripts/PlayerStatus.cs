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
    [SerializeField] RuntimeAnimatorController AlphaAnimCont;
    [SerializeField] RuntimeAnimatorController BetaAnimCont;
    [SerializeField] RuntimeAnimatorController GammaAnimCont;

    void Start () {
        alpha = GetComponent<PlayerAlpha>();
        beta = GetComponent<PlayerBeta>();
        gamma = GetComponent<PlayerGamma>();
        if (alpha.enabled)
        {
            status = Status.ALPHA;
        }
        if (beta.enabled)
        {
            status = Status.BETA;
        }
        if (gamma.enabled)
        {
            status = Status.GAMMA;
        }
    }

    public void Changed(Status _status)
    {
        Debug.Log(status);
        GetPlayerFromStatus(status).enabled = false;
        status = _status;
        GetPlayerFromStatus(status).enabled = true;
        if (alpha.enabled)
        {
            GetComponent<Animator>().runtimeAnimatorController = AlphaAnimCont;
        }
        if (beta.enabled)
        {
            GetComponent<Animator>().runtimeAnimatorController = BetaAnimCont;
        }
        if (gamma.enabled)
        {
            GetComponent<Animator>().runtimeAnimatorController = GammaAnimCont;
        }
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

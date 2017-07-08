
public enum BuffEvent
{
    Add,
    Remove,
}
public enum PlayerState
{
    Normal,//
    God,//无敌
    Dead,//死亡
}
public enum PlayerEvent
{
    Born,
    ReBorn,
    Dead,
    ChangeState,
}

public enum TerrainType
{
    None,
    Brick1,
    Brick2,
}

public enum GameState
{
    Play,
    Pause,
    End,
}
public enum GameEvent
{
    Start,
    StateChange,
    End,
}


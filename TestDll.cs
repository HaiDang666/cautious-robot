using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestDll
{


    public class FormationCharacters
{
    public string _id;
    public string key;
    public string baseKey;
    public string status;
    public string[] itemList;
    public int atk;
    public int def;
    public int speed;
    public int hp;
    public int level;
    public string contractAddress;
    public string nftId;
    public int position;
}
public class BattleUnit
{
    public int atk;
    public int def;
    public int speed;
    public int hp;
    public string _id;
    public string faction;
    public BattleUnit(int _atk, int _def, int _speed, int _hp, string __id, string _faction)
    {
        atk = _atk;
        def = _def;
        speed = _speed;
        hp = _hp;
        _id = __id;
        faction = _faction;
    }
}
public class BattleProgess
{
    public BattleUnit attacker;
    public BattleUnit target;
    public int turn;
    public int order;
    public string type;
}
public class BattleData
{
    public bool skip;
    public int status;
    public List<BattleProgess> battleProgress;
}

    static class BattleProcess
    {
        public static BattleData GetBattleData(FormationCharacters[] _userCharacters, FormationCharacters[] _opponentCharacters)
        {
            BattleData _battleData = new BattleData();
            _battleData.skip = false;
            _battleData.status = 1;
            _battleData.battleProgress = new List<BattleProgess>();

            BattleProgess battleProgess1 = new BattleProgess();
            battleProgess1.turn = 1;
            battleProgess1.order = 1;
            battleProgess1.type = "Attack";
            battleProgess1.attacker = new BattleUnit(30, 30, 30, 30, "62bc7e36d47e20163c0447ad", "OurSide");
            battleProgess1.target = new BattleUnit(10, 10, 0, 20, "627a348d2a246f967f142ebd", "OpposingSide");

            BattleProgess battleProgess2 = new BattleProgess();
            battleProgess2.turn = 1;
            battleProgess2.order = 2;
            battleProgess2.type = "Attack";
            battleProgess2.attacker = new BattleUnit(15, 15, 15, 15, "62bbf94f59aa4666f6d19b33", "OurSide");
            battleProgess2.target = new BattleUnit(10, 10, 0, 15, "627a348d2a246f967f142ebd", "OpposingSide");

            BattleProgess battleProgess3 = new BattleProgess();
            battleProgess3.turn = 2;
            battleProgess3.order = 1;
            battleProgess3.type = "Attack";
            battleProgess3.attacker = new BattleUnit(12, 14, 13, 10, "62bbf90659aa4666f6d19b1a", "OurSide");
            battleProgess3.target = new BattleUnit(10, 10, 0, 0, "627a348d2a246f967f142ebd", "OpposingSide");
            _battleData.battleProgress.Add(battleProgess1);
            _battleData.battleProgress.Add(battleProgess2);
            _battleData.battleProgress.Add(battleProgess3);
            return _battleData;

        }
    }

    public class E {
        public int a,b;
    }

    public class Startup
    {
        public async Task<object> Invoke(dynamic userCharacters)
        {

            E x = JsonUtility. ("[{a:1},{b:2}]");
            return x;
        }

        BattleData Add7(FormationCharacters[] _userCharacters, FormationCharacters[] _opponentCharacters)
        {
            return BattleProcess.GetBattleData(_userCharacters, _opponentCharacters);
        }
    }
}
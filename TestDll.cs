using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Newtonsoft.Json;

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
        public List<BattleProgess> battleProgress = new List<BattleProgess>();
    }

    public class DistanceWithCharacter
    {
        public int distance;
        public FormationCharacters character;
    }

    public class InputType
    {
        public FormationCharacters[] _userCharacters;
        public FormationCharacters[] _opponentCharacters;
    }
    public class Startup
    {
        public async Task<object> Invoke(string input)
        {
            InputType _input = JsonConvert.DeserializeObject<InputType>(input);
            FormationCharacters[] userCharacters = _input._userCharacters;
            FormationCharacters[] opponentCharacters = _input._opponentCharacters;
            return GenerateBattleData(userCharacters, opponentCharacters);
        }

        string GenerateBattleData(FormationCharacters[] _userCharacters, FormationCharacters[] _opponentCharacters)
        {
            return BattleProcess.GetBattleData(_userCharacters, _opponentCharacters);
        }
    }

    static class BattleProcess
    {
        public static string GetBattleData(FormationCharacters[] _userCharacters, FormationCharacters[] _opponentCharacters)
        {
            BattleData _battleData = new BattleData();
            _battleData.battleProgress = new List<BattleProgess>();
            _battleData.skip = false;
            List<FormationCharacters> orderQueue = new List<FormationCharacters>(_userCharacters.Length + _opponentCharacters.Length);
            orderQueue.AddRange(_userCharacters);
            orderQueue.AddRange(_opponentCharacters);
            orderQueue = orderQueue.OrderByDescending(character => character.speed).ToList();
            for (int i = 0; i < orderQueue.Count; i++)
            {
                FormationCharacters currentCharacter = orderQueue[i];
                if (_userCharacters.Where(character => character._id == orderQueue[i]._id).FirstOrDefault() != null)
                {
                    BattleProgess battleProgess = new BattleProgess();
                    battleProgess.turn = 1;
                    battleProgess.order = i;
                    battleProgess.type = "Attack";
                    FormationCharacters targetCharacter = GetTarget(currentCharacter, _opponentCharacters);
                    targetCharacter.hp = targetCharacter.hp - (currentCharacter.atk - targetCharacter.def);
                    battleProgess.attacker = new BattleUnit(currentCharacter.atk, currentCharacter.def, currentCharacter.speed, currentCharacter.hp, currentCharacter._id, "OurSide");
                    battleProgess.target = new BattleUnit(targetCharacter.atk, targetCharacter.def, targetCharacter.speed, targetCharacter.hp, targetCharacter._id, "OpposingSide");
                    _battleData.battleProgress.Add(battleProgess);
                }
                else if (_opponentCharacters.Where(character => character._id == orderQueue[i]._id).FirstOrDefault() != null)
                {
                    BattleProgess battleProgess = new BattleProgess();
                    battleProgess.turn = 1;
                    battleProgess.order = i;
                    battleProgess.type = "Attack";
                    FormationCharacters targetCharacter = GetTarget(currentCharacter, _userCharacters);
                    targetCharacter.hp = targetCharacter.hp - (currentCharacter.atk - targetCharacter.def);
                    battleProgess.attacker = new BattleUnit(currentCharacter.atk, currentCharacter.def, currentCharacter.speed, currentCharacter.hp, currentCharacter._id, "OpposingSide");
                    battleProgess.target = new BattleUnit(targetCharacter.atk, targetCharacter.def, targetCharacter.speed, targetCharacter.hp, targetCharacter._id, "OurSide");
                    _battleData.battleProgress.Add(battleProgess);
                }
            }
            return JsonConvert.SerializeObject(_battleData);
        }

        public static FormationCharacters GetTarget(FormationCharacters character, FormationCharacters[] targetCharacters)
        {
            int charPos = character.position;
            DistanceWithCharacter distanceWithCharacter = new DistanceWithCharacter();
            for (int i = 0; i < targetCharacters.Length; i++)
            {
                int tPosition = targetCharacters[i].position;
                int distance = (charPos / 3 + tPosition / 3) + (tPosition % 3);
                if (i == 0)
                {
                    distanceWithCharacter.distance = distance;
                    distanceWithCharacter.character = targetCharacters[i];
                }
                else
                {
                    if (distance < distanceWithCharacter.distance)
                    {
                        distanceWithCharacter.distance = distance;
                        distanceWithCharacter.character = targetCharacters[i];
                    }
                }
            }
            return distanceWithCharacter.character;
        }

        public static int ProcessGetTarget(int[] checkPosArr, Dictionary<int, FormationCharacters> _board)
        {
            return 1;
        }
    }
}
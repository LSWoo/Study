```C++
#include <iostream>+		

using namespace std;

enum PlayerType
{
	PT_Knight = 1,
	PT_Archer = 2,
	PT_Mage = 3
};

enum MonsterType
{
	MT_Slime = 1,
	MT_Orc = 2,
	MT_Skeleton = 3
};

struct StatInfo
{
	int HP = 0;
	int Attack = 0;
	int Defence = 0;
};

void EnterLobby();
void PrintMessage(const char* msg);
void CreatePlayer(StatInfo* playerInfo);
void PrintStatInfo(const char* name, const StatInfo& info); 
// 복사를 사용하지않고 참조를 사용한 이유는 크기가 커짐에 따라 참조를 사용해 얻는 성능상의 이득이 크기떄문에. const 를 붙인 이유는 읽기만 할뿐 수정하지않을것이디때문이다.
void EnterGame(StatInfo* playerInfo);
void CreateMonsters(StatInfo monsterInfo[], int Count);
bool EnterBattle(StatInfo* playerInfo, StatInfo* monsterInfo);

int main()
{
	srand((unsigned) time(nullptr));
	//EnterLobby
	//CreatePlayer
	//EnterGame
	//CreateMonsters
	//EnterBattle
	//	
	EnterLobby();
}
void PrintMessage(const char* msg) 
{
	cout << "*****************************************" << endl;
	cout << msg << endl;
	cout << "*****************************************" << endl;
}

void EnterLobby()
{
	while (true)
	{
		PrintMessage("로비에 입장했습니다.");

		StatInfo playerInfo;

		CreatePlayer(&playerInfo);
		PrintStatInfo("Player", playerInfo);
		EnterGame(&playerInfo);

	}
}
void CreatePlayer(StatInfo* playerInfo)
{
	bool isCreatePlayer = false;

	while (isCreatePlayer == false)
	{
		PrintMessage("[ 캐릭터 생성 ]");
		PrintMessage("[1] 기사  [2] 궁수  [3] 마법사");
		cout << ">";

		int  input;
		cin >> input;

		switch (input)
		{
			case 1:
				PrintMessage(" 기사 생성중...");
				playerInfo->HP = 120;
				playerInfo->Attack = 5;
				playerInfo->Defence = 3;
				isCreatePlayer = true;
				break;
			case 2:
				PrintMessage(" 궁수 생성중...");
				playerInfo->HP = 100;
				playerInfo->Attack = 8;
				playerInfo->Defence = 2;
				isCreatePlayer = true;
				break;
			case 3:
				PrintMessage(" 마법사 생성중...");
				playerInfo->HP = 80;
				playerInfo->Attack = 10;
				playerInfo->Defence = 1;
				isCreatePlayer = true;
				break;

			default:
				break;
		}
	}
}
void PrintStatInfo(const char* name, const StatInfo& info)
{
	cout << "*****************************************" << endl;
	cout << "이름 : " << name << " | HP : "<< info.HP << " | ATT : " << info.Attack << " | DEF : " << info.Defence << endl;
	cout << "*****************************************" << endl;
}
void EnterGame(StatInfo* playerInfo)
{
	const int MONSTER_COUNT = 2;
	PrintMessage("게임에 접속했습니다.");
	
	while (true)
	{
		StatInfo monsterInfo[MONSTER_COUNT];
		CreateMonsters(monsterInfo, MONSTER_COUNT); 
		// 배열의 이름은 배열의 시작 주소이기때문에 &monsterInfo 를 넘기지 않고 monsterInfo 를 넘겨준다.

		cout << "[1] 전투  [2] 전투  [3] 도망" << endl;

		int input;
		cin >> input;

		if (input == 1 || input == 2)
		{
			int index = input - 1;
			bool Victory = EnterBattle(playerInfo, &monsterInfo[index]);

			if (Victory == false)
				break;
		}
	}
}
void CreateMonsters(StatInfo monsterInfo[], int Count)
{
	for (int i = 0; i < Count; i++)
	{
		int randValue = 1 + rand() % 3;

		switch (randValue)
		{
		case MT_Slime:
			monsterInfo[i].HP = 10; 
			monsterInfo[i].Attack = 5; 
			monsterInfo[i].Defence = 2;
			break;
		case MT_Orc:
			monsterInfo[i].HP = 20;
			monsterInfo[i].Attack = 15;
			monsterInfo[i].Defence = 2;
			break;
		case MT_Skeleton:
			monsterInfo[i].HP = 30;
			monsterInfo[i].Attack = 15;
			monsterInfo[i].Defence = 4;
			break;
		default:
			break;
		}

		PrintStatInfo("Monster", monsterInfo[i]);
	}
}
bool EnterBattle(StatInfo* playerInfo, StatInfo* monsterInfo)
{
	while (true)
	{
		PrintMessage("전투에 입장했습니다.");

		int damage = playerInfo->Attack - monsterInfo->Defence;
		if (damage < 0)
			damage = 0;

		monsterInfo->HP -= damage;
		if (monsterInfo->HP < 0)
			monsterInfo->HP = 0;

		PrintStatInfo("Monster", *monsterInfo); 
		// StatInfo 를 받아줘야하는데 받아온건 monsterInfo[] 포인터이니까 해당 주소값으로 이동한다.
		
		if (monsterInfo->HP == 0)
		{
			PrintMessage("몬스터를 처치했습니다.");
			return true;
		}

		damage = monsterInfo->Attack - playerInfo->Defence;
		if (damage < 0)
			damage = 0;

		playerInfo->HP -= damage;
		if (playerInfo->HP < 0)
			playerInfo->HP = 0;

		PrintStatInfo("Player", *playerInfo); 
		// 넘겨줄때 &playerInfo 를 넘겨줬기 때문에 참조로 넘길땐 &가 아닌 playerInfo 를 넘겨줘야 하기 때문에 *playerInfo 해당 주소로 이동한다.

		if (playerInfo->HP == 0)
		{
			PrintMessage("You Are Dead.");
			return false;
		}
	}
}

```

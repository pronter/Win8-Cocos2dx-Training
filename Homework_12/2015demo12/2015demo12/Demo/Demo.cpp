#include "Demo/Demo.h"

#include <sqlite3/include/sqlite3.h>
#include<iostream>
using namespace std;



#include "json/rapidjson.h"
#include "json/document.h"
#include "json/writer.h"
#include "json/stringbuffer.h"
using namespace  rapidjson;

//#pragma comment(lib,"C:/Users/CBUU/Desktop/project/richgame/cocos2d/external/sqlite3/libraries/win32/sqlite3.lib")

Demo::Demo()
{

}

Demo::~Demo()
{

}

bool Demo::init()
{
	if (!Layer::init())
	{
		return false;
	}
 	testTMX();
// 	testMap();
// 	testSQLite();
// 	testUserDefault();
// 	testVector();
 	testJson();
	
	return true;
}

void Demo::testJson(){

	//ʹ��rapidjson����json��
	rapidjson::Document document;
	document.SetObject();

	rapidjson::Document::AllocatorType& allocator = document.GetAllocator();
	rapidjson::Value array(rapidjson::kArrayType);
	rapidjson::Value object(rapidjson::kObjectType);

	//Ϊ�����������
	object.AddMember("int", 1, allocator);
	object.AddMember("double", 1.0, allocator);
	object.AddMember("bool", true, allocator);
	object.AddMember("say", "hi", allocator);
	array.PushBack(object, allocator);

	//��Ӽ��ַ�������
	document.AddMember("json", "json string", allocator);
	document.AddMember("array", array, allocator);

	StringBuffer buffer;
	rapidjson::Writer<StringBuffer> writer(buffer);
	document.Accept(writer);

	log("%s", buffer.GetString());

	// ʹ��rapidjson����json��
	rapidjson::Document d;
	d.Parse<0>(buffer.GetString());
	if (d.HasParseError())  //��ӡ��������
	{
		log("GetParseError %s\n", d.GetParseError());
	}

	if (d.IsObject() && d.HasMember("json")) {
		log("%s\n", d["json"].GetString());//��ӡ��ȡhello��ֵ
	}
}

void Demo::testVector(){
	//����Vector����
	Vector<Sprite*> container;

	//������������
	Sprite* A = Sprite::create();
	Sprite* B = Sprite::create();
	Sprite* C = Sprite::create();

	//Ϊÿ�������ϱ�ǩ
	A->setTag(0);
	B->setTag(1);
	C->setTag(2);

	//�Ӻ�������
	container.pushBack(A);
	container.pushBack(B);
	container.pushBack(C);

	//��ȡ��������һ������
	Sprite* sp = container.back();
	log("the tag is %d", sp->getTag());

	//��ȡ����ĵڶ�������
	sp = container.at(1);
	log("the tag is %d", sp->getTag());

	//���õ���������Vector�ı���
	Vector<Sprite*>::iterator it = container.begin();

	for (; it != container.end();)
	{
		//����ɾ����ǩΪ1�ľ���
		if ((*it)->getTag() == 1)
		{
			it = container.erase(it);
		}
		else
		{
			it++;
		}
	}

	sp = container.at(1);
	log("the tag is %d", sp->getTag());

}

void Demo::testTMX()
{
	Size visibleSize = Director::getInstance()->getVisibleSize();

	//����tiledmap����
	TMXTiledMap* tmx = TMXTiledMap::create("PushBox/map.tmx");
	tmx->setPosition(visibleSize.width / 2, visibleSize.height / 2);
	tmx->setAnchorPoint(Vec2(0.5, 0.5));
	this->addChild(tmx);
}

void Demo::testUserDefault()
{
	//�ж��Ƿ����б��������ļ����Ǳ���
	if (!UserDefault::getInstance()->getBoolForKey("isExist"))
	{
		UserDefault::getInstance()->setBoolForKey("isExist", true);
	}

	//���ַ�����ʽ�洢
	UserDefault::getInstance()->setStringForKey("key", "value");
	string word = UserDefault::getInstance()->getStringForKey("key");
	log("the word is %s " , word);

	//��������ʽ�洢
	UserDefault::getInstance()->setIntegerForKey("value", 14);
	int value = UserDefault::getInstance()->getIntegerForKey("value");
	log("the value is %d ", value);
}

void Demo::testSQLite()
{
	//���ݿ�ָ��
	sqlite3* pdb = NULL;
	
	//���ݿ��·��
	string path = FileUtils::getInstance()->getWritablePath() + "save.db";

	//����������ݿ�
	int result = sqlite3_open(path.c_str(), &pdb);

	if (result==SQLITE_OK)
	{
		log("database init");
	}
	
	//����һ���±�
	string sql = "create table hero(ID int primary key not null,name char(10));";

	result = sqlite3_exec(pdb, sql.c_str(), NULL, NULL, NULL);

	if (result==SQLITE_OK)
	{
		log("create table");
	}

	//��������
	sql = "insert into hero values(1,'iori');";
	sqlite3_exec(pdb, sql.c_str(), NULL, NULL, NULL);
	
	sql = "insert into hero values(2,'cbuu');";
	sqlite3_exec(pdb, sql.c_str(), NULL, NULL, NULL);

	sql = "insert into hero values(3,'hoho');";
	sqlite3_exec(pdb, sql.c_str(), NULL, NULL, NULL);

	//ɾ������
	sql = "delete from hero where id=1;";
	sqlite3_exec(pdb, sql.c_str(), NULL, NULL, NULL);

	//��������
	sql = "update hero set name='hehe' where id=3;";
	sqlite3_exec(pdb, sql.c_str(), NULL, NULL, NULL);



	//��ѯ����
	char **re;
	int row, col;

	sqlite3_get_table(pdb, "select * from hero", &re, &row, &col,NULL);
	

	//���ڵ�0���Ǳ�ͷ���������������ݴӵ�1�п�ʼ��
	for (int i = 1; i <= row;i++)
	{
		for (int j = 0; j < col;j++)
		{
			log("%s", re[i*col + j]);
		}
	}

	//����ͷ�ָ��
	sqlite3_free_table(re);

	//��عر����ݿ⣬���������ڴ�й©
	sqlite3_close(pdb);
}

void Demo::testMap()
{
	//����Map����
	Map<string, Sprite*> map;

	Sprite* A = Sprite::create();
	Sprite* B = Sprite::create();
	Sprite* C = Sprite::create();

	A->setTag(0);
	B->setTag(1);
	C->setTag(2);

	//��ֵ�Է�ʽ�������
	map.insert("hero", A);
	map.insert("monster", B);
	map.insert("object", C);

	//��ȡ�ؼ���Ϊmonster�Ķ���
	Sprite* sp = map.at("monster");
	log("the tag is %d", sp->getTag());

	//���õ���������Map
	Map<string, Sprite*>::iterator it = map.begin();

	for (; it != map.end();)
	{
		//ɾ���ؼ���Ϊmonster�Ķ���XXX.firstΪ�ؼ��֣�XXX.secondΪֵ
		if ((*it).first == "monster")
		{
			it = map.erase(it);
		}
		else
		{
			it++;
		}
	}

	sp = map.at("monster");
	if (sp==NULL)
	{
		log("can not find the monster");
	}
	else
	{
		log("the tag is %d", sp->getTag());
	}
	
}

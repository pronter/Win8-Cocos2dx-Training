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

	//使用rapidjson生成json串
	rapidjson::Document document;
	document.SetObject();

	rapidjson::Document::AllocatorType& allocator = document.GetAllocator();
	rapidjson::Value array(rapidjson::kArrayType);
	rapidjson::Value object(rapidjson::kObjectType);

	//为数组添加数据
	object.AddMember("int", 1, allocator);
	object.AddMember("double", 1.0, allocator);
	object.AddMember("bool", true, allocator);
	object.AddMember("say", "hi", allocator);
	array.PushBack(object, allocator);

	//添加简单字符串数据
	document.AddMember("json", "json string", allocator);
	document.AddMember("array", array, allocator);

	StringBuffer buffer;
	rapidjson::Writer<StringBuffer> writer(buffer);
	document.Accept(writer);

	log("%s", buffer.GetString());

	// 使用rapidjson解析json串
	rapidjson::Document d;
	d.Parse<0>(buffer.GetString());
	if (d.HasParseError())  //打印解析错误
	{
		log("GetParseError %s\n", d.GetParseError());
	}

	if (d.IsObject() && d.HasMember("json")) {
		log("%s\n", d["json"].GetString());//打印获取hello的值
	}
}

void Demo::testVector(){
	//创建Vector对象
	Vector<Sprite*> container;

	//创建三个精灵
	Sprite* A = Sprite::create();
	Sprite* B = Sprite::create();
	Sprite* C = Sprite::create();

	//为每个精灵上标签
	A->setTag(0);
	B->setTag(1);
	C->setTag(2);

	//从后插入对象
	container.pushBack(A);
	container.pushBack(B);
	container.pushBack(C);

	//获取数组的最后一个对象
	Sprite* sp = container.back();
	log("the tag is %d", sp->getTag());

	//获取数组的第二个对象
	sp = container.at(1);
	log("the tag is %d", sp->getTag());

	//利用迭代器进行Vector的遍历
	Vector<Sprite*>::iterator it = container.begin();

	for (; it != container.end();)
	{
		//定向删除标签为1的精灵
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

	//创建tiledmap对象
	TMXTiledMap* tmx = TMXTiledMap::create("PushBox/map.tmx");
	tmx->setPosition(visibleSize.width / 2, visibleSize.height / 2);
	tmx->setAnchorPoint(Vec2(0.5, 0.5));
	this->addChild(tmx);
}

void Demo::testUserDefault()
{
	//判断是否已有本地数据文件，非必须
	if (!UserDefault::getInstance()->getBoolForKey("isExist"))
	{
		UserDefault::getInstance()->setBoolForKey("isExist", true);
	}

	//以字符串形式存储
	UserDefault::getInstance()->setStringForKey("key", "value");
	string word = UserDefault::getInstance()->getStringForKey("key");
	log("the word is %s " , word);

	//以整形形式存储
	UserDefault::getInstance()->setIntegerForKey("value", 14);
	int value = UserDefault::getInstance()->getIntegerForKey("value");
	log("the value is %d ", value);
}

void Demo::testSQLite()
{
	//数据库指针
	sqlite3* pdb = NULL;
	
	//数据库的路径
	string path = FileUtils::getInstance()->getWritablePath() + "save.db";

	//创建或打开数据库
	int result = sqlite3_open(path.c_str(), &pdb);

	if (result==SQLITE_OK)
	{
		log("database init");
	}
	
	//创建一个新表
	string sql = "create table hero(ID int primary key not null,name char(10));";

	result = sqlite3_exec(pdb, sql.c_str(), NULL, NULL, NULL);

	if (result==SQLITE_OK)
	{
		log("create table");
	}

	//插入数据
	sql = "insert into hero values(1,'iori');";
	sqlite3_exec(pdb, sql.c_str(), NULL, NULL, NULL);
	
	sql = "insert into hero values(2,'cbuu');";
	sqlite3_exec(pdb, sql.c_str(), NULL, NULL, NULL);

	sql = "insert into hero values(3,'hoho');";
	sqlite3_exec(pdb, sql.c_str(), NULL, NULL, NULL);

	//删除数据
	sql = "delete from hero where id=1;";
	sqlite3_exec(pdb, sql.c_str(), NULL, NULL, NULL);

	//更改数据
	sql = "update hero set name='hehe' where id=3;";
	sqlite3_exec(pdb, sql.c_str(), NULL, NULL, NULL);



	//查询数据
	char **re;
	int row, col;

	sqlite3_get_table(pdb, "select * from hero", &re, &row, &col,NULL);
	

	//由于第0行是表头，所以真正的数据从第1行开始；
	for (int i = 1; i <= row;i++)
	{
		for (int j = 0; j < col;j++)
		{
			log("%s", re[i*col + j]);
		}
	}

	//务必释放指针
	sqlite3_free_table(re);

	//务必关闭数据库，否则会造成内存泄漏
	sqlite3_close(pdb);
}

void Demo::testMap()
{
	//创建Map对象
	Map<string, Sprite*> map;

	Sprite* A = Sprite::create();
	Sprite* B = Sprite::create();
	Sprite* C = Sprite::create();

	A->setTag(0);
	B->setTag(1);
	C->setTag(2);

	//键值对方式插入对象
	map.insert("hero", A);
	map.insert("monster", B);
	map.insert("object", C);

	//获取关键字为monster的对象
	Sprite* sp = map.at("monster");
	log("the tag is %d", sp->getTag());

	//利用迭代器遍历Map
	Map<string, Sprite*>::iterator it = map.begin();

	for (; it != map.end();)
	{
		//删除关键字为monster的对象，XXX.first为关键字，XXX.second为值
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

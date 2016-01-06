#include "HelloWorldScene.h"
#include "base/CCUserDefault.h"
#include "SimpleAudioEngine.h"
#pragma execution_character_set("utf-8") 
USING_NS_CC;

const float SIZE_WSAD = 50.0;
const int FONT_SIZE = 50;
int count = 0;

Scene* HelloWorld::createScene()
{
    // 'scene' is an autorelease object
    auto scene = Scene::create();
    
    // 'layer' is an autorelease object
    auto layer = HelloWorld::create();

    // add layer as a child to scene
    scene->addChild(layer);
    
    // return the scene
    return scene;
}

// on "init" you need to initialize your instance
bool HelloWorld::init()
{
    //////////////////////////////
    // 1. super init first
    if ( !Layer::init() )
    {
        return false;
    }
	CocosDenshion::SimpleAudioEngine::sharedEngine()->playBackgroundMusic("001.mp3", true);
	//���ڼ�¼���ٲ���
	ud = UserDefault::getInstance();
	if (UserDefault::getInstance()->getIntegerForKey("count") == 0){
		ud->setIntegerForKey("count", 100);
		ud->flush(); // ��UserDefault�е�����д�뵽�ļ���
	}
	
	//�����ͼ
	TMXTiledMap* tmx = TMXTiledMap::create("TileMap.tmx");
	Size visibleSize = Director::getInstance()->getVisibleSize();
	tmx->setPosition(visibleSize.width/2, visibleSize.height/2);
	tmx->setAnchorPoint(Vec2(0.5, 0.5));
	this->addChild(tmx,0);
	
	TMXObjectGroup* wall = tmx->getObjectGroup("wall");
	ValueVector walcon = wall->getObjects();
	for (auto obj : walcon){
		ValueMap values = obj.asValueMap();
		//��ȡ�ݺ������꣨cocos2dx���꣩
		int x = values.at("x").asInt();
		int y = values.at("y").asInt();
		Sprite *wall = Sprite::create();
		int disx = (visibleSize.width - tmx->getContentSize().width) / 2;
		int disy = (visibleSize.height - tmx->getContentSize().height) / 2;
		wall->setAnchorPoint(Vec2(0, 0));
		wall->setPosition(Point(x + disx, y + disy));
		//������ǽ�浽wallcontainter
		wallcontainer.pushBack(wall);
		this->addChild(wall, 1);
	}
	

	TMXObjectGroup* des = tmx->getObjectGroup("des");
	ValueVector descon = des->getObjects();
	for (auto obj : descon){
		ValueMap values = obj.asValueMap();
		//��ȡ�ݺ������꣨cocos2dx���꣩
		int x = values.at("x").asInt();
		int y = values.at("y").asInt();
		end = Sprite::create("End.png");
		int disx = (visibleSize.width - tmx->getContentSize().width) / 2;
		int disy = (visibleSize.height - tmx->getContentSize().height) / 2;
		end->setAnchorPoint(Vec2(0, 0));
		end->setPosition(Point(x + disx, y + disy));
		this->addChild(end,1);
	}

	TMXObjectGroup* per = tmx->getObjectGroup("person");
	ValueVector percon = per->getObjects();
	for (auto obj : percon){
		ValueMap values = obj.asValueMap();
		//��ȡ�ݺ������꣨cocos2dx���꣩
		int x = values.at("x").asInt();
		int y = values.at("y").asInt();
		person = Sprite::create("Character-down.png");
		int disx = (visibleSize.width - tmx->getContentSize().width) / 2;
		int disy = (visibleSize.height - tmx->getContentSize().height) / 2;
		person->setAnchorPoint(Vec2(0, 0));
		person->setPosition(Point(x+disx , y+disy));
		this->addChild(person,1);
	}
	
	TMXObjectGroup* boxbox = tmx->getObjectGroup("box");
	ValueVector boxcon = boxbox->getObjects();
	for (auto obj : boxcon){
		ValueMap values = obj.asValueMap();
		//��ȡ�ݺ������꣨cocos2dx���꣩
		int x = values.at("x").asInt();
		int y = values.at("y").asInt();
		box = Sprite::create("Box.png");
		int disx = (visibleSize.width - tmx->getContentSize().width) / 2;
		int disy = (visibleSize.height - tmx->getContentSize().height) / 2;
		box->setAnchorPoint(Vec2(0, 0));
		box->setPosition(Point(x + disx, y + disy));
		this->addChild(box,1);
	}
	
	//����WSAD��ť
	auto menu = Menu::create();
	menu->setPosition(visibleSize.width, 0);
	menu->setAnchorPoint(Vec2::ANCHOR_BOTTOM_RIGHT);
	this->addChild(menu, 10);
	auto label_W = Label::createWithTTF("��", "fonts/arial.ttf", FONT_SIZE);
	auto label_S = Label::createWithTTF("��", "fonts/arial.ttf", FONT_SIZE);
	auto label_A = Label::createWithTTF("��", "fonts/arial.ttf", FONT_SIZE);
	auto label_D = Label::createWithTTF("��", "fonts/arial.ttf", FONT_SIZE);

	auto button_up = MenuItemLabel::create(label_W, CC_CALLBACK_1(HelloWorld::onUpPressed, this));
	auto button_down = MenuItemLabel::create(label_S, CC_CALLBACK_1(HelloWorld::onDownPressed, this));
	auto button_left = MenuItemLabel::create(label_A, CC_CALLBACK_1(HelloWorld::onLeftPressed, this));
	auto button_right = MenuItemLabel::create(label_D, CC_CALLBACK_1(HelloWorld::onRightPressed, this));

	button_up->setPosition(SIZE_WSAD * -2.25, SIZE_WSAD * 3);
	button_down->setPosition(SIZE_WSAD * -2.25, SIZE_WSAD * 1);
	button_left->setPosition(SIZE_WSAD * -3, SIZE_WSAD * 2);
	button_right->setPosition(SIZE_WSAD * -1, SIZE_WSAD * 2);

	button_up->setAnchorPoint(Vec2::ANCHOR_BOTTOM_RIGHT);
	button_down->setAnchorPoint(Vec2::ANCHOR_BOTTOM_RIGHT);
	button_left->setAnchorPoint(Vec2::ANCHOR_BOTTOM_RIGHT);
	button_right->setAnchorPoint(Vec2::ANCHOR_BOTTOM_RIGHT);

	menu->addChild(button_up);
	menu->addChild(button_down);
	menu->addChild(button_left);
	menu->addChild(button_right);



	//������ʾ����Ƿ�ɹ�
	label = LabelTTF::create("Level 1", "SketchFlow Print", 32);
	label->setPosition(Point(visibleSize.width / 2,visibleSize.height - 80));
	label->setHorizontalAlignment(TextHAlignment::CENTER);
	this->addChild(label,120);

	//������ʾ��óɼ�
	// ���洢�����ݶ��뵽�ı�����������Ѿ��洢�����أ�����ֱ�Ӷ�
	label1 = LabelTTF::create("", "Marker Felt", 30);
	label1->setPosition(Point(100, visibleSize.height - 50));
	label1->setHorizontalAlignment(TextHAlignment::CENTER);
	this->addChild(label1, 20);
	label1->setFontName("fonts/arial.ttf");
	label1->setString("Record:" + UserDefault::getInstance()->getStringForKey("count"));
    return true;
}

void HelloWorld::onRightPressed(Ref* sender)
{
	//���°���d���¼�ʵ��:�ұ�
	CCTexture2D* texture = CCTextureCache::sharedTextureCache()->addImage("Character-right.png");
	person->setTexture(texture);
	Point p = person->getPosition();
	Point bp = box->getPosition();
	if (p.x + 32 == bp.x && p.y == bp.y)//�����ƶ����ӣ���Ҫ�ж������Ƿ������ϰ�
	{ 
		Point p(bp.x + 32, bp.y);
		if (!isWall(p)) {
			person->setPosition(bp);
			box->setPosition(bp.x + 32, bp.y);
			isReach(box->getPosition());
		}
	}
	else//����·���ж����Ƿ������ϰ�
	{
		Point p(p.x + 32, p.y);
		if (!isWall(p)) {
			person->setPosition(p);
		}
	}
	++count;
}

void HelloWorld::onLeftPressed(Ref* sender)
{
	//���°���a���¼�ʵ��:���
	CCTexture2D* texture = CCTextureCache::sharedTextureCache()->addImage("Character-left.png");
	person->setTexture(texture);
	Point p = person->getPosition();
	Point bp = box->getPosition();
	if (p.x == bp.x +32 && p.y == bp.y)//�ƶ�����
	{
		Point p(bp.x - 32, bp.y);
		if (!isWall(p)) {
			box->setPosition(bp.x - 32, bp.y);
			person->setPosition(bp);
			isReach(box->getPosition());
		}
	}
	else//����·
	{
		Point p(p.x - 32, p.y);
		if (!isWall(p)) {
			person->setPosition(p);
		}
	}
	++count;
}

void HelloWorld::onUpPressed(Ref* sender)
{
	//���°���w���¼�ʵ��:�ϱ�
	CCTexture2D* texture = CCTextureCache::sharedTextureCache()->addImage("Character-up.png");
	person->setTexture(texture);
	Point p = person->getPosition();
	Point bp = box->getPosition();
	if (p.x == bp.x && p.y + 32 == bp.y)//�ƶ�����
	{
		Point p(bp.x, bp.y +32);
		if (!isWall(p)) {
			box->setPosition(bp.x, bp.y+32);
			person->setPosition(bp);
			isReach(box->getPosition());
		}
	}
	else//����·
	{
		Point p(p.x, p.y+32);
		if (!isWall(p)) {
			person->setPosition(p);
		}
	}
	++count;
}

void HelloWorld::onDownPressed(Ref* sender)
{
	//���°���s���¼�ʵ��:�±�
	CCTexture2D* texture = CCTextureCache::sharedTextureCache()->addImage("Character-down.png");
	person->setTexture(texture);
	Point p = person->getPosition();
	Point bp = box->getPosition();
	if (p.x== bp.x && p.y == bp.y + 32)//�ƶ�����
	{
		Point p(bp.x, bp.y -32);
		if (!isWall(p)) {
			box->setPosition(p);
			person->setPosition(bp);
			isReach(box->getPosition());
		}
	}
	else//����·
	{
		Point p(p.x, p.y - 32);
		if (!isWall(p)) {
			person->setPosition(p);
		}
	}
	++count;
}

//�����ж��˻�������һ���Ƿ������ϰ���
bool HelloWorld::isWall(Point p) {
	Vector<Sprite*>::iterator it = wallcontainer.begin();
	for (; it != wallcontainer.end();it++)
	{
		if ((*it)->getPosition().x == p.x && (*it)->getPosition().y == p.y)
			return true;
	}
	return false;
}

//�ж������Ƿ񵽴�Ŀ�ĵ�
bool HelloWorld::isReach(Point p) {

	if (p.x == end->getPosition().x && p.y == end->getPosition().y) {
		label->setString("FINSHED!");
		//�Ƚϲ�������óɼ�
		if (count < UserDefault::getInstance()->getIntegerForKey("count")) {
			// ��������ж�ȡ���ַ��������뵽UserDefault��
			ud->setIntegerForKey("count", count);
			ud->flush(); // ��UserDefault�е�����д�뵽�ļ���
		}
		label1->setString("Record:" + UserDefault::getInstance()->getStringForKey("count"));
		return true;
	}
	return false;
}



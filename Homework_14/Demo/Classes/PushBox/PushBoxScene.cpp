#include "PushBox/PushBoxScene.h"

const float SIZE_BLOCK = 64.0;
const int SIZE_MAP_WIDTH = 10;
const int SIZE_MAP_HEIGHT = 10;
const float SIZE_WSAD = 100.0;
const int FONT_SIZE = 100;
const int TAG_WALL = 100;
const int TAG_PLAYER = 1;

PushBoxScene::PushBoxScene() :movingBox(NULL)
{

}

PushBoxScene::~PushBoxScene()
{

}

bool PushBoxScene::init()
{
	if (!Layer::init())
	{
		return false;
	}

	visibleSize = Director::getInstance()->getVisibleSize();


	TMXTiledMap* tmx = TMXTiledMap::create("PushBox/map.tmx");
	tmx->setPosition(visibleSize.width / 2, visibleSize.height / 2);
	tmx->setAnchorPoint(Vec2(0.5, 0.5));
	DIS_X = (visibleSize.width - tmx->getContentSize().width) / 2;
	DIS_Y = (visibleSize.height - tmx->getContentSize().height) / 2;
	this->addChild(tmx,0);


	player = Sprite::create("PushBox/player.png");
	player->setAnchorPoint(Vec2(0, 0));
	player->setPosition(SIZE_BLOCK * 1 + DIS_X, SIZE_BLOCK * 8 + DIS_Y);
	player->setTag(TAG_PLAYER);
	this->addChild(player,10);

	parseTMX(tmx);

	initTouchEvent();

	initDatabase();

	return true;
}



void PushBoxScene::initTouchEvent(){
	auto menu = Menu::create();
	menu->setPosition(visibleSize.width,0);
	menu->setAnchorPoint(Vec2::ANCHOR_BOTTOM_RIGHT);
	this->addChild(menu,10);

	auto label_W = Label::createWithTTF("W", "fonts/Marker Felt.ttf", FONT_SIZE);
	auto label_S = Label::createWithTTF("S", "fonts/Marker Felt.ttf", FONT_SIZE);
	auto label_A = Label::createWithTTF("A", "fonts/Marker Felt.ttf", FONT_SIZE);
	auto label_D = Label::createWithTTF("D", "fonts/Marker Felt.ttf", FONT_SIZE);

	auto button_up = MenuItemLabel::create(label_W, CC_CALLBACK_1(PushBoxScene::onUpPressed, this));
	auto button_down = MenuItemLabel::create(label_S, CC_CALLBACK_1(PushBoxScene::onDownPressed, this));
	auto button_left = MenuItemLabel::create(label_A, CC_CALLBACK_1(PushBoxScene::onLeftPressed, this));
	auto button_right = MenuItemLabel::create(label_D, CC_CALLBACK_1(PushBoxScene::onRightPressed, this));
	
	button_up->setPosition(SIZE_WSAD * -1, SIZE_WSAD * 2);
	button_down->setPosition(SIZE_WSAD * -1, SIZE_WSAD * 0);
	button_left->setPosition(SIZE_WSAD * -2, SIZE_WSAD * 1);
	button_right->setPosition(SIZE_WSAD * 0, SIZE_WSAD * 1);

	button_up->setAnchorPoint(Vec2::ANCHOR_BOTTOM_RIGHT);
	button_down->setAnchorPoint(Vec2::ANCHOR_BOTTOM_RIGHT);
	button_left->setAnchorPoint(Vec2::ANCHOR_BOTTOM_RIGHT);
	button_right->setAnchorPoint(Vec2::ANCHOR_BOTTOM_RIGHT);

	menu->addChild(button_up);
	menu->addChild(button_down);
	menu->addChild(button_left);
	menu->addChild(button_right);
}

void PushBoxScene::parseTMX(TMXTiledMap* map)
{
	TMXObjectGroup* objects = map->getObjectGroup("box");
	ValueVector container = objects->getObjects();

	for (auto obj:container)
	{
		ValueMap values = obj.asValueMap();
		Sprite* box = Sprite::create("PushBox/box.png");
		box->setAnchorPoint(Vec2(0, 0));
		box->setPosition(values.at("x").asInt() + DIS_X, values.at("y").asInt() + DIS_Y);
		this->addChild(box,2);
		boxes.pushBack(box);
	}

	objects = map->getObjectGroup("goal");
	container = objects->getObjects();

	for (auto obj:container)
	{
		ValueMap values = obj.asValueMap();
		Sprite* goal = Sprite::create("PushBox/goal.png");
		goal->setAnchorPoint(Vec2(0, 0));
		goal->setPosition(values.at("x").asInt() + DIS_X, values.at("y").asInt() + DIS_Y);
		this->addChild(goal,1);
		goals.pushBack(goal);
	}

	objects = map->getObjectGroup("wall");
	container = objects->getObjects();

	for (auto obj:container)
	{
		ValueMap values = obj.asValueMap();
		Sprite* wall = Sprite::create("PushBox/wall.png");
		wall->setAnchorPoint(Vec2(0, 0));
		wall->setPosition(values.at("x").asInt() + DIS_X, values.at("y").asInt() + DIS_Y);
		wall->setTag(TAG_WALL);
		this->addChild(wall, 1);
		walls.pushBack(wall);
	}
}

void PushBoxScene::moveTo(Sprite* sprite, int x, int y)
{
	if (sprite){
			sprite->setPosition(x*SIZE_BLOCK+DIS_X,y*SIZE_BLOCK+DIS_Y);
			if (sprite->getTag()==TAG_PLAYER)
			{
				score++;
			}
	}
}

cocos2d::Vec2 PushBoxScene::getPos(Sprite* sprite)
{
	if (sprite){
		return Vec2((sprite->getPositionX()-DIS_X) / SIZE_BLOCK, (sprite->getPositionY()-DIS_Y) / SIZE_BLOCK);
	}
	return Vec2(0,0);
}

bool PushBoxScene::isEnd()
{
	int count = 0;
	for (auto b:boxes){
		Vec2 bp = getPos(b);
		for (auto g:goals){
			Vec2 gp = getPos(g);
			if (bp.x == gp.x&&bp.y == gp.y){
				count++;
			}
		}
	}
	return count == goals.size();
}

bool PushBoxScene::canGo(Vec2 pos)
{
	for (auto obj:walls)
	{
		Vec2 wp = getPos(obj);
		
		if (wp == pos)
		{
			return false;
		}
	}
	return true;
}

bool PushBoxScene::haveBox(Vec2 pos)
{
	for (auto sp : boxes){
		Vec2 p = getPos(sp);
		//log("%d %d", p.x, p.y);
		if (p.x == pos.x&&p.y == pos.y)
		{
			movingBox = sp;
			return true;
		}
	}
	return false;
}

void PushBoxScene::moveBox(Vec2 nextPos, Vec2 nextBoxPos)
{
	if (!movingBox)
	{
		return;
	}
	if (canGo(nextBoxPos)&&!haveBox(nextBoxPos))
	{
		moveTo(player, nextPos.x, nextPos.y);
		moveTo(movingBox, nextBoxPos.x, nextBoxPos.y);
		if (isEnd())
		{
			showWin();
		}
	}
}

void PushBoxScene::showWin()
{
	char* s = new char[10];
	sprintf(s, "%d steps", score);

	Label* winLabel = Label::createWithTTF(s, "fonts/arial.ttf", 100);
	winLabel->setPosition(visibleSize.width / 2, visibleSize.height / 2);
	this->addChild(winLabel, 11);
	Director::getInstance()->getEventDispatcher()->removeAllEventListeners();
	
	UserDefault::getInstance()->setIntegerForKey("Score", score);
}


void PushBoxScene::onRightPressed(Ref* sender)
{
	//按下按键d的事件实现
	Vec2 pos = getPos(player);
	Vec2 nextPos;
	Vec2 nextBoxPos;
	nextPos = Vec2(pos.x + 1, pos.y);
	if (canGo(nextPos)){
		if (haveBox(nextPos)){
			nextBoxPos = Vec2(nextPos.x + 1, nextPos.y);
			moveBox(nextPos, nextBoxPos);
		}
		else{
			moveTo(player, nextPos.x, nextPos.y);
		}
	}
}

void PushBoxScene::onLeftPressed(Ref* sender)
{
	//按下按键a的事件实现
	Vec2 pos = getPos(player);
	Vec2 nextPos;
	Vec2 nextBoxPos;
	nextPos = Vec2(pos.x - 1, pos.y);
	if (canGo(nextPos)){
		if (haveBox(nextPos)){
			nextBoxPos = Vec2(nextPos.x - 1, nextPos.y);
			moveBox(nextPos, nextBoxPos);
		}
		else{
			moveTo(player, nextPos.x, nextPos.y);
		}
	}
}

void PushBoxScene::onUpPressed(Ref* sender)
{
	//按下按键w的事件实现
	Vec2 pos = getPos(player);
	Vec2 nextPos;
	Vec2 nextBoxPos;
	nextPos = Vec2(pos.x, pos.y + 1);
	if (canGo(nextPos)){
		if (haveBox(nextPos)){
			nextBoxPos = Vec2(nextPos.x, nextPos.y + 1);
			moveBox(nextPos, nextBoxPos);
		}
		else{
			moveTo(player, nextPos.x, nextPos.y);
		}
	}
}

void PushBoxScene::onDownPressed(Ref* sender)
{
	//按下按键s的事件实现
	Vec2 pos = getPos(player);
	Vec2 nextPos;
	Vec2 nextBoxPos;
	nextPos = Vec2(pos.x, pos.y - 1);
	if (canGo(nextPos)){
		if (haveBox(nextPos)){
			nextBoxPos = Vec2(nextPos.x, nextPos.y - 1);
			moveBox(nextPos, nextBoxPos);
		}
		else{
			moveTo(player, nextPos.x, nextPos.y);
		}
	}
}

void PushBoxScene::initDatabase()
{
	if (UserDefault::getInstance()->getBoolForKey("isExist"))
	{
		UserDefault::getInstance()->setBoolForKey("isExist", true);
	}

	int oldScore = UserDefault::getInstance()->getIntegerForKey("Score",0);

	char* s = new char[10];
	sprintf(s, "%d", oldScore);
	scoreLabel = Label::createWithTTF(s, "fonts/Marker Felt.ttf", 75);
	scoreLabel->setPosition(visibleSize.width / 2, visibleSize.height);
	scoreLabel->setAnchorPoint(Vec2(0.5, 1.0));
	this->addChild(scoreLabel, 10);

	score = 0;
}

Scene* PushBoxScene::createScene()
{
	Scene* scene = Scene::create();
	auto layer = PushBoxScene::create();
	scene->addChild(layer);

	return scene;
}







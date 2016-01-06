#include "HelloWorldScene.h"
#include <iostream>
#include <string>

#pragma execution_character_set("utf-8")
using namespace std;

USING_NS_CC;

Scene* HelloWorld::createScene()
{
    auto scene = Scene::create();
    auto layer = HelloWorld::create();
    scene->addChild(layer);
    return scene;
}

bool HelloWorld::init()
{
    if ( !Layer::init() )
    {
        return false;
    }//这句话是对父类进行初始化

    Size visibleSize = Director::getInstance()->getVisibleSize();
    Vec2 origin = Director::getInstance()->getVisibleOrigin();
	//add background
	Sprite* background = Sprite::create("dog.jpg");
	background->setPosition(visibleSize.width / 2, visibleSize.height / 2);
	addChild(background,1);
	
	auto starMenuItem = MenuItemImage::create("CloseNormal.png", "CloseSelected.png", CC_CALLBACK_1(HelloWorld::sencecallback, this));
	starMenuItem->setPosition(visibleSize.width / 2, 60);
	auto starMenu = Menu::create(starMenuItem, NULL);
	starMenu->setPosition(Point::ZERO);
	addChild(starMenu,2);
    return true;
}

bool HelloWorld::onTouchBegan(Touch *touch, Event *unused_event)
{
	/*
	to be implemented

	*/
	auto location = touch->getLocation();//点击的地址返回到
	fish->runAction(MoveTo::create(1, Vec2(location.x, location.y)));//vec2原名point，他可以表示一个二维坐标点，又同时可以表示一个二维向量
	float o = location.x -fish->getPosition().x;
	float a = location.y - fish->getPosition().y;
	float at = (float)CC_RADIANS_TO_DEGREES(atanf(o / a));

	if (a < 0)
	{
		if (o < 0)
			at = 180 + fabs(at);
		else
			at = 180 - fabs(at);
	}

	fish->runAction(RotateTo::create(1, at));//并不知道，复制了clickandmovetest里的代码


	return true;
}

void HelloWorld::zdcallback(Object* pSender, float h) {
	zd = Sprite::create("fire.png");
	zd->setPosition(h, 60);
	addChild(zd,4);
	float x = fish->getPosition().x;
	float y = fish->getPosition().y;
	zd->runAction(MoveTo::create(1, Vec2(x, y)));

	zd->runAction(Sequence::create(//sequence类解释为创建一组顺序性动作的协助构造函数static Sequence *  create (M m1, M m2, std::nullptr_t listEnd) 
		DelayTime::create(1.4f),
		FadeOut::create(0.2f),//英文解释为 渐隐
		nullptr)
		);//设置动作的时间速度等

}
void HelloWorld::sencecallback(Object *psSender) {
	Size visibleSize = Director::getInstance()->getVisibleSize();
	Vec2 origin = Director::getInstance()->getVisibleOrigin();//显示

	//添加背景
	Sprite* back = Sprite::create("back.jpg");
	back->setPosition(visibleSize.width/2, visibleSize.height/2);
	
	addChild(back,3);
	//添加鱼美人
	fish = Sprite::create("player.png");
	fish->setPosition(visibleSize.width / 2, visibleSize.height / 2);
	addChild(fish,4);

	//添加监听
	EventListenerTouchOneByOne* listener = EventListenerTouchOneByOne::create();
	listener->setSwallowTouches(true);
	listener->onTouchBegan = CC_CALLBACK_2(HelloWorld::onTouchBegan, this);
	Director::getInstance()->getEventDispatcher()->addEventListenerWithSceneGraphPriority(listener,this);
	//添加按钮
	float hei = visibleSize.width / 2;
	auto starMenuItem = MenuItemImage::create("gun.png", "gun,png", CC_CALLBACK_1(HelloWorld::zdcallback,this, hei));
	starMenuItem->setPosition(visibleSize.width*0.46, 60);
	auto starMenu = Menu::create(starMenuItem, NULL);//创建一个菜单包含按钮
	starMenu->setPosition(Point::ZERO);
	this->addChild(starMenu,5);
	auto label = Label::createWithTTF("SPACE WAR!", "fonts/Marker Felt.ttf", 48);

	// position the label on the center of the screen
	label->setPosition(visibleSize.width/2,visibleSize.height*0.25);

	// add the label as a child to this layer
	this->addChild(label, 5);
}

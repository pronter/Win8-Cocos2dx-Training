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
    }//��仰�ǶԸ�����г�ʼ��

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
	auto location = touch->getLocation();//����ĵ�ַ���ص�
	fish->runAction(MoveTo::create(1, Vec2(location.x, location.y)));//vec2ԭ��point�������Ա�ʾһ����ά����㣬��ͬʱ���Ա�ʾһ����ά����
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

	fish->runAction(RotateTo::create(1, at));//����֪����������clickandmovetest��Ĵ���


	return true;
}

void HelloWorld::zdcallback(Object* pSender, float h) {
	zd = Sprite::create("fire.png");
	zd->setPosition(h, 60);
	addChild(zd,4);
	float x = fish->getPosition().x;
	float y = fish->getPosition().y;
	zd->runAction(MoveTo::create(1, Vec2(x, y)));

	zd->runAction(Sequence::create(//sequence�����Ϊ����һ��˳���Զ�����Э�����캯��static Sequence *  create (M m1, M m2, std::nullptr_t listEnd) 
		DelayTime::create(1.4f),
		FadeOut::create(0.2f),//Ӣ�Ľ���Ϊ ����
		nullptr)
		);//���ö�����ʱ���ٶȵ�

}
void HelloWorld::sencecallback(Object *psSender) {
	Size visibleSize = Director::getInstance()->getVisibleSize();
	Vec2 origin = Director::getInstance()->getVisibleOrigin();//��ʾ

	//��ӱ���
	Sprite* back = Sprite::create("back.jpg");
	back->setPosition(visibleSize.width/2, visibleSize.height/2);
	
	addChild(back,3);
	//���������
	fish = Sprite::create("player.png");
	fish->setPosition(visibleSize.width / 2, visibleSize.height / 2);
	addChild(fish,4);

	//��Ӽ���
	EventListenerTouchOneByOne* listener = EventListenerTouchOneByOne::create();
	listener->setSwallowTouches(true);
	listener->onTouchBegan = CC_CALLBACK_2(HelloWorld::onTouchBegan, this);
	Director::getInstance()->getEventDispatcher()->addEventListenerWithSceneGraphPriority(listener,this);
	//��Ӱ�ť
	float hei = visibleSize.width / 2;
	auto starMenuItem = MenuItemImage::create("gun.png", "gun,png", CC_CALLBACK_1(HelloWorld::zdcallback,this, hei));
	starMenuItem->setPosition(visibleSize.width*0.46, 60);
	auto starMenu = Menu::create(starMenuItem, NULL);//����һ���˵�������ť
	starMenu->setPosition(Point::ZERO);
	this->addChild(starMenu,5);
	auto label = Label::createWithTTF("SPACE WAR!", "fonts/Marker Felt.ttf", 48);

	// position the label on the center of the screen
	label->setPosition(visibleSize.width/2,visibleSize.height*0.25);

	// add the label as a child to this layer
	this->addChild(label, 5);
}

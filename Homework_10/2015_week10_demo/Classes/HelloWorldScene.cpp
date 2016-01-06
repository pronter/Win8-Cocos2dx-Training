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
    }
    
	
    Size visibleSize = Director::getInstance()->getVisibleSize();
    Vec2 origin = Director::getInstance()->getVisibleOrigin();

	//add background
	Sprite* background = Sprite::create("background.jpg");
	background->setPosition(visibleSize.width / 2, visibleSize.height / 2);
	addChild(background);

	//create a fish sprite and run animation
	m_fish = Sprite::createWithSpriteFrameName("fish13_01.png");
	Animate* fishAnimate = Animate::create(AnimationCache::getInstance()->getAnimation("fishAnimation"));
	m_fish->runAction(RepeatForever::create(fishAnimate));
	m_fish->setPosition(visibleSize.width / 2, visibleSize.height / 2);
	addChild(m_fish);

	//add touch listener
	EventListenerTouchOneByOne* listener = EventListenerTouchOneByOne::create();
	listener->setSwallowTouches(true);
	listener->onTouchBegan = CC_CALLBACK_2(HelloWorld::onTouchBegan, this);
	Director::getInstance()->getEventDispatcher()->addEventListenerWithSceneGraphPriority(listener, this);

    return true;
}

bool HelloWorld::onTouchBegan(Touch *touch, Event *unused_event)
{
	/*
	to be implemented
	*/
	return true;
}

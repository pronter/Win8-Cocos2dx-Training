#include "HelloWorldScene.h"
#include "base/CCUserDefault.h"
#include "SimpleAudioEngine.h"
#pragma execution_character_set("utf-8") 
using namespace CocosDenshion;
using namespace std;


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

bool HelloWorld::init()
{
	if (!Layer::init())
	{
		return false;
	}
	dispatcher = Director::getInstance()->getEventDispatcher();
	Size visibleSize = Director::getInstance()->getVisibleSize();
	Vec2 origin = Director::getInstance()->getVisibleOrigin();

	tree = Sprite::create("tree.png");
	tree->setPosition(visibleSize.width / 2, visibleSize.height - tree->getContentSize().height / 4-100);

	apple = Sprite::create("apple.png");
	apple->setPosition(visibleSize.width / 2, 250);

	newton = Sprite::create("newton.png");
	newton->setPosition(visibleSize.width / 2, newton->getContentSize().height / 2);

	this->addChild(tree);
	this->addChild(apple);
	this->addChild(newton);

	preloadMusic();
	playBgm();

	//此demo中自定义事件由触摸事件onTouchBegan触发
	testTouchEvent();
	testCustomEvent();
	schedule(schedule_selector (HelloWorld::judge), 0.01f);

	//testKeyboardEvent();

	//testMouseEvent();

	testAccelerationEvent();

	//testDemo();

	return true;
}

void HelloWorld::preloadMusic()
{
	SimpleAudioEngine::getInstance()->preloadBackgroundMusic("Big Bang Theory Theme.mp3");
	//SimpleAudioEngine::getInstance()->preloadEffect("music/shoot.mp3");
}

void HelloWorld::playBgm()
{
	SimpleAudioEngine::getInstance()->playBackgroundMusic("Big Bang Theory Theme.mp3", true);
}

void HelloWorld::playEffect()
{
	SimpleAudioEngine::getInstance()->playEffect("shoot.mp3");
}

void HelloWorld::judge(float t) {
	if (apple->getPosition().y == 50) {
		SimpleAudioEngine::getInstance()->stopBackgroundMusic();
	}
}

void HelloWorld::testTouchEvent()
{
	streak = MotionStreak::create(0.5f, 10, 30, Color3B::WHITE, "flash.png");
	this->addChild(streak, 2);
	auto listener = EventListenerTouchOneByOne::create();
	listener->onTouchBegan = [&](Touch* touch, Event* event){
		touch_pos = touch->getLocation();
		EventCustom e("test");
		e.setUserData(&touch_pos);
		dispatcher->dispatchEvent(&e);
		return true;
	};

	listener->onTouchMoved = [&](Touch* touch, Event* event){
		touch_pos = touch->getLocation();
		//滑动拖尾效果
		if (!isCut) {
			if (touch_pos.x > tree->getPositionX() - tree->getContentSize().width / 2 &&
				touch_pos.x < tree->getPositionX() + tree->getContentSize().width / 2 &&
				touch_pos.y > tree->getPositionY() - tree->getContentSize().height / 2 &&
				touch_pos.y < tree->getPositionY() + tree->getContentSize().height / 2) {
		auto action2 = FadeOut::create(1.0f);
		tree->runAction(action2);
		Vec2 toLaction = Vec2(tree->getPosition().x, 50);
		auto moveTo = MoveTo::create(1.0f, toLaction);
		apple->runAction(moveTo);
		isCut = true;
		playEffect();
		}
		}
		streak->setPosition(touch_pos);
	};

	listener->onTouchEnded = [&](Touch* touch, Event* event){
		log("onTouchEnded");
	};

	dispatcher->addEventListenerWithSceneGraphPriority(listener, this);
}

void HelloWorld::testAccelerationEvent()
{
	Device::setAccelerometerEnabled(true);

	auto listener = EventListenerAcceleration::create([](Acceleration* acceleration, Event* event){
		log("X: %f; Y: %f; Z:%f; ", acceleration->x, acceleration->y, acceleration->z);
	});

	dispatcher->addEventListenerWithSceneGraphPriority(listener, this);
}

void HelloWorld::testKeyboardEvent()
{
	auto listener = EventListenerKeyboard::create();

	listener->onKeyPressed = [&](EventKeyboard::KeyCode code, Event* event){
		if (code == EventKeyboard::KeyCode::KEY_A)
		{
			log("onKeyPressed--A");
		}
	};

	listener->onKeyReleased = [&](EventKeyboard::KeyCode code, Event* event){
		if (code == EventKeyboard::KeyCode::KEY_A)
		{
			log("onKeyReleased--A");
		}
	};

	dispatcher->addEventListenerWithSceneGraphPriority(listener, this);
}

void HelloWorld::testMouseEvent()
{
	auto listener = EventListenerMouse::create();

	listener->onMouseDown = [&](Event* event){
		log("onMouseDown");
	};

	listener->onMouseMove = [&](Event* event){
		log("onMouseMove");
	};

	listener->onMouseUp = [&](Event* event){
		log("onMouseUp");
	};

	listener->onMouseScroll = [&](Event* event){
		log("onMouseScroll");
	};

	dispatcher->addEventListenerWithSceneGraphPriority(listener, this);
}

void HelloWorld::testCustomEvent()
{
	auto listener = EventListenerCustom::create("test", [](EventCustom* event){
		Vec2* pos = (Vec2*)(event->getUserData());

		log("testCustomEvent -- %f %f", pos->x, pos->y);
	});

	dispatcher->addEventListenerWithFixedPriority(listener, 1);
}

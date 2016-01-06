#include "Demo/Demo.h"
#include <string>
using namespace std;
#include "SimpleAudioEngine.h"

using namespace CocosDenshion;

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

	dispatcher = Director::getInstance()->getEventDispatcher();

	

	preloadMusic();
	playBgm();

	//此demo中自定义事件由触摸事件onTouchBegan触发
	testTouchEvent();
	testCustomEvent();


	//testKeyboardEvent();
	//testMouseEvent();
	
	//testAccelerationEvent();

	//testDemo();

	return true;
}

void Demo::preloadMusic()
{
	SimpleAudioEngine::getInstance()->preloadBackgroundMusic("music/bgm.mp3");
	SimpleAudioEngine::getInstance()->preloadEffect("music/shoot.mp3");
}

void Demo::playBgm()
{
	SimpleAudioEngine::getInstance()->playBackgroundMusic("music/bgm.mp3", true);
}

void Demo::playEffect()
{
	SimpleAudioEngine::getInstance()->playEffect("music/shoot.mp3");
}



void Demo::testTouchEvent()
{

	streak = MotionStreak::create(0.5f, 10, 30, Color3B::WHITE, "Demo/flash.png");
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
		streak->setPosition(touch_pos);
	};

	listener->onTouchEnded = [&](Touch* touch, Event* event){
		log("onTouchEnded");
	};

	dispatcher->addEventListenerWithSceneGraphPriority(listener, this);
}

void Demo::testAccelerationEvent()
{
	Device::setAccelerometerEnabled(true);

	auto listener = EventListenerAcceleration::create([](Acceleration* acceleration, Event* event){
		log("X: %f; Y: %f; Z:%f; ", acceleration->x, acceleration->y, acceleration->z);
	});

	dispatcher->addEventListenerWithSceneGraphPriority(listener, this);
}

void Demo::testKeyboardEvent()
{
	auto listener = EventListenerKeyboard::create();

	listener->onKeyPressed = [&](EventKeyboard::KeyCode code, Event* event){
		if (code==EventKeyboard::KeyCode::KEY_A)
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

void Demo::testMouseEvent()
{
	auto listener = EventListenerMouse::create();

	listener->onMouseDown = [&](Event* event){
		log("onMouseDown");
	};

	listener->onMouseMove = [&](Event* event){
		//log("onMouseMove");
	};

	listener->onMouseUp = [&](Event* event){
		log("onMouseUp");
	};

	listener->onMouseScroll = [&](Event* event){
		log("onMouseScroll");
	};

	dispatcher->addEventListenerWithSceneGraphPriority(listener, this);
}

void Demo::testCustomEvent()
{
	auto listener = EventListenerCustom::create("test", [](EventCustom* event){
		Vec2* pos = (Vec2*)(event->getUserData());
		
		log("testCustomEvent -- %f %f",pos->x,pos->y);
	});

	dispatcher->addEventListenerWithFixedPriority(listener, 1);
}


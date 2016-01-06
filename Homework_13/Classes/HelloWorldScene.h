#ifndef __HELLOWORLD_SCENE_H__
#define __HELLOWORLD_SCENE_H__

#include "cocos2d.h"
USING_NS_CC;

class HelloWorld : public cocos2d::Layer
{
public:
    // there's no 'id' in cpp, so we recommend returning the class instance pointer
    static cocos2d::Scene* createScene();

    // Here's a difference. Method 'init' in cocos2d-x returns bool, instead of returning 'id' in cocos2d-iphone
    virtual bool init();
    // implement the "static create()" method manually
    CREATE_FUNC(HelloWorld);
	//“Ù¿÷º”‘ÿ”Î≤•∑≈
	void preloadMusic();
	void playBgm();
	void playEffect();
	void testTouchEvent();
	void testKeyboardEvent();
	void testMouseEvent();
	void testCustomEvent();
	void testAccelerationEvent();
	void judge(float);

private:
	EventDispatcher* dispatcher;
	MotionStreak* streak;
	Vec2 touch_pos;
	bool isTouching;
	bool isCut = false;
	Sprite* tree;
	Sprite* newton;
	Sprite* apple;
};

#endif // __HELLOWORLD_SCENE_H__

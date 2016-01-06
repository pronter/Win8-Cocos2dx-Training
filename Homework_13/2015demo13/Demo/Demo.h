#include "cocos2d.h"

USING_NS_CC;

class Demo :public Layer
{
public:
	Demo();
	~Demo();

	CREATE_FUNC(Demo);

	virtual bool init();


	//“Ù¿÷º”‘ÿ”Î≤•∑≈
	void preloadMusic();
	void playBgm();
	void playEffect();


	void testTouchEvent();

	void testKeyboardEvent();

	void testMouseEvent();

	void testCustomEvent();

	void testAccelerationEvent();

public:



private:
	EventDispatcher* dispatcher;

	MotionStreak* streak;

	Vec2 touch_pos;

	bool isTouching;
	bool isCut;

	Sprite* rope;
	Sprite* man;
	Sprite* box;
};

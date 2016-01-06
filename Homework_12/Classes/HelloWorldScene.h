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

	void initTouchEvent();
	void onRightPressed(Ref* sender);
	void onLeftPressed(Ref* sender);
	void onUpPressed(Ref* sender);
	void onDownPressed(Ref* sender);
	bool isWall(Point p);
	bool isReach(Point p);
	LabelTTF* label;
	LabelTTF* label1;
private:
	Size visibleSize;
	Sprite* end;
	Sprite* person;
	Sprite* box;
	Vector<Sprite*> wallcontainer;
	UserDefault *ud;
};

#endif // __HELLOWORLD_SCENE_H__
